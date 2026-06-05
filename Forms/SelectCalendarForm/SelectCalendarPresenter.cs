using DayTracker.Navigation;

namespace DayTracker.Forms.SelectCalendarForm
{
    internal class SelectCalendarPresenter : IPresenter
    {
        private readonly ISelectCalendarView _view;
        private readonly ISelectCalendarModel _model;
        private readonly INavigationService _navigationService;

        public IModel Model => _model;
        public IView View => _view;

        public SelectCalendarPresenter(ISelectCalendarView view, ISelectCalendarModel model)
        {
            _view = view;
            _model = model;

            _view.BtnYourCalendarClicked += OnBtnYourCalendarClicked;
            _view.BtnSubmitSelectedCalendarClicked += OnBtnSubmitSelectedCalendarClicked;
            _view.BtnSubmitCodeClicked += OnBtnSubmitCodeClicked;
            _view.FormLoading += OnFormLoading;
        }

        private void OnBtnYourCalendarClicked()
        {
            // model ustawia kalendarz na ten użytwkonika 
        }
        private void OnBtnSubmitSelectedCalendarClicked(int? calendarId)
        {
            // model ustawia kalendarz na ten o id calendarId
        }
        private void OnBtnSubmitCodeClicked(string inviteCode)
        {
            // model wykonuje zapytanie do bazy danych, aby znaleźć kalendarz odpowiadający inviteCode i ustawia go jako aktualny
            // model dodaje permisje dla użytkownika do tego kalendarza
        }
        private void OnFormLoading()
        {
            var firstNameResult = _model.GetUserFirstName();
            if (firstNameResult.IsSuccess)
            {
                _view.Greeting = $"Hello {firstNameResult.Data}!";
            }
            else
            {
                _view.Greeting = $"Error occured: {firstNameResult.ErrorMsg}";
            }
        }
    }
}