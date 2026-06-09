using DayTracker.Common;
namespace DayTracker.Forms.LoginForm
{
    internal interface ILoginModel: IModel
    {
        Task<OperationResult> Login(string email, string password);
    }
}