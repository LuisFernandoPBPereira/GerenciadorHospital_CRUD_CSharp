using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Domain.Repository;

public interface IUsuario
{
    Task<UsuarioEntity> BuscarPorId(int id);
    Task<UsuarioEntity> Adicionar(UsuarioEntity usuario);
    Task<UsuarioEntity> Atualizar(UsuarioEntity usuario);
    Task<bool> Apagar(int id);
}
