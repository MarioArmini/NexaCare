using System.ComponentModel.DataAnnotations;

namespace Relic.Host.Dto.Addresses;

public class CreateAddressDto
{
    [Required]
    public string CountryId { get; set; }
    [Required]
    public string RegionId { get; set; }
    [Required]
    public string CityId { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string PostalCode { get; set; }
}