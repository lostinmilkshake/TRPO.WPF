using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Data;
using TRPO.Data.Models;

namespace TRPO.WPF.ViewModels;

public class CadCostEditViewModel
{
    public CadCost CadCost { get; set; } = new CadCost();
    private readonly IGenericRepository<CadCost> _cadCostRepository;
    private readonly IGenericRepository<CadSystem> _cadSystemRepository;

    public CadCostEditViewModel(IGenericRepository<CadCost> cadCostRepository, IGenericRepository<CadSystem> cadSystemRepository)
    {
        _cadCostRepository = cadCostRepository;
        _cadSystemRepository = cadSystemRepository;
    }

    public void AddCadCost(CadSystem cadSystem)
    {
        CadCost.CadSystemId = cadSystem.Id;
        _cadCostRepository.Create(CadCost);        
    }

    public IEnumerable<CadSystem> PopulateCadSystems()
    {
        return _cadSystemRepository.GetEntities();
    }
}
