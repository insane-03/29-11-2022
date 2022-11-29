
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flopkart_Repository.MongoEntity;

namespace Flopkart_Repository
{
    public class DB_Context
    {
        public IMongoCollection<MongoProducts> ? Products { get; set; }
        public DB_Context(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            Products = database.GetCollection<MongoProducts>("Products");
        }
    }
}
