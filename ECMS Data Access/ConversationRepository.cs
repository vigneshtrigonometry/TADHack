using ECMS_Data_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Data_Access
{
    public class ConversationRepository
    {
        private ECMSContext context;
        public ConversationRepository()
        {
            context = new ECMSContext();
        }
        public List<Conversation> GetAllConversationByUserId(int UserID)
        {
            return context.Users.First(c => c.UserId==UserID).Conversations.ToList();
        }
        public Conversation GetConversationByConversationId(int ConvId)
        {
            return context.Conversations.First(c => c.ConversationID == ConvId);
        }
        public void AddMessageToConversation(int conv_id,string msg,string username)
        {
            ConversationMessage cmsg = new ConversationMessage { Message = msg, Conversation= context.Conversations.FirstOrDefault(cc=>cc.ConversationID==conv_id), TimeSent = DateTime.Now, Sender = context.Users.First(un=>un.UserName==username) };

            //msg.Conversation = context.Conversations.FirstOrDefault(c => c.ConversationID == conv_id);
            context.ConversationMessages.Add(cmsg);
            //context.Conversations.Single(c => c.ConversationID == conv_id).Messages.Add(msg);
            context.SaveChanges();
        }
        public List<ConversationMessage> GetAllMessagesForConvId(int ConvId)
        {
            return context.ConversationMessages.Where(c => c.Conversation.ConversationID == ConvId).ToList();
        }
        public void CreateConversation(List<string> usernames, string title)
        {
            Conversation c = new Conversation { ConversationTitle = title };
            foreach (string uname in usernames)
            {
                User u = context.Users.FirstOrDefault(us => us.UserName == uname);
                u.Conversations.Add(c);
                context.Entry(u).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void UpdateConversation(int convid, string title, List<string> usernames)
        {
            Conversation c = context.Conversations.FirstOrDefault(co => co.ConversationID == convid);
            c.ConversationTitle = title;
            c.Users.Clear();
            context.SaveChanges();
            foreach (string uname in usernames)
            {
                User u = context.Users.FirstOrDefault(un => un.UserName == uname);
                c.Users.Add(u);
            }
            context.Entry(c).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
