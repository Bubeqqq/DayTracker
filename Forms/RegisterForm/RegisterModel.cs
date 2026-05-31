using DayTracker.Common;
using DayTracker.LoginServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.RegisterForm
{
    internal class RegisterModel : IRegisterModel
    {
        private readonly ILoginService _loginService;

        public RegisterModel(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public async Task<OperationResult<bool>> Register(string email, string password, string name, string lastName)
        {
            int result = await _loginService.Register(email, password, name, lastName);
            return result == LoginService.SUCCESS ?
                OperationResult<bool>.Success(true) :
                OperationResult<bool>.Failure(_loginService.ConvertLoginResultToMessage(result));
        }
    }
}