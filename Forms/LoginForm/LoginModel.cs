using DayTracker.Common;
using DayTracker.LoginServices;

namespace DayTracker.Forms.LoginForm
{
    internal class LoginModel : ILoginModel
    {
        private readonly ILoginService _loginService;

        public LoginModel(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public async Task<OperationResult<bool>> Login(string email, string password)
        {
            int result = await _loginService.Login(email, password);
            return result == LoginService.SUCCESS ? 
                OperationResult<bool>.Success(true) : 
                OperationResult<bool>.Failure(_loginService.ConvertLoginResultToMessage(result));
        }
    }
}
