using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Infraestructure.Repository;

public class UsuarioRepository : IUsuario
{
    public Task<UsuarioEntity> Adicionar(UsuarioEntity usuario)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioEntity> Atualizar(UsuarioEntity usuario)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioEntity> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
}
