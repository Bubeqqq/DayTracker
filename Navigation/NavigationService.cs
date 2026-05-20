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
        public event Action<UserControl> OnSceneChanged;

        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        void INavigationService.NavigateTo<TPresenter>()
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter.View is UserControl view)
            {
                if (presenter.Model != null)
                {
                    presenter.Model.NavigationService = this;
                }

                OnSceneChanged?.Invoke(view);
            }
            else
            {
                throw new InvalidOperationException($"Widok prezentera {typeof(TPresenter).Name} musi dziedziczyć po UserControl, aby mógł być wyświetlony jako scena.");
            }
        }

        UserControl INavigationService.LoadUserControl<TPresenter>()
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter.View is UserControl view)
            {
                if (presenter.Model != null)
                {
                    presenter.Model.NavigationService = this;
                }

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

            if (presenter.View is UserControl view)
            {
                if (presenter.Model != null)
                {
                    presenter.Model.NavigationService = this;
                }

                presenter.LoadArgs(args);

                OnSceneChanged?.Invoke(view);
            }
            else
            {
                throw new InvalidOperationException($"Widok prezentera {typeof(TPresenter).Name} musi dziedziczyć po UserControl, aby mógł być wyświetlony jako scena.");
            }
        }

        UserControl INavigationService.LoadUserControl<TPresenter, TArgs>(TArgs args)
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter.View is UserControl view)
            {
                if (presenter.Model != null)
                {
                    presenter.LoadArgs(args);

                    presenter.Model.NavigationService = this;
                }

                return view;
            }
            else
            {
                throw new InvalidOperationException($"Widok prezentera {typeof(TPresenter).Name} musi dziedziczyć po UserControl, aby mógł być wyświetlony jako scena.");
            }
        }
    }
}
