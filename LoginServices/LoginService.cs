using DayTracker.Database;
using DayTracker.Database.Datatypes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTracker.LoginServices
{
    internal class LoginService : ILoginService
    {
        private readonly IDatabaseService _databaseService;

        public const int MULTIPLE_USERS = 1, USER_NOT_FOUND = 2, INVALID_PASSWORD = 3, USER_EXISTS = 4, SUCCESS = 5;

        private User? CurrentUser;

        public LoginService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<int> Login(string email, string password)
        {
            List<User> users = await _databaseService.GetUsersAsync(u => u.email == email);

            if (users.Count == 0)
            {
                return USER_NOT_FOUND;
            }

            if(users.Count > 1)
            {
                return MULTIPLE_USERS;
            }

            Console.WriteLine($"Password from database: {users[0].password}");

            if (!BCrypt.Net.BCrypt.Verify(password, users[0].password))
            {
                return INVALID_PASSWORD;
            }

            List<User> newUsers = await _databaseService.GetUsersAsync(u => u.email == email);
            CurrentUser = newUsers[0];
            return SUCCESS;
        }

        public async Task<int> Register(string name, string surname, string email, string password)
        {
            List<User> users = await _databaseService.GetUsersAsync(u => u.email == email);

            if (users.Count > 0)
            {
                return MULTIPLE_USERS;
            }
            
            User r = new User
            {
                FirstName = name,
                LastName = surname,
                email = email,
                password = BCrypt.Net.BCrypt.HashPassword(password)
            };
            await _databaseService.AddUserAsync(r);
            Permission p = new Permission() { UserId = r.Id, PermissionName = PermissionType.Admin };
            await _databaseService.AddAsync(p);

            return SUCCESS;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public string ConvertLoginResultToMessage(int result)
        {
            switch(result)
            {
                case MULTIPLE_USERS:
                    return "Multiple users with the same email found. Please contact support.";
                case USER_NOT_FOUND:
                    return "User not found. Please check your email and try again.";
                case INVALID_PASSWORD:
                    return "Invalid password. Please check your password and try again.";
                case USER_EXISTS:
                    return "User with this email already exists. Please check your email and try again.";
                case SUCCESS:
                    return "Login successful!";
                default:
                    return "An unknown error occurred. Please try again later.";
            }
        }

        public User? GetUser()
        {
            return CurrentUser;
        }
    }
}
