using ECMS_Data_Access;
using ECMS_Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Business_Logic
{
    public class MeetingManager
    {
        private MeetingRepository MeetRepo;
        public MeetingManager()
        {
            MeetRepo = new MeetingRepository();
        }

        public List<Meeting> GetAllMeetingsForUser(string username)
        {
            return MeetRepo.GetAllMeetingsForUserId(username);
        }

        public Meeting GetMeetingById(int meeting_id)
        {
            return MeetRepo.GetMeetingByID(meeting_id);
        }
        public void CreateMeeting(List<string> usernames, DateTime time)
        {
            MeetRepo.CreateMeeting(usernames, time);
        }
    }
}
