namespace GerenciadorHospital.Data.ORM;

public interface IRepositorioORM<T>
{
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
