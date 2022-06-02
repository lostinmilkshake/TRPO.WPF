using System.ComponentModel.DataAnnotations;

namespace TRPO.Data.Models;

public class OperatingSystem : IEntity
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
}
