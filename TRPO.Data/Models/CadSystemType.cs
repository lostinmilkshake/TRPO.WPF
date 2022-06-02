using System.ComponentModel.DataAnnotations;

namespace TRPO.Data.Models;

public class CadSystemType : IEntity
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
}
