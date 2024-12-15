using Movies.Models.Models.BaseEntity.Interface;

namespace Movies.Models.Models.BaseEntity;

public class BaseEntity<T> : IBaseEntity<T>
{
    public T Id { get; set; }
}