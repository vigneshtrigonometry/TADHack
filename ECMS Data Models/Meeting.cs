using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Data_Models
{
    public class Meeting
    {
        [Key]
        public int MeetingID { get; set; }
        private List<User> users = new List<User>();
        public virtual List<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
            }
        }
        //public User InitiatedBy { get; set; }
        public DateTime TimeOfMeeting
        {
            get; set;
        }
    }
}
