using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Data_Models
{
    public class ConversationMessage
    {
        [Key]
        public int ConversationMessageID { get; set; }
        public string Message { get; set; }
        [Required]
        public DateTime TimeSent { get; set; }
        private Conversation conversation;
        [Required]
        public virtual Conversation Conversation
        {
            get
            {
                return conversation;
            }
            set
            {
                conversation = value;
            }
        }
        [Required]
        public virtual User Sender { get; set; }
    }
}
