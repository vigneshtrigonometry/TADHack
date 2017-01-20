using ECMS_Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Data_Access
{
    public class MeetingRepository
    {
        private ECMSContext context;
        public MeetingRepository()
        {
            context = new ECMSContext();
        }
       public List<Meeting> GetAllMeetingsForUserId(string Username)
        {

            return context.Meetings.Where(u => u.Users.Equals(context.Users.FirstOrDefault(us=>us.UserName==Username))).ToList();
        }

        public Meeting GetMeetingByID(int MeetingId)
        {
            return context.Meetings.First(m => m.MeetingID == MeetingId);
        }
        public void CreateMeeting(List<string> usernames, DateTime time)
        {
            Meeting m = new Meeting { TimeOfMeeting = time };
            foreach(string uname in usernames)
            {
                m.Users.Add(context.Users.FirstOrDefault(u=>u.UserName==uname));
            }
            context.Meetings.Add(m);
            context.SaveChanges();
        }

        public void ModifyMeeting(Meeting m)
        {
            Meeting meet = context.Meetings.FirstOrDefault(me => me.MeetingID == m.MeetingID);
            meet.TimeOfMeeting = m.TimeOfMeeting;
            meet.Users.Clear();
            meet.Users = m.Users;
            context.Entry(meet).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
