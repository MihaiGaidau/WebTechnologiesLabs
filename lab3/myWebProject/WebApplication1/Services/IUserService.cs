using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string username, string password, out User User);
        Task<bool> AddUser(string username, string password);
    }

    public class User
    {
        public string Username { get; }

        public User(string username)
        {
            Username = username;
        }
    }
}
