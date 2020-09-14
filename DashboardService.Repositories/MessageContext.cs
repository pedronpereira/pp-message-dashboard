using MessageDashboard.Model;
using Microsoft.EntityFrameworkCore;

namespace MessageDashboard.Repositories
{
    public class MessageContext : DbContext
    {
        public MessageContext()
        {
        }

        public MessageContext(DbContextOptions<MessageContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}
