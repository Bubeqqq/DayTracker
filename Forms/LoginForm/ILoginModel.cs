using DayTracker.Common;
namespace DayTracker.Forms.LoginForm
{
    internal interface ILoginModel: IModel
    {
        Task<OperationResult<bool>> Login(string email, string password);
    }
}