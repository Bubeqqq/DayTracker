using DayTracker.Navigation;
using System.Windows.Navigation;

namespace DayTracker.Forms.SelectCalendarForm
{
    internal class SelectCalendarPresenter : IPresenter
    {
        private readonly ISelectCalendarView _view;
        private readonly ISelectCalendarModel _model;
        private readonly INavigationService _navigationService;

        public IModel Model => _model;
        public IView View => _view;

        public SelectCalendarPresenter(ISelectCalendarView view, ISelectCalendarModel model, INavigationService navigationService)
        {
            _view = view;
            _model = model;
            _navigationService = navigationService;

            _view.BtnYourCalendarClicked += OnBtnYourCalendarClicked;
            _view.BtnSubmitSelectedCalendarClicked += OnBtnSubmitSelectedCalendarClicked;
            _view.BtnSubmitCodeClicked += OnBtnSubmitCodeClicked;
            _view.FormLoading += OnFormLoading;
        }

        private void OnBtnYourCalendarClicked()
        {
            // model ustawia kalendarz na ten użytwkonika 
            _navigationService.NavigateTo<Calendar.CalendarPresenter>();

        }
        private void OnBtnSubmitSelectedCalendarClicked(int? calendarId)
        {
            // model ustawia kalendarz na ten o id calendarId
            _navigationService.NavigateTo<Calendar.CalendarPresenter>();
        }
        private void OnBtnSubmitCodeClicked(string inviteCode)
        {
            // model wykonuje zapytanie do bazy danych, aby znaleźć kalendarz odpowiadający inviteCode i ustawia go jako aktualny
            _navigationService.NavigateTo<Calendar.CalendarPresenter>();
        }
        private void OnFormLoading()
        {
            SetUserGreeting();
            LoadUserSharedCalendars();

        }
        
        private void SetUserGreeting()
        {
            var result = _model.GetUserFirstName();
            if (result.IsSuccess)
            {
                _view.Greeting = $"Hello {result.Data}!";
            }
            else
            {
                _view.Greeting = $"Error occured: {result.ErrorMsg}";
            }
        }
        private void LoadUserSharedCalendars() // TODO: funkcja ładuje nazwy kalendarzy udostępnionych użytkownikowi i ich id, aby można było je wybrać w interfejsie
        {
            var result = _model.GetUserSharedCalendars();
            if (result.IsSuccess)
            {
                // widok.załadujKalendarzeDoComboBoxa(result.Data);
            }
        }
    }
}