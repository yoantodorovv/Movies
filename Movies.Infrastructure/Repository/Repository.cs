using Movies.Infrastructure.Repository.Interface;

namespace Movies.Infrastructure.Repository;

public class Repository<T> : IRepository<T>
    where T : class
{
    private readonly MovieDbContext _context;
    
    // DI (Dependency Injection)
    public Repository(MovieDbContext context)
    {
        _context = context;
    }

    public void Add(T entity) => _context.Add(entity);
    
    public void AddRange(IEnumerable<T> entities) => _context.AddRange(entities);

    public void Get<TId>(TId id) => _context.Find<T>(id);

    public void GetAll()
    {
        throw new NotImplementedException();
    }

    public void Update<TEntity>(TEntity entity) => _context.Update(entity);

    public void Delete<T1>(T1 entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteById<T1>(T1 id)
    {
        throw new NotImplementedException();
    }
    
    public void SaveChanges() => _context.SaveChanges();
}