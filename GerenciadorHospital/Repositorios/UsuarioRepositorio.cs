using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel)
        {
            await _bancoContext.Usuarios.AddAsync(usuarioModel);
            await _bancoContext.SaveChangesAsync();

            return usuarioModel;
        }

        //Método Apagar, que aguarda a requisição de busca por ID para poder fazer a deleção
        public async Task<bool> Apagar(int id)
        {
            //Pegamos um paciente pelo ID de forma assíncrona
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Paciente para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Removemos do banco de dados e salvamos as alterações
            _bancoContext.Usuarios.Remove(usuarioPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }

        //Método Atualizar, que aguarda a busca pelo ID para fazer a alteração
        public async Task<UsuarioModel> Atualizar(UsuarioModel paciente, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Paciente para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Fazemos as devidas alterações
            usuarioPorId.Nome = paciente.Nome;
            usuarioPorId.Cpf = paciente.Cpf;
            usuarioPorId.Endereco = paciente.Endereco;
            usuarioPorId.DataNasc = paciente.DataNasc;

            //Atualizamos no banco de dados e salvamos as alterações
            _bancoContext.Usuarios.Update(usuarioPorId);
            await _bancoContext.SaveChangesAsync();

            return usuarioPorId;
        }

        //Método BuscarPorId, que através do ID recebido, faz requisição no banco para mostrar a busca
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            /*
             * Retornamos o primeiro paciente ou o padrão por ID,
             * incluindo os objetos convenio e medicamento
            */
            return await _bancoContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }


        //Método BuscarTodosUsuarios, que lista todos os usuários do banco
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            //Retornamos todos os pacientes com os objetos convenio e medicamento
            return await _bancoContext.Usuarios.ToListAsync();
        }
    }
}
