using MessageDashboard.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageDashboard.Service
{
    public interface IDashboardService
    {
        Task<List<Message>> GetMessages();
        Task<Message> CreateMessage(Message message);
    }
}
