using PasswordStrengthChecker.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrengthChecker
{
    class NewUserRepository : IRepository
    {
        public IChecker checker { get; set; }
        private readonly DbContext context;

        public NewUserRepository(DbContext context, IChecker checker)
        {
            this.context = context;
            this.checker = checker;
        }

        public string CreateNewUser(string login, string password, bool isAdmin)
        {
            string message;
            if (checker.Verify(login, password, isAdmin, out message))
            {
                int num = CreateUser(login, password, isAdmin);
                return String.Format("User with id {0} has been created", num);
            }
            return message;
        }

        private int CreateUser(string login, string password, bool isAdmin)
        {
            User user = new User() { IsAdmin = isAdmin, Login = login, Password = password };
            user = context.Set<User>().Add(user);
            context.SaveChanges();
            context.Dispose();
            return user.Id;
        }
    }
}
