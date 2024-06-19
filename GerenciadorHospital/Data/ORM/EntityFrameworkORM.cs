
namespace GerenciadorHospital.Data.ORM;

public class EntityFrameworkORM<T> : IRepositorioORM<T>
{
    private readonly BancoContext _bancoContext;
    public EntityFrameworkORM(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    public async Task AddAsync(T entity)
    {
        await _bancoContext.AddAsync(entity);
    }

    public async Task Delete(T entity)
    {
        _bancoContext.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _bancoContext.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _bancoContext.Update(entity);
    }
}
