using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalMonitoring.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User() { }

        public User(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }
        public User(int id,string login, string password, string email)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
