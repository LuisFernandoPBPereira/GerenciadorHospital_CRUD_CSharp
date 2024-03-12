using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        //Criamos o contexto do banco de dados
        private readonly BancoContext _bancoContext;

        //Injetamos o contexto no construtor
        public MedicoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<MedicoModel> Adicionar(MedicoModel medico)
        {
            //Adicionamos o médico na tabela Medicos e salvamos as alterações
            await _bancoContext.Medicos.AddAsync(medico);
            await _bancoContext.SaveChangesAsync();

            return medico;
        }

        public async Task<bool> Apagar(int id)
        {
            //Pegamos um médico por id de forma assíncrona
            MedicoModel medicoPorId = await BuscarPorId(id);
            if (medicoPorId == null)
            {
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Removemos do banco de dados e salvamos as alterações
            _bancoContext.Medicos.Remove(medicoPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }

        public async Task<MedicoModel> Atualizar(MedicoModel medico, int id)
        {
            //Pegamos um médico por id de forma assíncrona
            MedicoModel medicoPorId = await BuscarPorId(id);
            if (medicoPorId == null)
            {
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Atualizamos os devidos campos
            medicoPorId.Nome = medico.Nome;
            medicoPorId.Cpf = medico.Cpf;

            //Atualizamos o banco de dados e salvamos as alterações
            _bancoContext.Medicos.Update(medicoPorId);
            await _bancoContext.SaveChangesAsync();

            return medicoPorId;
        }

        public async Task<MedicoModel> BuscarPorId(int id)
        {
            //Retornamos o primeiro médico ou o padrão por ID
            return await _bancoContext.Medicos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MedicoModel>> BuscarTodosMedicos()
        {
            //Retornamos todos os médicos
            return await _bancoContext.Medicos.ToListAsync();
        }
    }
}
