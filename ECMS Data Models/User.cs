using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Data_Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name ="Username")]
        [Required]
        [Column(TypeName = "VARCHAR")]
        [Index(IsUnique = true)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public long PhoneNumberPrimary { get; set; }
        private List<Meeting> meetings = new List<Meeting>();
        public virtual List<Meeting> Meetings
        {
            get
            {
                return meetings;
            }
            set
            {
                meetings = value;
            }
        }
        //private List<Conversation> conversations = new List<Conversation>();
        public virtual List<Conversation> Conversations
        {
            get;
            set;
        }
        public List<ConversationMessage> Messages { get; set; }
    }
}
