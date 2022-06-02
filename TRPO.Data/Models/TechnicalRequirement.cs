using System.ComponentModel.DataAnnotations;

namespace TRPO.Data.Models;

public class TechnicalRequirement : IEntity
{
    public int Id { get; set; }
    public int OperatingSystemId { get; set; }
    public OperatingSystem OperatingSystem { get; set; }
    [Required]
    public int Storage { get; set; }
    [Required]
    public int Ram { get; set; }
}
