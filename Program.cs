using DayTracker.Forms;
using DayTracker.Forms.MainForm;
using DayTracker.Forms.TestForm;
using DayTracker.Navigation;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DayTracker.Database;
using DayTracker.LoginServices;
using DayTracker.HabitAnalysis;
using System.Threading.Tasks;
using DayTracker.LoadedData;
using DayTracker.Database.Datatypes;

namespace DayTracker
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Resources/appsettings.json", optional: false, reloadOnChange: true).Build();

            services.AddDbContext<IDatabaseService, DatabaseService>(options => options.UseNpgsql(configuration.GetConnectionString("NeonDatabase")));
            services.AddSingleton<ILoginService, LoginService>();

            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<IAnalysisService, AnalysisService>();

            services.AddSingleton<ILoadedDataService, LoadedDataService>();

            ConfigureService<IPresenter>(services);
            ConfigureService<IView>(services);
            ConfigureService<IModel>(services);

            services.AddSingleton<MainFormPresenter>();
            services.AddSingleton<IMainFormView, Form1>();
            services.AddSingleton<IMainFormModel, MainFormModel>();

            using var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IDatabaseService>();

                if (db != null)
                {
                    Console.WriteLine("Sprawdzanie i tworzenie bazy danych...");
                    await db.EnsureCreated();
                }
            }

            await serviceProvider.GetRequiredService<ILoadedDataService>().Initialize();

            var mainForm = serviceProvider.GetRequiredService<MainFormPresenter>();
            mainForm.Initialize();

            if (mainForm.View is Form mainFormWindow)
            {
                Application.Run(mainFormWindow);
            }
            else
            {
                MessageBox.Show("G³ówny widok aplikacji nie jest oknem typu Form!");
            }
        }

        private static void ConfigureService<T>(ServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var targetInterface = typeof(T);

            var implementations = assembly.GetTypes()
                .Where(t => targetInterface.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in implementations)
            {
                services.AddTransient(type);
                var relevantInterfaces = type.GetInterfaces()
                    .Where(iface => targetInterface.IsAssignableFrom(iface));

                foreach (var iface in relevantInterfaces)
                {
                    services.AddTransient(iface, type);
                }
            }
        }
    }
}