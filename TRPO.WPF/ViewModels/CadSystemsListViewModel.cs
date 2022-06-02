using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
