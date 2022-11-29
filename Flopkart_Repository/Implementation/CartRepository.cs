using Flopkart_Repository.Interface;
using Flopkart_Repository.MongoEntity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flopkart_Repository.Implementation
{
    public class CartRepository : ICartRepository
    {
        private readonly DB_Context _dbContext;

        public CartRepository(DB_Context dbContext)
        {
            _dbContext = dbContext;
        }

        public MongoProducts BuyItems(MongoProducts products)
        {
            var id = products.ProductId;
            
            var productData = _dbContext.Products.Find(x => x.ProductId == id && x.ProductName == products.ProductName).FirstOrDefault();
            if (productData != null)
            {
                productData.Quantity = (productData.Quantity - products.Quantity);
                _dbContext.Products.ReplaceOne(product => product.ProductId == products.ProductId, productData);
                return productData;
            }

            return products;

            
        }
    }
}
