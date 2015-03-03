using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrengthChecker
{
    interface IChecker
    {
        bool Verify(string login, string pwd, bool isAdmin, out string msg);
    }
}
