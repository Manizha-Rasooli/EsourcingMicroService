using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Repositories;
using Ordering.Domain.Repositories.Base;
using Ordering.Infrustructure.Data;
using Ordering.Infrustructure.Repositories;
using Ordering.Infrustructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrustructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
                                                         ServiceLifetime.Singleton,
                                                         ServiceLifetime.Singleton);
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();
            
            return services; 
            
        }
    }
}
 