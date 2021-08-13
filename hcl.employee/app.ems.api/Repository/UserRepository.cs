using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.ems.api.Models;

namespace app.ems.api.Repository
{
    interface IUserRepository
    {
        Login GetUser(string userId);
    }

    public class UserRepository : IUserRepository
    {
        private EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();

        /// <summary>
        /// Get User by Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Login GetUser(string userId)
        {
            var login = db.Logins.FirstOrDefault(x => x.UserId == userId);
            return login;
        }
    }
}
