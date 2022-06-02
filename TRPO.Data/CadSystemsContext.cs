using Microsoft.EntityFrameworkCore;
using TRPO.Data.Models;

namespace TRPO.Data;

public class CadSytemsContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<CadCost> CadCost { get; set; }
    public DbSet<CadSystemType> CadSystemTypes { get; set; }
    public DbSet<CadSystem> CadSytems { get; set; }
    public DbSet<Models.OperatingSystem> OperatingSystems { get; set; }
    public DbSet<TechnicalRequirement> TechnicalRequirements { get; set;}


    public CadSytemsContext()
    {
        _connectionString = "Data Source=(localdb)\\Local; Initial Catalog=CadSystems; persist security info=True; Integrated Security = SSPI;";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
