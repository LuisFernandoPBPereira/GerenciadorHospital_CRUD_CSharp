using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public MedicoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<MedicoModel> Adicionar(MedicoModel medico)
        {
            await _bancoContext.Medicos.AddAsync(medico);
            await _bancoContext.SaveChangesAsync();

            return medico;
        }

        public async Task<bool> Apagar(int id)
        {
            MedicoModel medicoPorId = await BuscarPorId(id);
            if (medicoPorId == null)
            {
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");
            }

            _bancoContext.Medicos.Remove(medicoPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }

        public async Task<MedicoModel> Atualizar(MedicoModel medico, int id)
        {
            MedicoModel medicoPorId = await BuscarPorId(id);
            if (medicoPorId == null)
            {
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");
            }

            medicoPorId.Nome = medico.Nome;
            medicoPorId.Cpf = medico.Cpf;

            _bancoContext.Medicos.Update(medicoPorId);
            await _bancoContext.SaveChangesAsync();

            return medicoPorId;
        }

        public async Task<MedicoModel> BuscarPorId(int id)
        {
            return await _bancoContext.Medicos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MedicoModel>> BuscarTodosMedicos()
        {
            return await _bancoContext.Medicos.ToListAsync();
        }
    }
}
