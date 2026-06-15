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
            _view.BtnSubmitCodeClicked += async (inviteCode) => await OnBtnSubmitCodeClicked(inviteCode);
            _view.FormLoading += async () => await OnFormLoading();

            _navigationService.HideBar();
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
        private async Task OnBtnSubmitCodeClicked(string inviteCode)
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
            var calendarIdResult = await _model.GetCalendarIdByInvitationCode(inviteCode);
            if (calendarIdResult.IsSuccess)
            {
                if (calendarIdResult.Data is int calendarId)
                {
                    var addAccessResult = await _model.AddCalendarAccess(calendarId);
                    if (addAccessResult.IsSuccess)
                    {
                        var setCalendarResult = await _model.SetCurrentCalendar(calendarId);
                        if (!setCalendarResult.IsSuccess)
                        {
                            MessageBox.Show(setCalendarResult.ErrorMsg); // placeholder
                            return;
                        }

                        _navigationService.NavigateTo<Calendar.CalendarPresenter>();
                    }
                    else
                    {
                        MessageBox.Show(addAccessResult.ErrorMsg); // placeholder
                    }
                }
                else
                {
                    MessageBox.Show("Invalid invite code. Please check and try again."); // placeholder
                }
            }
            else
            {
                MessageBox.Show(calendarIdResult.ErrorMsg); // placeholder
            }
            
        }
        private async Task OnFormLoading()
        {
            SetUserGreeting();
            await LoadUserSharedCalendars();
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
        private async Task LoadUserSharedCalendars()
        {
            var result = await _model.GetUserSharedCalendars();
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