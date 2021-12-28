using Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.BaseRepositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoCollection<TEntity> collection;

        protected BaseRepository(ISchoolDatabaseSettings databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            collection = mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task Create(TEntity entity)
        {
            await this.collection.InsertOneAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> FindAll()
        {
            return await this.collection.Find(_ => true).ToListAsync();
        }

        public async Task Update(string id, TEntity entity)
        {
            await this.collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", id), entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
