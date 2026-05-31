using DayTracker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.RegisterForm
{
    internal interface IRegisterModel : IModel
    {
        Task<OperationResult<bool>> Register(string email, string password, string name, string lastName);
    }
}
