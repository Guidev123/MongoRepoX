using MongoRepoX.DomainObjects;
using MongoRepoX.Response;

namespace MongoRepoX.Repositories
{
    /// <summary>
    /// Generic repository interface for managing entities with a customizable identifier type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the entity's identifier.</typeparam>
    public interface IRepository<TEntity, TKey> where TEntity : IEntityBase<TKey>
    {
        /// <summary>
        /// Retrieves a paged list of entities based on the specified page number and page size.
        /// </summary>
        /// <param name="pageNumber">The number of the page to retrieve.</param>
        /// <param name="pageSize">The number of entities per page.</param>
        /// <returns>A paged response containing a list of entities or null.</returns>
        Task<PagedResponse<List<TEntity>?>> GetAllAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// Retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity matching the specified identifier, or null if not found.</returns>
        Task<TEntity?> GetByIdAsync(TKey id);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(TKey id, TEntity entity);

        /// <summary>
        /// Removes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to remove.</param>
        void RemoveAsync(TKey id);
    }

}
