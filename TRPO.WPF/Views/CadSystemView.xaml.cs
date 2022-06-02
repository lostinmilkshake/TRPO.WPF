using System;
using System.Windows;
using TRPO.Data.Models;
using TRPO.WPF.ViewModels;

namespace TRPO.WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CadSystemView : Window
    {
        CadCostEditViewModel _cadSystemViewModel;
        private readonly IServiceProvider serviceProvider;

        public CadSystemView(CadCostEditViewModel cadSystemViewModel, IServiceProvider serviceProvider)
        {
            DataContext = _cadSystemViewModel = cadSystemViewModel;
            this.serviceProvider = serviceProvider;
            InitializeComponent();         
            
            foreach (var item in _cadSystemViewModel.PopulateCadSystems())
            {
                CadComboBox.Items.Add(item);
            }
            CadComboBox.DisplayMemberPath = "Name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedOs = CadComboBox.SelectedItem as CadSystem;
                       
            _cadSystemViewModel.AddCadCost(selectedOs);
            this.Close();
        }
    }
}
