using DayTracker.Common;

namespace DayTracker.Forms.SelectCalendarForm
{
    internal interface ISelectCalendarModel : IModel
    {
        OperationResult<string> GetUserFirstName();
    }
}
