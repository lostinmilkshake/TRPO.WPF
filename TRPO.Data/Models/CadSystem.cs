using System.ComponentModel.DataAnnotations;

namespace TRPO.Data.Models;

public class CadSystem : IEntity
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
    public int TypeId { get; set; }
    public CadSystemType Type { get; set; }
    public int TechnicalRequirementId { get; set; }
    public TechnicalRequirement TechnicalRequirement { get; set; }
    public List<CadCost> CadCosts { get; set; }
}
