using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Data;
using TRPO.Data.Models;

namespace TRPO.WPF.ViewModels
{
    public class CadSystemsEditViewModel : INotifyPropertyChanged
    {
        public CadSystem CadSystem { get; set; } = new CadSystem();
        public TechnicalRequirement TechnicalRequirement { get; set; } = new TechnicalRequirement();
        
        private readonly IGenericRepository<CadSystem> _cadSystemRepository;
        private readonly IGenericRepository<CadCost> _cadCostRepository;
        private readonly IGenericRepository<CadSystemType> _cadSystemTypeRepository;
        private readonly IGenericRepository<Data.Models.OperatingSystem> _operatingSystemRepository;
        private readonly IGenericRepository<TechnicalRequirement> _technicalRequirementRepository;

        public event PropertyChangedEventHandler? PropertyChanged;

        public CadSystemsEditViewModel(IGenericRepository<CadSystem> cadSystemRepository,
                                   IGenericRepository<CadCost> cadCostRepository,
                                   IGenericRepository<CadSystemType> cadSystemTypeRepository,
                                   IGenericRepository<Data.Models.OperatingSystem> operatingSystemRepository,
                                   IGenericRepository<TechnicalRequirement> technicalRequirementRepository)
        {
            _cadSystemRepository = cadSystemRepository;            
            _cadCostRepository = cadCostRepository;
            _cadSystemTypeRepository = cadSystemTypeRepository;
            _operatingSystemRepository = operatingSystemRepository;
            _technicalRequirementRepository = technicalRequirementRepository;            
        }

        public CadSystemsEditViewModel()
        {
        }

        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        
        public void SetCurrentCadSystem(int id)
        {
            CadSystem = _cadSystemRepository.GetEntity(id);
            TechnicalRequirement = _technicalRequirementRepository.GetEntity(CadSystem.TechnicalRequirementId);
            OnPropertyChanged(nameof(CadSystem.Name));
            OnPropertyChanged(nameof(TechnicalRequirement));
        }

        public void AddNewCadSystem(Data.Models.OperatingSystem selectedOperatingSystem, CadSystemType selectedCadSystemType)
        {
            TechnicalRequirement.OperatingSystemId = selectedOperatingSystem.Id;            

            CadSystem.TechnicalRequirement = TechnicalRequirement;
            CadSystem.TypeId = selectedCadSystemType.Id;
            _cadSystemRepository.Create(CadSystem);
        }

        public void DeleteCadSystem(int id) => _cadSystemRepository.Remove(id);

        public IEnumerable<CadCost> PopulateCadCost()
        {
            return _cadCostRepository.GetEntities().ToList();
        }

        public IEnumerable<CadSystemType> PopulateCadSystemType()
        {
            return _cadSystemTypeRepository.GetEntities().ToList();
        }

        public IEnumerable<Data.Models.OperatingSystem> PopulateOperatingSystem()
        {
            return _operatingSystemRepository.GetEntities().ToList();
        }
    }
    
}
