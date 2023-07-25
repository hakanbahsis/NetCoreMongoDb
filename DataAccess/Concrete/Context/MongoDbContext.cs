using DataAccess.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoSettings> setting)
        {
            var client=new MongoClient(setting.Value.ConnectionString);
            _database = client.GetDatabase(setting.Value.Database);
        }


        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name.Trim());
        }

        public IMongoDatabase GetDatabase() { return _database; }

    }
}
