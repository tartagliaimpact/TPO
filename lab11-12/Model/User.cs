using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1112.Model
{
    public class User
    {
        public string userlogin;
        public string password;

        public User(string userlogin, string password) 
        {
            this.userlogin = userlogin;
            this.password = password;
        }

    }
}
