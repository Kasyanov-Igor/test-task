using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Test_task.Model;
using Test_task.Model.Entities;
using Test_task.Repositories;
using Test_task.Repositories.Interface;
using Test_task.Services;
using Test_task.Services.Interfaces;
using TestTask.Services;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            // Регистрируем зависимости
            services.AddScoped<ADatabaseConnection, SqliteConnection>();
            services.AddScoped<IRepository<Counterparty>, Repository<Counterparty>>();
            services.AddScoped<IRepository<Employee>, Repository<Employee>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddTransient<CounterpartyViewModel>();
            services.AddScoped<CounterpartyEditViewModel>();
            services.AddTransient<OrderViewModel>();
            services.AddTransient<EmployeeViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
