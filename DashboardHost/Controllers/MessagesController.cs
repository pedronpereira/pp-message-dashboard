using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageDashboard.Model;
using MessageDashboard.Service;

namespace DashboardHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public MessagesController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // GET: api/Messages
        [HttpGet]
        [Route("", Name = "GetMessages")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _dashboardService.GetMessages();
        }

        // POST: api/Messages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("", Name = "GetMessage")]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            var createdMessage = await _dashboardService.CreateMessage(message);
            
            return CreatedAtAction("GetMessages", new { id = createdMessage.Id }, createdMessage);
        }
    }
}
