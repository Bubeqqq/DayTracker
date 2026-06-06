namespace DayTracker.Forms.SelectCalendarForm
{
    internal interface ISelectCalendarView : IView
    {
        string InviteCode { get; }

        event Action BtnYourCalendarClicked;
        event Action<int?> BtnSubmitSelectedCalendarClicked;
        event Action<string> BtnSubmitCodeClicked;
        event Action FormLoading;

        string Greeting { set; }

        void LoadSharedCalendars(List<KeyValuePair<int, string>> calendars);
        void ShowValidationErrors(Dictionary<string, string> errors);
        void ClearAllValidationErrors();
    }
}
