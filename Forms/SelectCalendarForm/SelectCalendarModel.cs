using DayTracker.LoadedData;
using DayTracker.Database.Datatypes;
using DayTracker.Common;

namespace DayTracker.Forms.SelectCalendarForm
{
    internal class SelectCalendarModel : ISelectCalendarModel
    {
        private readonly ILoadedDataService _loadedDataService;

        public SelectCalendarModel(ILoadedDataService loadedDataService)
        {
            _loadedDataService = loadedDataService;
        }

        public OperationResult<string> GetUserFirstName()
        {
            if (_loadedDataService.GetCurrentUser() is User user)
            {
                return OperationResult<string>.Success(user.FirstName);
            }

            return OperationResult<string>.Failure("Current user is not set correctly!");
        }
    }
}