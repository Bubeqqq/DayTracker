using DayTracker.Common;
using DayTracker.LoginServices;
namespace DayTracker.Forms.RegisterForm
{
    internal class RegisterModel : IRegisterModel
    {
        private readonly ILoginService _loginService;

        public RegisterModel(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public async Task<OperationResult> Register(string name, string lastName, string email, string password)
        {
            int result = await _loginService.Register(name, lastName, email, password);
            return result == LoginService.SUCCESS ?
                OperationResult.Success() :
                OperationResult.Failure(_loginService.ConvertLoginResultToMessage(result));
        }
        public async Task<OperationResult> Login(string email, string password)
        {
            int result = await _loginService.Login(email, password);
            return result == LoginService.SUCCESS ?
                OperationResult.Success() :
                OperationResult.Failure(_loginService.ConvertLoginResultToMessage(result));
        }
    }
}