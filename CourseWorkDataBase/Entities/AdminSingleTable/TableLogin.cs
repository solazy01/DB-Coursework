using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AdminSingleTable
{
   public class TableLogin
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Vacant { get; private set; }


        public TableLogin(string login, string password, string vacant)
        {
            Login = login;
            Password = password;
            Vacant = vacant;
        }

        public TableLogin()
        {

        }
    }
}
