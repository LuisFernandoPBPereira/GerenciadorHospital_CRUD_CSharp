using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Utils;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Laudo
{
    public class LaudoRepositorio : ILaudoRepositorio
    {
        private readonly BancoContext _bancoContext;
        #region Construtor
        public LaudoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        #endregion

        #region Repositório - Adicionar Laudo
        public async Task<LaudoModel> Adicionar(LaudoModel laudo)
        {
            laudo.DataCriacao = DateTime.Now;
            await _bancoContext.Laudos.AddAsync(laudo);
            await _bancoContext.SaveChangesAsync();

            return laudo;
        }
        #endregion

        #region Repositório - Apagar Laudo
        public async Task<bool> Apagar(int id)
        {
            LaudoModel? laudoPorId = await BuscarPorId(id);

            if (laudoPorId == null)
                throw new Exception($"Laudo para o ID: {id} não foi encontrado no banco de dados.");

            _bancoContext.Laudos.Remove(laudoPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Laudo
        public async Task<LaudoModel> Atualizar(LaudoModel laudo, int id)
        {
            LaudoModel? laudoPorId = await BuscarPorId(id);

            if (laudoPorId == null)
                throw new Exception($"Laudo para o ID: {id} não foi encontrado no banco de dados.");

            laudoPorId.Descricao = laudo.Descricao;
            laudoPorId.PacienteId = laudo.PacienteId;
            laudoPorId.MedicoId = laudo.MedicoId;
            laudoPorId.MedicamentoId = laudo.MedicamentoId;
            laudoPorId.CaminhoImagemLaudo = laudo.CaminhoImagemLaudo;

            _bancoContext.Laudos.Update(laudoPorId);
            await _bancoContext.SaveChangesAsync();

            return laudoPorId;
        }

        #endregion

        #region Repositório - Buscar Laudo com Filtro
        public async Task<List<LaudoModel>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId)
        {
            var dataInicialConvertida = DateTime.Now;
            var dataFinalConvertida = DateTime.Now;

            var query = _bancoContext.Laudos.Where(x => x.PacienteId == pacienteId && x.MedicoId == medicoId);

            if (medicoId == 0) query = query.Where(x => x.PacienteId == pacienteId);
            if (pacienteId == 0) query = query.Where(x => x.MedicoId == medicoId);
            if (medicoId == 0 && pacienteId == 0) query = _bancoContext.Laudos;

            if (dataInicial != string.Empty && dataInicial != null && dataFinal != null)
            {
                dataInicialConvertida = DateTime.Parse(dataInicial);
                dataFinalConvertida = DateTime.Parse(dataFinal);
                query = query.Where(x => x.DataCriacao > dataInicialConvertida && x.DataCriacao < dataFinalConvertida);

            }
            return await query
                //.Include(x => x.Paciente)
                //.Include(x => x.Medico)
                .Include(x => x.Medicamento)
                .ToListAsync();
        }
        #endregion

        #region Repositório - Buscar Laudo Por ID
        public async Task<LaudoModel?> BuscarPorId(int id)
        {
            return await _bancoContext.Laudos
                //.Include(x => x.Paciente)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Todos Laudos
        public async Task<List<LaudoModel>> BuscarTodosLaudos()
        {
            return await _bancoContext.Laudos
                //.Include(x => x.Paciente)
                .ToListAsync();
        }
        #endregion

        #region Repositório - Buscar Imagem do Laudo Por ID
        public async Task<LaudoModel?> BuscarImagemLaudoPorId(int id)
        {
            return await _bancoContext.Laudos
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion
    }
}
