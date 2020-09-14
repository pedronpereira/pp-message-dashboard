using MessageDashboard.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DashboardHost.AppComposition
{
    public static class DashboardServiceRepositoriesComposition
    {
        public static IServiceCollection AddMessagesRepository(this IServiceCollection services)
        {
            services.AddDbContext<MessageContext>(opt =>
                opt.UseInMemoryDatabase("DashboardMessages"));

            return services;
        }
    }
}
