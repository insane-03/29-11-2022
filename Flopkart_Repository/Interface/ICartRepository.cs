using Flopkart_Repository.MongoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flopkart_Repository.Interface
{
    public interface ICartRepository
    {
        public MongoProducts BuyItems(MongoProducts products);
    }
}
