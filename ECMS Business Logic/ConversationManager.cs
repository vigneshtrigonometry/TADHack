using ECMS_Data_Access;
using ECMS_Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Business_Logic
{
    public class ConversationManager
    {
        private ConversationRepository ConvRepo = new ConversationRepository();

        public List<Conversation> GetAllConversationsForUsername(string username)
        {
            User user = new UserRepository().GetUserByUsername(username);
            if(user!=null)
            {
                return ConvRepo.GetAllConversationByUserId(user.UserId);
            }
            else
            {
                return null;
            }
        }

        public void CreateNewConversation(List<String> usernames, string title)
        {
            
            ConvRepo.CreateConversation(usernames, title);
        }
        public void AddMessage(int conv_id,string msg,string username)
        {
             ConvRepo.AddMessageToConversation(conv_id,msg,username);
        }
        public void UpdateConversation(int convid, string title, List<string> usernames)
        {
            ConvRepo.UpdateConversation(convid, title, usernames);
        }
    }
}
