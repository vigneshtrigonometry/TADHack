using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Data_Models
{
    public class Conversation
    {
        [Key]
        public int ConversationID { get; set; }
        private List<ConversationMessage> messages = new List<ConversationMessage>();
        public virtual List<ConversationMessage> Messages
        {
            get
            {
                return messages;
            }
            set
            {
                messages = value;
            }
        }
        //private User user = new User();
        [Required]
        public virtual List<User> Users
        {
            get;
            set;
        }
        [Required]
        public string ConversationTitle { get; set; }
    }
}
