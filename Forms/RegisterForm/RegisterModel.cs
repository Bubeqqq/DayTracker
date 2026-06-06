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
        public async Task<OperationResult<bool>> Register(string name, string lastName, string email, string password)
        {
            int result = await _loginService.Register(name, lastName, email, password);
            return result == LoginService.SUCCESS ?
                OperationResult<bool>.Success(true) :
                OperationResult<bool>.Failure(_loginService.ConvertLoginResultToMessage(result));
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