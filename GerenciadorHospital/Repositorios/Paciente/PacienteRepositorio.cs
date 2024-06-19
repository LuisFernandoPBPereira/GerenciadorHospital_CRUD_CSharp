using GerenciadorHospital.Data;
using GerenciadorHospital.Data.ORM;
using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Paciente
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly IRepositorioORM<PacienteModel> _ormRepo;
        #region Construtor
        public PacienteRepositorio(BancoContext bancoContext, IRepositorioORM<PacienteModel> ormRepo)
        {
            _bancoContext = bancoContext;
            _ormRepo = ormRepo;
        }
        #endregion

        #region Repositório - Adicionar Paciente
        public async Task<PacienteModel> Adicionar(PacienteModel paciente)
        {
            await _ormRepo.AddAsync(paciente);
            await _ormRepo.SaveChangesAsync();

            return paciente;
        }
        #endregion

        #region Repositório - Apagar Paciente
        public async Task<bool> Apagar(int id)
        {
            PacienteModel? pacientePorId = await BuscarPorId(id);

            if (pacientePorId == null)
                throw new Exception($"Paciente para o ID: {id} não foi encontrado no banco de dados.");

            _ormRepo.Delete(pacientePorId);
            await _ormRepo.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Paciente
        public async Task<PacienteModel> Atualizar(PacienteModel paciente, int id)
        {
            PacienteModel? pacientePorId = await BuscarPorId(id);

            if (pacientePorId == null)
                throw new Exception($"Paciente para o ID: {id} não foi encontrado no banco de dados.");

            pacientePorId.Nome = paciente.Nome;
            pacientePorId.Cpf = paciente.Cpf;
            pacientePorId.Endereco = paciente.Endereco;
            pacientePorId.DataNasc = paciente.DataNasc;
            pacientePorId.TemConvenio = paciente.TemConvenio;
            pacientePorId.ConvenioId = paciente.ConvenioId;
            pacientePorId.ImgDocumento = paciente.ImgDocumento;
            pacientePorId.ImgCarteiraDoConvenio = paciente.ImgCarteiraDoConvenio;

            _ormRepo.Update(pacientePorId);
            await _ormRepo.SaveChangesAsync();

            return pacientePorId;
        }
        #endregion

        #region Repositório - Buscar Paciente Por ID
        public async Task<PacienteModel?> BuscarPorId(int id)
        {
            return await _bancoContext.Pacientes
                .Include(x => x.Convenio)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Documento do Convênio Por ID
        public async Task<PacienteModel?> BuscarDocConvenioPorId(int id)
        {
            return await _bancoContext.Pacientes
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Documento do Paciente Por ID
        public async Task<PacienteModel?> BuscarDocPorId(int id)
        {
            return await _bancoContext.Pacientes
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Todos Pacientes
        public async Task<List<PacienteModel>> BuscarTodosPacientes()
        {
            return await _bancoContext.Pacientes
                .Include(x => x.Convenio)
                .ToListAsync();
        }
        #endregion
    }
}
