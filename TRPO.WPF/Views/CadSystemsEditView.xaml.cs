using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRPO.Data;
using TRPO.Data.Models;
using TRPO.WPF.ViewModels;

namespace TRPO.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CadSystemsEditView : Window
    {       
        DbContext context;
        private readonly IServiceProvider _serviceProvider;
        private readonly ViewModels.CadSystemsEditViewModel _mainWindowViewModel;


        public CadSystemsEditView(ViewModels.CadSystemsEditViewModel mainWindowViewModel, DbContext context, IServiceProvider serviceProvider)
        {
            this.context = context;
            _serviceProvider = serviceProvider;
                       
            DataContext = _mainWindowViewModel = mainWindowViewModel;
            InitializeComponent();

            

            var oses = _mainWindowViewModel.PopulateOperatingSystem();
            if (oses.Count() > 0)
            {
                foreach (var os in oses)
                {
                    OsComboBox.Items.Add(os);
                }
                OsComboBox.DisplayMemberPath = "Name";
            }

            var types = _mainWindowViewModel.PopulateCadSystemType();
            if (types.Count() > 0)
            {                
                foreach (var type in types)
                {
                    TypeComboBox.Items.Add(type);
                }
                TypeComboBox.DisplayMemberPath = "Name";
            }
            
        }

        protected override void OnContentRendered(EventArgs e)
        {
            if (_mainWindowViewModel.CadSystem.Id == 0)
            {
                Delete.Visibility = Visibility.Hidden;
                AddCost.Visibility = Visibility.Hidden;
            }
            else
            {
                EditOrAdd.Content = "Edit Cad System";
            }
        }

        public void SetCurrentCadSystem(int id)
        {
            _mainWindowViewModel.SetCurrentCadSystem(id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window1 = _serviceProvider.GetService<CadSystemView>();
            window1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedOs = OsComboBox.SelectedItem as Data.Models.OperatingSystem;                       
            var selectedType = TypeComboBox.SelectedItem as Data.Models.CadSystemType;

            
            _mainWindowViewModel.AddNewCadSystem(selectedOs, selectedType);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.DeleteCadSystem(_mainWindowViewModel.CadSystem.Id);
            this.Close();
        }
    }
}
