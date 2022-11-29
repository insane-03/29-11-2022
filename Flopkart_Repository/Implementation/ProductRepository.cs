using Flopkart_Model;
using Flopkart_Repository.Interface;
using Flopkart_Repository.MongoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Flopkart_Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DB_Context _dbContext;
        public ProductRepository(DB_Context dbContext) 
        {
            _dbContext= dbContext;
        }
        
        public List<MongoProducts> GetAllItems()
        {
            return _dbContext.Products.Find(_ => true).ToList() ;
        }

        public MongoProducts GetoneProduct(int ProductId)
        {
            var productData = _dbContext.Products.Find(x => x.ProductId == ProductId).FirstOrDefault();
            return productData;
        }
        public MongoProducts InsertProduct(MongoProducts products)
        {
            _dbContext.Products.InsertOne(products) ;
            return products ;
        }

        public MongoProducts UpdateProduct(MongoProducts products,int ProductId)
        {
            var productData = _dbContext.Products.Find(x => x.ProductId == ProductId).FirstOrDefault();
            productData.ProductId = products.ProductId;
            productData.ProductName = products.ProductName;
            productData.Quantity = products.Quantity;
            _dbContext.Products.ReplaceOne(product => product.ProductId == ProductId, productData);

            return productData;

        }

        public MongoProducts RemoveProduct(int ProductId) 
        {
            var productData = _dbContext.Products.Find(x => x.ProductId == ProductId).FirstOrDefault();
            var result =_dbContext.Products.DeleteOne(product => product.ProductId == ProductId);
            return productData;
        }
    }
}
