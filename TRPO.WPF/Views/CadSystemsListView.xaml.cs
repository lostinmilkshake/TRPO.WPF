using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TRPO.Data.Models;
using TRPO.WPF.ViewModels;

namespace TRPO.WPF
{
    /// <summary>
    /// Interaction logic for CadSystemsEditView.xaml
    /// </summary>
    public partial class CadSystemsListView : Window
    {
        private CadSystemsListViewModel cadSystemsEditViewModel;
        private readonly IServiceProvider _serviceProvider;

        public CadSystemsListView(CadSystemsListViewModel cadSystemsEditViewModel, IServiceProvider serviceProvider)
        {
            DataContext = this.cadSystemsEditViewModel = cadSystemsEditViewModel;
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            var value = row.Item as CadSystem;


            var window = _serviceProvider.GetService<CadSystemsEditView>();
            window.SetCurrentCadSystem(value.Id);
            window.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = _serviceProvider.GetService<CadSystemsEditView>();            
            window.Show();
        }
    }
}
