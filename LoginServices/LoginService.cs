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
        private readonly IUsersDatabase _databaseService;

        public const int MULTIPLE_USERS = 1, USER_NOT_FOUND = 2, INVALID_PASSWORD = 3, USER_EXISTS = 4, SUCCESS = 5;

        public LoginService(IUsersDatabase databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<int> Login(string email, string password)
        {
            List<User> users = await _databaseService.ExecuteRawSqlSelectAsync<User>($"SELECT * FROM \"Users\" WHERE \"email\" = '{email}'");

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

            return SUCCESS;
        }

        public async Task<int> Register(string name, string surname, string email, string password) //TODO: zwykła metoda hói, zmień na async
        {
            List<User> users = await _databaseService.ExecuteRawSqlSelectAsync<User>($"SELECT * FROM \"Users\" WHERE \"email\" = '{email}'");
            
            if (users.Count > 0)
            {
                return MULTIPLE_USERS;
            }
            
            
            await _databaseService.ExecuteRawSqlCommandAsync($"INSERT INTO \"Users\" (\"FirstName\", \"LastName\", \"email\", \"password\") VALUES ('{name}', '{surname}', '{email}', '{BCrypt.Net.BCrypt.HashPassword(password)}')");
            return SUCCESS;
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
    }
}
