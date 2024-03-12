using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class ConvenioRepositorio : IConvenioRepositorio
    {
        //Criamos uma variável de contexto
        private readonly BancoContext _bancoContext;

        //Iniciamos o construtor e injetamos o contexto do banco de dados
        public ConvenioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<ConvenioModel> Adicionar(ConvenioModel convenio)
        {
            //Os dados recebidos são inseridos na tabela Convenios
            await _bancoContext.Convenios.AddAsync(convenio);
            await _bancoContext.SaveChangesAsync();

            return convenio;

        }

        public async Task<bool> Apagar(int id)
        {
            //Pegamos um convênio por Id de forma assíncrona
            ConvenioModel convenioPorId = await BuscarPorId(id);
            if (convenioPorId == null)
            {
                throw new Exception($"Convênio para o ID: {id} não foi encontrado no banco de dados.");
            }
            //Removemos da tabela Convenios e salvamos as alterações
            _bancoContext.Convenios.Remove(convenioPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }

        public async Task<ConvenioModel> Atualizar(ConvenioModel convenio, int id)
        {
            //Pegamos um convênio por Id de forma assíncrona
            ConvenioModel convenioPorId = await BuscarPorId(id);
            if (convenioPorId == null)
            {
                throw new Exception($"Convênio para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Atualizamos os devidos campos
            convenioPorId.Nome = convenio.Nome;
            convenioPorId.Preco = convenio.Preco;
            
            //Atualizamos a tabela Convenios e salvamos as alterações
            _bancoContext.Convenios.Update(convenioPorId);
            await _bancoContext.SaveChangesAsync();

            return convenioPorId;
        }

        public async Task<ConvenioModel> BuscarPorId(int id)
        {
            //Retornamos o primeiro ou o padrão achado pelo id na tabela Convenios
            return await _bancoContext.Convenios.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<ConvenioModel>> BuscarTodosConvenios()
        {
            //Buscamos todos os Convenios
            return await _bancoContext.Convenios.ToListAsync();
        }
    }
}
