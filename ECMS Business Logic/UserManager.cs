using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECMS_Data_Access;
using ECMS_Data_Models;

namespace ECMS_Business_Logic
{
    public class UserManager
    {
        private UserRepository UserRepo;
        public UserManager()
        {
            UserRepo = new UserRepository();
        }

        public bool AuthenticateUser(string username, string password)
        {
            try
            {
                User u = UserRepo.GetUserByUsername(username);
                return u.Password == password ? true : false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            
        }

        public void RegisterUser(string username,string password,long phone)
        {
            User u = new User { UserName = username, Password = password, PhoneNumberPrimary = phone };
            UserRepo.CreateUser(u);
        }

        public User GetUserByUsername(string username)
        {
            return UserRepo.GetUserByUsername(username);
        }

        public void UpdateUser(User u)
        {
            UserRepo.UpdateUser(u);
        }
    }
}
