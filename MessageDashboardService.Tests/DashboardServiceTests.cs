using MessageDashboard.Model;
using MessageDashboard.Repositories;
using MessageDashboard.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MessageDashboardService.Tests
{
    public class DashboardServiceTests
    {
        [Fact]
        public async Task Call_GetMessages_ReturnsDbMessages()
        {
            var dbMock = new Mock<MessageContext>();
            var messagesMock = CreateDbSetMock(GetMockMessages());
            dbMock.Setup(x => x.Messages).Returns(messagesMock.Object);

            var dashboardService = new DashboardService(dbMock.Object);

            var messages = await dashboardService.GetMessages();

            Assert.Equal(2, messages.Count);
        }

        private List<Message> GetMockMessages()
        {
            return new List<Message>
            {
                new Message { Id = 1, Content = "a test message" },
                new Message { Id = 2, Content = "another test message" },
            };
        }

        private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }
    }
}
