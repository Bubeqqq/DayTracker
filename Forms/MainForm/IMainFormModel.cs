using DayTracker.Database.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.Forms.MainForm
{
    internal interface IMainFormModel : IModel
    {
        void Logout();
        public void Exit();

        Task ClearList();
        Task ResetCalendar();
        void ChangeBarVisibility(bool visible);
        Task ChangePermission(string email, string role, string old);
        Task AddUser(string email, string role);
        Task RemoveUser(string email);

        event Action OnAppExitRequest;

        Task<List<SimplePermission>> GetPermissionsList();
        string GetInvitationCode();

        bool IsCurrentUserAdmin();
    }
}
