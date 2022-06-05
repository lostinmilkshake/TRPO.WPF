using System.Collections.ObjectModel;
using TRPO.Data;
using TRPO.Data.Models;

namespace TRPO.WPF.ViewModels;

public class CadSystemsListViewModel
{
    public ObservableCollection<CadSystem> CadSystems { get; set; } = new ObservableCollection<CadSystem>();

    private readonly IGenericRepository<CadSystem> _cadSystemRepository;

    public CadSystemsListViewModel(IGenericRepository<CadSystem> cadSystemRepository)
    {
        _cadSystemRepository = cadSystemRepository;

        CadSystems = new ObservableCollection<CadSystem>(_cadSystemRepository.GetEntities());
    }          
}
