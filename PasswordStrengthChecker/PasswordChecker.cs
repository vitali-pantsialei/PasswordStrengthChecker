using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrengthChecker
{
    public class PasswordChecker : IChecker
    {
        private char[] SPECIAL_SYMBOLS = {'{', '}', '#', ',', '!', '_', '@', '^', '(', 
                                               ')', ':', '.', '|', '$', '[', ']', ';', '?',
                                               '=', '+', '-', '*', '~', '%' };

        public bool Verify(string login, string pwd, bool isAdmin, out string msg)
        {
            msg = "OK";
            if (login == null)
            {
                msg = "Login is null";
                return false;
            }
            else if (pwd == null)
            {
                msg = "Password is null";
                return false;
            }
            else if (pwd.Length <= 7)
            {
                msg = "Password length should be more than 7 chars";
                return false;
            }
            else if (!pwd.Any(ch => Char.IsLetter(ch)))
            {
                msg = "Password should contain at least 1 letter";
                return false;
            }
            else if (!pwd.Any(ch => Char.IsDigit(ch)))
            {
                msg = "Password should contain at least 1 digit";
                return false;
            }
            else if (isAdmin)
            {
                if (pwd.Length <= 10)
                {
                    msg = "Password should be more  than 10 chars for admins";
                    return false;
                }
                else if (!pwd.Any(ch => SPECIAL_SYMBOLS.Contains(ch)))
                {
                    msg = "Password should contain at least one special character";
                    return false;
                }
            }
            return true;
        }
    }
}
