using ECMS_Business_Logic;
using ECMS_Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            MeetingManager cmgr = new MeetingManager();
            cmgr.CreateMeeting(new List<string> { "vignesh16" }, DateTime.Now);
            //new ECMSContext().Database.Initialize(true);
            //Console.WriteLine(new ECMSContext().ConversationMessages.First().Sender.UserId);
            Console.ReadKey();
        }
    }
}
