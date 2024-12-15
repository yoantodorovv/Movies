namespace Movies.Models.Models.BaseEntity.Interface;

public interface IBaseEntity<T>
{
    public T Id { get; set; }
}