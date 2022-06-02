using System.ComponentModel.DataAnnotations;

namespace TRPO.Data.Models;

public class CadCost : IEntity
{
    public int Id { get; set; }
    [Required]
    public double Cost { get; set; }
    [Required]
    [MaxLength(100)]
    public string Period { get; set; }
    public int CadSystemId { get; set; }
    public virtual CadSystem CadSystem { get; set; }
}
