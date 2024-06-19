using GerenciadorHospital.Data;
using GerenciadorHospital.Data.ORM;
using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Models;
using GerenciadorHospital.Utils;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Laudo
{
    public class LaudoRepositorio : ILaudoRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly IRepositorioORM<LaudoModel> _ormRepo;
        #region Construtor
        public LaudoRepositorio(BancoContext bancoContext, IRepositorioORM<LaudoModel> ormRepo)
        {
            _bancoContext = bancoContext;
            _ormRepo = ormRepo;
        }
        #endregion

        #region Repositório - Adicionar Laudo
        public async Task<LaudoModel> Adicionar(LaudoModel laudo)
        {
            laudo.DataCriacao = DateTime.Now;
            await _ormRepo.AddAsync(laudo);
            await _ormRepo.SaveChangesAsync();

            return laudo;
        }
        #endregion

        #region Repositório - Apagar Laudo
        public async Task<bool> Apagar(int id)
        {
            LaudoModel? laudoPorId = await BuscarPorId(id);

            if (laudoPorId == null)
                throw new Exception($"Laudo para o ID: {id} não foi encontrado no banco de dados.");

            _ormRepo.Delete(laudoPorId);
            await _ormRepo.SaveChangesAsync();

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
        public async Task<List<LaudoResponseDto>> BuscarLaudo(string? dataInicial, string? dataFinal, int medicoId, int pacienteId)
        {
            var dataInicialConvertida = DateTime.Now;
            var dataFinalConvertida = DateTime.Now;

            var query = _bancoContext.Laudos.Where(x => x.PacienteId == pacienteId && x.MedicoId == medicoId);

            if (pacienteId == 0)
                query = _bancoContext.Laudos.Where(x => x.MedicoId == medicoId);
            
            if(medicoId == 0)
                query = _bancoContext.Laudos.Where(x => x.PacienteId == pacienteId);

            if (dataInicial != string.Empty && dataInicial != null && dataFinal != null)
            {
                dataInicialConvertida = DateTime.Parse(dataInicial);
                dataFinalConvertida = DateTime.Parse(dataFinal);
                query = _bancoContext.Laudos.Where(x => x.DataCriacao > dataInicialConvertida && x.DataCriacao < dataFinalConvertida);

            }
            return await query
                .Select(x => new LaudoResponseDto(
                        x.Id,
                        x.Descricao,
                        x.DataCriacao,
                        x.PacienteId,
                        x.MedicoId,
                        x.MedicamentoId
                    ))
                .ToListAsync();
        }
        #endregion

        #region Repositório - Buscar Laudo Por ID
        public async Task<LaudoResponseDto?> BuscarPorIdDto(int id)
        {
            var laudoModel = await _bancoContext.Laudos
                            .Where(x => x.Id == id)
                            .Select(x => new LaudoResponseDto(
                                x.Id,
                                x.Descricao,
                                x.DataCriacao,
                                x.PacienteId,
                                x.MedicoId,
                                x.MedicamentoId
                            ))
                            .FirstOrDefaultAsync();

            return laudoModel;
        }
        #endregion
        
        #region Repositório - Buscar Laudo Por ID
        public async Task<LaudoModel?> BuscarPorId(int id)
        {
            return await _bancoContext.Laudos
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Repositório - Buscar Todos Laudos
        public async Task<List<LaudoResponseDto>> BuscarTodosLaudos()
        {
            return await _bancoContext.Laudos
                .Select(x => new LaudoResponseDto(
                        x.Id,
                        x.Descricao,
                        x.DataCriacao,
                        x.PacienteId,
                        x.MedicoId,
                        x.MedicamentoId
                    ))
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
