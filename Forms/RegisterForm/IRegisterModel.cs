using DayTracker.Common;

namespace DayTracker.Forms.RegisterForm
{
    internal interface IRegisterModel : IModel
    {
        Task<OperationResult> Register(string name, string lastName, string email, string password);
        Task<OperationResult> Login(string email, string password);
    }
}
