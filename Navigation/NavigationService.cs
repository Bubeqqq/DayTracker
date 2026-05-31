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
        public event Action<bool> OnGoBackButtonEnableChange;
        public event Action<bool> OnGoForwardButtonEnableChange;

        private readonly IServiceProvider _serviceProvider;

        //States

        private record NavigationEntry(Type PresenterType, object? Args);

        private readonly List<NavigationEntry> _history = new();
        private int _currentIndex = 0;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        void INavigationService.NavigateTo<TPresenter>()
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter.View is IView view)
            {
                if (_history.Count - 1 > _currentIndex)
                    _history.RemoveRange(_currentIndex + 1, _history.Count - 1 - _currentIndex);
                _history.Add(new NavigationEntry(presenter.GetType(), null));
                _currentIndex = _history.Count - 1;
                OnGoForwardButtonEnableChange?.Invoke(false);
                OnGoBackButtonEnableChange?.Invoke(_currentIndex != 0);


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
                if(_history.Count - 1 > _currentIndex)
                    _history.RemoveRange(_currentIndex + 1, _history.Count - 1 - _currentIndex);
                _history.Add(new NavigationEntry(presenter.GetType(), args));
                _currentIndex = _history.Count - 1;
                OnGoForwardButtonEnableChange?.Invoke(false);
                OnGoBackButtonEnableChange?.Invoke(_currentIndex != 0);

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

        public void GoBack()
        {
            if (_currentIndex <= 0)
                return;

            _currentIndex--;

            NavigationEntry navigationEntry = _history[_currentIndex];

            object presenterObj = _serviceProvider.GetRequiredService(navigationEntry.PresenterType);

            if(_currentIndex == 0)
                OnGoBackButtonEnableChange?.Invoke(false);
            OnGoForwardButtonEnableChange?.Invoke(true);

            if (presenterObj is IPresenter basePresenter)
            {
                if (basePresenter.View is IView view)
                {
                    dynamic dynamicPresenter = basePresenter;

                    if (navigationEntry.Args != null)
                    {
                        dynamicPresenter.LoadArgs((dynamic)navigationEntry.Args);
                    }

                    OnSceneChanged?.Invoke(view);
                }
                else
                {
                    throw new InvalidOperationException($"Widok prezentera {navigationEntry.PresenterType.Name} musi dziedziczyć po odpowiednim interfejsie (np. UserControl), aby mógł być wyświetlony jako scena.");
                }
            }
            else
            {
                throw new InvalidOperationException($"{navigationEntry.PresenterType.Name} nie implementuje IPresenter.");
            }
        }

        public void GoForward()
        {
            if (_currentIndex >= _history.Count - 1)
                return;

            _currentIndex++;

            OnGoBackButtonEnableChange?.Invoke(true);
            if(_currentIndex == _history.Count - 1)
                OnGoForwardButtonEnableChange?.Invoke(false);

            NavigationEntry navigationEntry = _history[_currentIndex];

            object presenterObj = _serviceProvider.GetRequiredService(navigationEntry.PresenterType);

            if (presenterObj is IPresenter basePresenter)
            {
                if (basePresenter.View is IView view)
                {
                    dynamic dynamicPresenter = basePresenter;

                    if (navigationEntry.Args != null)
                    {
                        dynamicPresenter.LoadArgs((dynamic)navigationEntry.Args);
                    }

                    OnSceneChanged?.Invoke(view);
                }
                else
                {
                    throw new InvalidOperationException($"Widok prezentera {navigationEntry.PresenterType.Name} musi dziedziczyć po odpowiednim interfejsie (np. UserControl), aby mógł być wyświetlony jako scena.");
                }
            }
            else
            {
                throw new InvalidOperationException($"{navigationEntry.PresenterType.Name} nie implementuje IPresenter.");
            }
        }
    }
}
