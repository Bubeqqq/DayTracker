using DayTracker.Forms;
using DayTracker.Forms.MainForm;
using DayTracker.Forms.TestForm;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DayTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureService<IPresenter>(services);
            ConfigureService<IView>(services);
            ConfigureService<IModel>(services);

            services.AddSingleton<MainFormPresenter>();
            services.AddSingleton<IMainFormView, Form1>();
            services.AddSingleton<IMainFormModel, MainFormModel>();


            using var serviceProvider = services.BuildServiceProvider();
            var mainForm = serviceProvider.GetRequiredService<MainFormPresenter>();
            mainForm.Initialize();

            Application.Run(mainForm.View);
        }

        private static void ConfigureService<T>(ServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var targetInterface = typeof(T);

            var implementations = assembly.GetTypes().Where(t => targetInterface.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            foreach (var type in implementations)
            {
                services.AddTransient(type);
                var implementedInterfaces = type.GetInterfaces();

                foreach (var iface in implementedInterfaces)
                {
                    services.AddTransient(iface, type);
                }
            }
        }
    }
}