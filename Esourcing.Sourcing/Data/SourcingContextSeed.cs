using Esourcing.Sourcing.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esourcing.Sourcing.Data
{
    public class SourcingContextSeed
    {
       public static void SeedData(IMongoCollection<Auction> auctionCollection)
        {
            bool exist = auctionCollection.Find(p => true).Any();//if there is any item or data in collection
            if (!exist)
            {
                auctionCollection.InsertManyAsync(GetPreconfigurations());
            }
        }

        private static IEnumerable<Auction> GetPreconfigurations()
        {
            return new List<Auction>()
            { 
                new Auction()
                {
                    Name="Auction 1",
                    Description="Auction desc 1",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(10),
                    ProductId="62593be92456586353a4b8d6",
                    IncludedSellers=new List<string>()
                    {
                        "seler1@test.com",
                        "seler2@test.com",
                        "seler3@test.com"
                    },
                    Quantity=1,
                    Status= (int)Status.Active
                },
                new Auction()
                {
                    Name="Auction 2",
                    Description="Auction desc 2",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(10),
                    ProductId="62593be92456586353a4b8d6",
                    IncludedSellers=new List<string>()
                    {
                        "seler1@test.com",
                        "seler2@test.com",
                        "seler3@test.com"
                    },
                    Quantity=2,
                    Status= (int)Status.Active
                },
                new Auction()
                {
                    Name="Auction 3",
                    Description="Auction desc 3",
                    CreatedAt=DateTime.Now,
                    StartedAt=DateTime.Now,
                    FinishedAt=DateTime.Now.AddDays(10),
                    ProductId="62593be92456586353a4b8d6",
                    IncludedSellers=new List<string>()
                    {
                        "seler1@test.com",
                        "seler2@test.com",
                        "seler3@test.com"
                    },
                    Quantity=3,
                    Status= (int)Status.Active
                }
            };
        }
    }
}
