using Flopkart_Repository.MongoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flopkart_Repository.Interface
{
    public interface IProductRepository
    {
        public List<MongoProducts> GetAllItems();

        public MongoProducts InsertProduct(MongoProducts products);

        public MongoProducts RemoveProduct(int ProductId);

        public MongoProducts GetoneProduct(int ProductId);

        public MongoProducts UpdateProduct(MongoProducts products, int ProductId);

    }
}
