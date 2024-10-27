namespace MongoRepoX.DomainObjects
{
    /// <summary>
    /// Base interface for entities with a generic identifier and active status.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's identifier.</typeparam>
    public interface IEntityBase<TKey>
    {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// Indicates whether the entity is active.
        /// </summary>
        bool IsActive { get; set; }
    }

}
