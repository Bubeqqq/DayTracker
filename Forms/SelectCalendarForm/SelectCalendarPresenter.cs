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

            _view.BtnYourCalendarClicked += async () => await OnBtnYourCalendarClicked();
            _view.BtnSubmitSelectedCalendarClicked += OnBtnSubmitSelectedCalendarClicked;
            _view.BtnSubmitCodeClicked += OnBtnSubmitCodeClicked;
            _view.FormLoading += OnFormLoading;
        }

        private async Task OnBtnYourCalendarClicked()
        {
            var result = await _model.SetCurrentCalendarToUserCalendar();
            if (result.IsSuccess)
            {
                _navigationService.NavigateTo<Calendar.CalendarPresenter>();
            }
            else
            {
                throw new NotImplementedException("Błąd obsłużyć trzeba");
            }
        }
        private void OnBtnSubmitSelectedCalendarClicked(int? calendarId)
        {
            if (calendarId != null && calendarId > 0)
            {
                _model.SetCurrentCalendar(calendarId.Value);
                _navigationService.NavigateTo<Calendar.CalendarPresenter>();
            }
        }
        private void OnBtnSubmitCodeClicked(string inviteCode)
        {
            inviteCode = inviteCode.Trim();
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(inviteCode))
            {
                errors[nameof(_view.InviteCode)] = "Invite code cannot be empty.";
            }   
            // dodatkowe walidacje inviteCode, np. format, długość itp. można dodać tutaj

            if (errors.Count > 0)
            {
                _view.ShowValidationErrors(errors);
                return;
            }

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
        private void LoadUserSharedCalendars()
        {
            var result = _model.GetUserSharedCalendars();
            if (result.IsSuccess)
            {
                if (result.Data!.Count == 0)
                {
                    _view.LoadSharedCalendars([new KeyValuePair<int, string>(-1, "No shared calendars available")]);
                    return;
                }

                var calendars = result.Data.Select(c => new KeyValuePair<int, string>(c.CalendarId, c.DisplayName)).ToList();
                _view.LoadSharedCalendars(calendars);
            }
        }
    }
}