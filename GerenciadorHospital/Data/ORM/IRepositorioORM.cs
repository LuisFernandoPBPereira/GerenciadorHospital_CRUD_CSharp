namespace GerenciadorHospital.Data.ORM;

public interface IRepositorioORM<T>
{
    Task AddAsync(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task SaveChangesAsync();
}
