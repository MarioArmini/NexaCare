using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NexaCare.Database.EntityFrameworkCore;
using NexaCare.Database.Shared.Identity;
using NexaCare.Domain.Entities.Addresses;
using NexaCare.Domain.Entities.Identity;
using NexaCare.Host.Dto.Auth;
using NexaCare.Host.Managers;
using NexaCare.Host.ObjectMapper;
using NexaCare.Host.Services.Interfaces;
using NexaCare.Host.Shared;

namespace NexaCare.Host.Services.Auth;

public class AuthAppService : IAuthAppService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly NexaCareDbContext _dbContext;
    private IConfiguration _config;
    private readonly LogManager _logManager;
    private readonly IMailAppService _mailAppService;
    private readonly MailManager _mailManager;
    private readonly IMapper _mapper;

    public AuthAppService(UserManager<ApplicationUser> userManager,
        NexaCareDbContext dbContext,
        IConfiguration config,
        LogManager logManager,
        IMailAppService mailAppService,
        MailManager mailManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _dbContext = dbContext;
        _config = config;
        _logManager = logManager;
        _mailAppService = mailAppService;
        _mailManager = mailManager;
        _mapper = mapper;
    }

    public async Task RegisterAsync(RegisterDto input)
    {
        try
        {
            var identityUser = new ApplicationUser
            {
                UserName = input.Username,
                Email = input.Email
            };

            var result = await _userManager.CreateAsync(identityUser, input.Password);
            if (!result.Succeeded)
                throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));

            var domainUser = new User
            {
                Id = identityUser.Id,
                Created = DateTime.UtcNow
            };

            await AssignRoleAsync(identityUser.Id, "User");

            _dbContext.Users.Add(domainUser);
            await _dbContext.SaveChangesAsync();

            await _logManager.CreateInformationLog(LogMessages.USER_CREATED, domainUser.Id.ToString());
        }
        catch (Exception ex)
        {
            await _logManager.CreateErrorLog(ex.Message.ToString(), ex.InnerException?.ToString());
        }
    }
    
    public async Task<string> Login(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is not null)
        {
            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
                return string.Empty;

            var token = GenerateJwtToken(user);

            return token;
        }

        return string.Empty;
    }

    public async Task<string> ForgotPassword(ForgotPasswordDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null) return string.Empty;

        var body = _mailManager.GenerateForgotPasswordBody(user.UserName, "test");
        await _mailAppService.SendMailAsync(user.Email, null, null, "Forgot password", body);

        return await _userManager.GeneratePasswordResetTokenAsync(user);

    }

    public async Task<bool> ResetPassword(ResetPasswordDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
            return false;

        var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
        return result.Succeeded;
    }

    public async Task AssignRoleAsync(Guid userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is not null)
        {
            if (!await _userManager.IsInRoleAsync(user, role))
                await _userManager.AddToRoleAsync(user, role);
        }
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}