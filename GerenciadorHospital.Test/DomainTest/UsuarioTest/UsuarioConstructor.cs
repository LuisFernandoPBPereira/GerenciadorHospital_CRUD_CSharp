using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Test.DomainTest.UsuarioTest;

public class UsuarioConstructor
{
    [Fact]
    public void QuandoConstrutorValidoRetornarEntidade()
    {
        int id = 1;
        string nome = "user";
        string senha = "*User123";
        string role = "Admin";

        UsuarioEntity usuarioEntity = new UsuarioEntity(id, nome, senha, role);

        Assert.NotNull(usuarioEntity);
    }
}
