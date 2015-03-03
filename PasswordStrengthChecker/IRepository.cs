using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrengthChecker
{
    interface IRepository
    {
        string CreateNewUser(string login, string password, bool isAdmin);
    }
}
