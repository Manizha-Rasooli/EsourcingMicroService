using ESourcing.Products.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Products.Data
{
    public class ProductContextSeed
    {
        public static void DataSeed(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfihureProducts());
            }
        }

        private static IEnumerable<Product> GetConfihureProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name="Samsung",
                    Summary="asdfadkfsadsfjkdsfjs",
                    Description="adddddddddddddddfffffffffffffffffeeeee",
                    ImageFile="test.png",
                    Price=860.6M,
                    Category="Smart Phone"

                },
                new Product()
                    {
                        Name="Iphone X",
                        Summary="asdfadkfsadsfjkdsfjs",
                        Description="adddddddddddddddfffffffffffffffffeeeee",
                        ImageFile="test.png",
                        Price=960.6M,
                        Category="Smart Phone"

                    },
                new Product()
                    {
                        Name="Huawei Plus",
                        Summary="asdfadkfsadsfjkdsfjs",
                        Description="adddddddddddddddfffffffffffffffffeeeee",
                        ImageFile="test.png",
                        Price=960.6M,
                        Category="Smart Phone"

                    },
            };
        }
    }
}
