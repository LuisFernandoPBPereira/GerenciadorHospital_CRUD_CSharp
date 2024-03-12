using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class TipoExameRepositorio : ITipoExameRepositorio
    {
        //Criamos o contexto do banco de dados
        private readonly BancoContext _bancoContext;
        //Injetamos no construtor
        public TipoExameRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<TipoExameModel> Adicionar(TipoExameModel tipoExame)
        {
            //Salvamos o exame no banco de dados e salvamos as alterações
            await _bancoContext.TiposExames.AddAsync(tipoExame);
            await _bancoContext.SaveChangesAsync();

            return tipoExame;
        }

        public async Task<bool> Apagar(int id)
        {
            //Pegamos o exame pelo ID de fomra assíncrona
            TipoExameModel tipoExamePorId = await BuscarPorId(id);
            if (tipoExamePorId == null)
            {
                throw new Exception($"Tipo de Exame para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Removemos do banco de dados e salvamos as alterações
            _bancoContext.TiposExames.Remove(tipoExamePorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }

        public async Task<TipoExameModel> Atualizar(TipoExameModel tipoExame, int id)
        {
            //Pegamos o exame pelo ID de forma assíncrona
            TipoExameModel tipoExamePorId = await BuscarPorId(id);
            if (tipoExamePorId == null)
            {
                throw new Exception($"Tipo de Exame para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Fazemos as devidas alterações
            tipoExamePorId.Nome = tipoExame.Nome;

            //Atualizamos o banco de dados e salvamos as alterações
            _bancoContext.TiposExames.Update(tipoExamePorId);
            await _bancoContext.SaveChangesAsync();

            return tipoExamePorId;
        }

        public async Task<TipoExameModel> BuscarPorId(int id)
        {
            //Retornamos o primeiro exame ou o padrão pelo ID
            return await _bancoContext.TiposExames.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TipoExameModel>> BuscarTodosExames()
        {
            //Retornamos todos os exames
            return await _bancoContext.TiposExames.ToListAsync();

        }
    }
}
