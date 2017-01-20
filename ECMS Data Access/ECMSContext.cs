using ECMS_Data_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS_Data_Access
{
    public class ECMSContext : DbContext
    {
        public ECMSContext() : base()
        {
            Database.SetInitializer<ECMSContext>(new CreateDatabaseIfNotExists<ECMSContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Conversation> Conversations {get;set;}
        public DbSet<ConversationMessage> ConversationMessages { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

    }
}
