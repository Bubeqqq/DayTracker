namespace DayTracker.Forms.SelectCalendarForm
{
    internal interface ISelectCalendarView : IView
    {
        event Action BtnYourCalendarClicked;
        event Action<int?> BtnSubmitSelectedCalendarClicked;
        event Action<string> BtnSubmitCodeClicked;
        event Action FormLoading;

        string Greeting { set; }
    }
}
