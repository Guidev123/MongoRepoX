using MongoDB.Driver;
using MongoRepoX.DomainObjects;
using MongoRepoX.Response;

namespace MongoRepoX.Repositories
{
    /// <summary>
    /// A generic repository for managing entities in a MongoDB collection with a customizable identifier type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the entity's identifier.</typeparam>
    public class Repository<TEntity, TKey>(IMongoDatabase mongoDatabase, string collectionName)
                   : IRepository<TEntity, TKey> where TEntity : IEntityBase<TKey>
    {
        /// <summary>
        /// MongoDB collection for the specified entity type.
        /// </summary>
        protected readonly IMongoCollection<TEntity> _collection = mongoDatabase.GetCollection<TEntity>(collectionName);

        /// <summary>
        /// Adds a new entity to the MongoDB collection.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public async Task CreateAsync(TEntity entity) => await _collection.InsertOneAsync(entity);

        /// <summary>
        /// Retrieves a paged list of active entities from the MongoDB collection.
        /// </summary>
        /// <param name="pageNumber">The number of the page to retrieve.</param>
        /// <param name="pageSize">The number of entities per page.</param>
        /// <returns>A paged response containing a list of active entities or null.</returns>
        public async Task<PagedResponse<List<TEntity>?>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = await _collection.Find(c => c.IsActive).Skip((pageNumber - 1) * pageSize).Limit(pageSize).ToListAsync();
            var totalCount = query.Count();
            return new PagedResponse<List<TEntity>?>(query, totalCount, pageSize, pageNumber);
        }

        /// <summary>
        /// Retrieves a single active entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The active entity matching the specified identifier, or null if not found.</returns>
        public async Task<TEntity?> GetByIdAsync(TKey id) =>
            await _collection.Find(c => c.Id.Equals(id) && c.IsActive).SingleOrDefaultAsync();

        /// <summary>
        /// Removes an entity from the MongoDB collection by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to remove.</param>
        public void RemoveAsync(TKey id) => _collection.DeleteOne(c => c.Id.Equals(id));

        /// <summary>
        /// Updates an existing entity in the MongoDB collection.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public async Task UpdateAsync(TEntity entity) =>
            await _collection.ReplaceOneAsync(c => c.Id.Equals(entity.Id), entity);
    }
}
