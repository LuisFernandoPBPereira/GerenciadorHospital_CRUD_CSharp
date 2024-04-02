using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class LaudoRepositorio : ILaudoRepositorio
    {
        //Criamos a variável de contexto do banco de dados
        private readonly BancoContext _bancoContext;
        //Injetamos o contexto no construtor
        public LaudoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<LaudoModel> Adicionar(LaudoModel laudo)
        {
            //Adicionamos na tabela Laudos e salvamos as alterações
            await _bancoContext.Laudos.AddAsync(laudo);
            await _bancoContext.SaveChangesAsync();

            return laudo;
        }

        public async Task<bool> Apagar(int id)
        {
            //Pegamos um laudo por ID de forma assíncrona
            LaudoModel laudoPorId = await BuscarPorId(id);
            if (laudoPorId == null)
            {
                throw new Exception($"Laudo para o ID: {id} não foi encontrado no banco de dados.");
            }
            //Removemos do banco de dados e salvamos as alterações
            _bancoContext.Laudos.Remove(laudoPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }

        public async Task<LaudoModel> Atualizar(LaudoModel laudo, int id)
        {
            //Pegamos um laudo por ID de forma assíncrona
            LaudoModel laudoPorId = await BuscarPorId(id);
            if (laudoPorId == null)
            {
                throw new Exception($"Laudo para o ID: {id} não foi encontrado no banco de dados.");
            }
            //Fazemos as devidas alterações
            laudoPorId.Descricao = laudo.Descricao;
            laudoPorId.PacienteId = laudo.PacienteId;
            laudoPorId.MedicoId = laudo.MedicoId;
            laudoPorId.MedicamentoId = laudo.MedicamentoId;

            //Atualizamos no banco de dados e salvamos as alterações
            _bancoContext.Laudos.Update(laudoPorId);
            await _bancoContext.SaveChangesAsync();

            return laudoPorId;
        }

        public async Task<LaudoModel> BuscarPorId(int id)
        {
            /*
             * Retornamos o primeiro laudo ou o padrão, incluindo
             * o objeto paciente, pois laudo e paciente estão relacionados
            */
            return await _bancoContext.Laudos
                .Include(x => x.Paciente)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LaudoModel>> BuscarTodosLaudos()
        {
            //Retornamos todos os laudos incluindo o objeto paciente
            return await _bancoContext.Laudos
                .Include(x => x.Paciente)
                .ToListAsync();
        }
    }
}
