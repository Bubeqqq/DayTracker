using DayTracker.Common;

namespace DayTracker.Forms.RegisterForm
{
    internal interface IRegisterModel : IModel
    {
        Task<OperationResult<bool>> Register(string name, string lastName, string email, string password);
    }
}
