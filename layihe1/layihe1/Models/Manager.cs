using System;
using System.Collections.Generic;
using System.Text;

namespace layihe1.Models
{
    public class Manager : BaseModel
    {
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Manager()
        {

        }
        public Manager(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
