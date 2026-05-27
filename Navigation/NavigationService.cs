using DayTracker.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Navigation
{
    internal class NavigationService : INavigationService
    {
        public event Action<IView> OnSceneChanged;

        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        void INavigationService.NavigateTo<TPresenter>()
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter.View is IView view)
            {
                OnSceneChanged?.Invoke(view);
            }
            else
            {
                throw new InvalidOperationException($"Widok prezentera {typeof(TPresenter).Name} musi dziedziczyć po UserControl, aby mógł być wyświetlony jako scena.");
            }
        }

        IView INavigationService.LoadUserControl<TPresenter>()
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter.View is IView view)
            {
                return view;
            }
            else
            {
                throw new InvalidOperationException($"Widok prezentera {typeof(TPresenter).Name} musi dziedziczyć po UserControl, aby mógł być wyświetlony jako scena.");
            }
        }

        void INavigationService.NavigateTo<TPresenter, TArgs>(TArgs args)
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter.View is IView view)
            {
                presenter.LoadArgs(args);

                OnSceneChanged?.Invoke(view);
            }
            else
            {
                throw new InvalidOperationException($"Widok prezentera {typeof(TPresenter).Name} musi dziedziczyć po UserControl, aby mógł być wyświetlony jako scena.");
            }
        }

        IView INavigationService.LoadUserControl<TPresenter, TArgs>(TArgs args)
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter.View is IView view)
            {
                presenter.LoadArgs(args);

                return view;
            }
            else
            {
                throw new InvalidOperationException($"Widok prezentera {typeof(TPresenter).Name} musi dziedziczyć po UserControl, aby mógł być wyświetlony jako scena.");
            }
        }
    }
}
