using MessageDashboard.Model;
using MessageDashboard.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageDashboard.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly MessageContext _context;

        public DashboardService(MessageContext context)
        {
            _context = context;
        }

        public async Task<Message> CreateMessage(Message message)
        {
            _context.Messages.Add(message);

            await _context.SaveChangesAsync();

            return message;
        }

        public async Task<List<Message>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }
    }
}
