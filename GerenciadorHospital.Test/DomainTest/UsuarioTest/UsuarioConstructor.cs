using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Exceptions;

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

    [Fact]
    public void QuandoConstrutorInvalidoLancarExcecao()
    {
        int id = 1;
        string? nome = null;
        string? senha = null;
        string? role = null;

        Assert.Throws<DomainException>(() => { UsuarioEntity usuarioEntity = new UsuarioEntity(id, nome, senha, role); });
    }
    
    [Fact]
    public void QuandoNomeInvalidoRetornarExcecaoComMensagem()
    {
        int id = 1;
        string? nome = null;
        string? senha = "*Teste123";
        string? role = "Admin";

        string mensagem = "Nome inválido";

        var exception = Assert.Throws<DomainException>(() => { UsuarioEntity usuarioEntity = new UsuarioEntity(id, nome, senha, role); });
        Assert.Contains(mensagem, exception.Mensagem);
    }
    
    [Fact]
    public void QuandoSenhaInvalidaRetornarExcecaoComMensagem()
    {
        int id = 1;
        string? nome = "nome";
        string? senha = null;
        string? role = "Admin";

        string mensagem = "A senha deve conter no mínimo 6 caracteres, no mínimo 1 letra maiúscula, no mínimo 1 número e no mínimo 1 caractere especial";

        var exception = Assert.Throws<DomainException>(() => { UsuarioEntity usuarioEntity = new UsuarioEntity(id, nome, senha, role); });
        Assert.Contains(mensagem, exception.Mensagem);
    }
    
    [Fact]
    public void QuandoRoleInvalidaRetornarExcecaoComMensagem()
    {
        int id = 1;
        string? nome = "nome";
        string? senha = "*Teste123";
        string? role = null;

        string mensagem = "Role inválido";

        var exception = Assert.Throws<DomainException>(() => { UsuarioEntity usuarioEntity = new UsuarioEntity(id, nome, senha, role); });
        Assert.Contains(mensagem, exception.Mensagem);
    }
    
    [Fact]
    public void QuandoIdInvalidoRetornarExcecaoComMensagem()
    {
        int id = 0;
        string? nome = "nome";
        string? senha = "*Teste123";
        string? role = "Admin";

        string mensagem = "Id inválido";

        var exception = Assert.Throws<DomainException>(() => { UsuarioEntity usuarioEntity = new UsuarioEntity(id, nome, senha, role); });
        Assert.Contains(mensagem, exception.Mensagem);
    }
}
