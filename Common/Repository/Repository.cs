using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Common.Repository
{
    
    public class Repository<T> : IRepository<T> where T : Document
    {
        private readonly IMongoCollection<T> _mongoCollection;
        
        public Repository(IMongoClient client, MongoSettings mongoSettings)
        {
            var collectionName = typeof(T).Name;
            collectionName = collectionName[0].ToString().ToLowerInvariant() + collectionName[1..];
            _mongoCollection = client.GetDatabase(mongoSettings.DatabaseName).GetCollection<T>(collectionName);
        }

        public async Task<T> CreateAsync(T document)
        {
            document.CreatedAt = DateTime.UtcNow;
            document.UpdatedAt = DateTime.UtcNow;

            await _mongoCollection.InsertOneAsync(document);
            return document;

        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _mongoCollection.AsQueryable().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _mongoCollection.AsQueryable().ToListAsync();
        }
    }
}