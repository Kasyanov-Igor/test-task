using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
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

            // Регистрируем сервисы
            services.AddScoped<ADatabaseConnection, SqliteConnection>();
            services.AddScoped<IRepository<Counterparty>, Repository<Counterparty>>();
            services.AddTransient<CounterpartyViewModel>();
            services.AddTransient<MainWindow>();

            this._serviceProvider = services.BuildServiceProvider();

            var mainWindow = this._serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
