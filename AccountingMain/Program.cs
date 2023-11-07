using AccountingBussinessLogic;
using AccountingContracts;
using AccountingDataBaseImplemet.Implements;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingMain
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;
        public static ServiceProvider? ServiceProvider => _serviceProvider;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            
            services.AddTransient<IUserStorage, UserStorage>();
            services.AddTransient<IUserLogic, UserLogic>();
            services.AddTransient<ICityLogic, CityLogic>();
            services.AddTransient<ICityStorage, CityStorage>();




            services.AddTransient<FormMain>();
            services.AddTransient<FormAddAUpdate>();
            services.AddTransient<FormDirectory>();
        }
    }
}