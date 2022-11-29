using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Flopkart_Repository.MongoEntity
{
    public  class MongoProducts
    {
        public ObjectId  id { get; set; }
        public string? ProductName { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
