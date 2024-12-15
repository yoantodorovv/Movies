namespace Movies.Infrastructure.Repository.Interface;

public interface IRepository<T>
    where T : class
{
    //CRUD------------------------------------------------
    
    // Create
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);

    // Read
    void Get<TId>(TId id);
    void GetAll();

    // Update
    void Update<TEntity>(TEntity entity);

    // Delete
    void Delete<T>(T entity);
    void DeleteById<T>(T id);
    
    //-----------------------------------------------------
    
    void SaveChanges();
}