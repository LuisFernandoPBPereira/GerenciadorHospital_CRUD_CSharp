using GerenciadorHospital.Data;
using GerenciadorHospital.Data.ORM;
using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Medico
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly IRepositorioORM<MedicoModel> _ormRepo;
        #region Construtor
        public MedicoRepositorio(BancoContext bancoContext, IRepositorioORM<MedicoModel> ormRepo)
        {
            _bancoContext = bancoContext;
            _ormRepo = ormRepo;
        }
        #endregion

        #region Repositório - Adicionar Médico
        public async Task<MedicoModel> Adicionar(MedicoModel medico)
        {
            await _ormRepo.AddAsync(medico);
            await _ormRepo.SaveChangesAsync();

            return medico;
        }
        #endregion

        #region Repositório - Apagar Médico
        public async Task<bool> Apagar(int id)
        {
            MedicoModel? medicoPorId = await BuscarPorId(id);

            if (medicoPorId == null)
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");

            await _ormRepo.Delete(medicoPorId);
            await _ormRepo.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Médico
        public async Task<MedicoModel> Atualizar(MedicoModel medico, int id)
        {
            MedicoModel? medicoPorId = await BuscarPorId(id);

            if (medicoPorId == null)
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");

            medicoPorId.Nome = medico.Nome;
            medicoPorId.Cpf = medico.Cpf;
            medicoPorId.Crm = medico.Crm;
            medicoPorId.Endereco = medico.Endereco;
            medicoPorId.DataNasc = medico.DataNasc;
            medicoPorId.Senha = medico.Senha;
            medicoPorId.Especializacao = medico.Especializacao;
            medicoPorId.CaminhoDoc = medico.CaminhoDoc;

            await _ormRepo.Update(medicoPorId);
            await _ormRepo.SaveChangesAsync();

            return medicoPorId;
        }

        #endregion

        #region Repositório - Buscar Documento do Médico Por ID
        public async Task<MedicoModel?> BuscarDocMedicoPorId(int id)
        {
            return await _bancoContext.Medicos
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Médico Por ID
        public async Task<MedicoModel?> BuscarPorId(int id)
        {
            return await _bancoContext.Medicos.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Todos Médicos
        public async Task<List<MedicoModel>> BuscarTodosMedicos()
        {
            return await _bancoContext.Medicos.ToListAsync();
        }
        #endregion
    }
}
