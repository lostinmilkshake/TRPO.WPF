using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TRPO.Data;
using TRPO.Data.Models;
using TRPO.WPF.ViewModels;

namespace TRPO.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<DbContext, CadSytemsContext>();
            services.AddScoped<IGenericRepository<CadSystem>, GenericRepository<CadSystem>>();
            services.AddScoped<IGenericRepository<TechnicalRequirement>, GenericRepository<TechnicalRequirement>>();
            services.AddScoped<IGenericRepository<CadCost>, GenericRepository<CadCost>>();
            services.AddScoped<IGenericRepository<Data.Models.OperatingSystem>, GenericRepository<Data.Models.OperatingSystem>>();
            services.AddScoped<IGenericRepository<CadSystemType>, GenericRepository<CadSystemType>>();
            services.AddSingleton<CadSystemsEditView>();
            services.AddScoped<CadSystemsEditViewModel>();
            services.AddScoped<CadCostEditViewModel>();
            services.AddScoped<CadSystemView>();
            services.AddScoped<CadSystemsListViewModel>();
            services.AddScoped<CadSystemsListView>();            
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<CadSystemsListView>();
            mainWindow.Show();
        }
    }
}
