using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        //Criamos uma variável de contexto
        private readonly BancoContext _bancoContext;
        //Injetamos o contexto no construtor
        public PacienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        //Método Adicionar, que aguarda o recebimento do paciente para salvar no banco
        public async Task<PacienteModel> Adicionar(PacienteModel paciente)
        {
            await _bancoContext.Pacientes.AddAsync(paciente);
            await _bancoContext.SaveChangesAsync();

            return paciente;
        }

        //Método Apagar, que aguarda a requisição de busca por ID para poder fazer a deleção
        public async Task<bool> Apagar(int id)
        {
            //Pegamos um paciente pelo ID de forma assíncrona
            PacienteModel pacientePorId = await BuscarPorId(id);
            if (pacientePorId == null)
            {
                throw new Exception($"Paciente para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Removemos do banco de dados e salvamos as alterações
            _bancoContext.Pacientes.Remove(pacientePorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }

        //Método Atualizar, que aguarda a busca pelo ID para fazer a alteração
        public async Task<PacienteModel> Atualizar(PacienteModel paciente, int id)
        {
            PacienteModel pacientePorId = await BuscarPorId(id);
            if (pacientePorId == null)
            {
                throw new Exception($"Paciente para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Fazemos as devidas alterações
            pacientePorId.Nome = paciente.Nome;
            pacientePorId.Cpf = paciente.Cpf;
            pacientePorId.Endereco = paciente.Endereco;
            pacientePorId.DataNasc = paciente.DataNasc;
            pacientePorId.TemConvenio = paciente.TemConvenio;
            pacientePorId.ExameId = paciente.ExameId;
            pacientePorId.MedicamentoId = paciente.MedicamentoId;
            pacientePorId.ConvenioId = paciente.ConvenioId;
            pacientePorId.ImgCarteiraDoConvenio = paciente.ImgCarteiraDoConvenio;
            pacientePorId.ImgDocumento = paciente.ImgDocumento;

            //Atualizamos no banco de dados e salvamos as alterações
            _bancoContext.Pacientes.Update(pacientePorId);
            await _bancoContext.SaveChangesAsync();

            return pacientePorId;
        }

        //Método BuscarPorId, que através do ID recebido, faz requisição no banco para mostrar a busca
        public async Task<PacienteModel> BuscarPorId(int id)
        {
            /*
             * Retornamos o primeiro paciente ou o padrão por ID,
             * incluindo os objetos convenio e medicamento
            */
            return await _bancoContext.Pacientes
                .Include(x => x.Convenio)
                .Include(x => x.Medicamento)
                .Include(x => x.Exame)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        //Método BuscarTodosUsuarios, que lista todos os usuários do banco
        public async Task<List<PacienteModel>> BuscarTodosPacientes()
        {
            //Retornamos todos os pacientes com os objetos convenio e medicamento
            return await _bancoContext.Pacientes
                .Include(x => x.Convenio)
                .Include(x => x.Medicamento)
                .Include(x => x.Exame)
                .ToListAsync();
        }
    }
}
