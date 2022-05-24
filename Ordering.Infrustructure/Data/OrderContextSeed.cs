using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrustructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>()
            {
                new Order()
                {
                    AuctionId = Guid.NewGuid().ToString(),
                    ProductId = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    SellerUserName = "test@test.com",
                    UnitPrice = 10,
                    TotalPrice = 1000

                },
                new Order()
                {
                  AuctionId = Guid.NewGuid().ToString(),
                    ProductId = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    SellerUserName = "test2@test.com",
                    UnitPrice = 20,
                    TotalPrice = 2000
                },
                new Order()
                {
                   AuctionId = Guid.NewGuid().ToString(),
                    ProductId = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    SellerUserName = "test3@test.com",
                    UnitPrice = 30,
                    TotalPrice = 3000
                }
            };
            throw new NotImplementedException();
        }
    }
}
