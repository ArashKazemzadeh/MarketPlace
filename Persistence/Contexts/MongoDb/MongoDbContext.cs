using Application.Interfaces.Contexts;
using MongoDB.Driver;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Contexts.MongoContext
{
    public class MongoDbContext<T> : IMongoDbContext<T>
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<T> mongoCollection;
        private readonly ILogger logger;

        public MongoDbContext()
        {
            var client = new MongoClient();
            db = client.GetDatabase("VisitorDb");
            mongoCollection = db.GetCollection<T>(typeof(T).Name);
            logger = Log.Logger;
        }

        public IMongoCollection<T> GetCollection()
        {
            return mongoCollection;
        }

       
    }
}
