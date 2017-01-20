using ECMS_Data_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Data_Access
{
    public class UserRepository
    {
        private ECMSContext context;

        public UserRepository()
        {
            context = new ECMSContext();
            
        }
        public User GetUserById(int userid)
        {
            return context.Users.FirstOrDefault(u => u.UserId == userid);
        }
        public User GetUserByUsername(string username)
        {
            return context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public void CreateUser(User u)
        {
            context.Database.Initialize(true);
            context.Users.Add(u);
            context.SaveChanges();
        }

        public void UpdateUser(User u)
        {
            context.Entry(u).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
