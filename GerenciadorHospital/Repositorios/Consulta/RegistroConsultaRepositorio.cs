using GerenciadorHospital.Data;
using GerenciadorHospital.Data.ORM;
using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios.Consulta
{
    public class RegistroConsultaRepositorio : IRegistroConsultaRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly IRepositorioORM<RegistroConsultaModel> _ormRepo;
        #region Construtor
        public RegistroConsultaRepositorio(BancoContext bancoContext, IRepositorioORM<RegistroConsultaModel> entityFramework)
        {
            _bancoContext = bancoContext;
            _ormRepo = entityFramework;
        }
        #endregion

        #region Repositório - Adicionar Consulta
        public async Task<RegistroConsultaModel> Adicionar(RegistroConsultaModel registroConsulta)
        {
            await _ormRepo.AddAsync(registroConsulta);
            await _ormRepo.SaveChangesAsync();

            return registroConsulta;
        }
        #endregion

        #region Repositório - Apagar Consulta
        public async Task<bool> Apagar(int id)
        {
            RegistroConsultaModel consultaPorId = await BuscarPorId(id);

            if (consultaPorId == null)
                throw new Exception($"Consulta para o ID: {id} não foi encontrado no banco de dados.");

            await _ormRepo.Delete(consultaPorId);
            await _ormRepo.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Repositório - Atualizar Consulta
        public async Task<RegistroConsultaModel> Atualizar(RegistroConsultaModel registroConsulta, int id)
        {
            RegistroConsultaModel consultaPorId = await BuscarPorId(id);

            if (consultaPorId == null)
                throw new Exception($"Consulta para o ID: {id} não foi encontrado no banco de dados.");

            consultaPorId.EstadoConsulta = registroConsulta.EstadoConsulta;
            consultaPorId.DataConsulta = registroConsulta.DataConsulta;
            consultaPorId.DataRetorno = registroConsulta.DataRetorno;
            consultaPorId.Valor = registroConsulta.Valor;
            consultaPorId.MedicoId = registroConsulta.MedicoId;
            consultaPorId.PacienteId = registroConsulta.PacienteId;
            consultaPorId.ExameId = registroConsulta.ExameId;

            await _ormRepo.Update(consultaPorId);
            await _bancoContext.SaveChangesAsync();

            return consultaPorId;
        }
        #endregion

        #region Repositório - Buscar Consulta Por ID do Paciente
        public async Task<List<ConsultaResponseDto>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta)
        {
            return await _bancoContext.RegistrosConsultas
                .Where(x => statusConsulta == 0 ? x.PacienteId == id : x.PacienteId == id && x.EstadoConsulta == statusConsulta)
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Include(x => x.Laudo)
                .Include(x => x.Exame)
                .Select(x => new ConsultaResponseDto(
                        x.Id,
                        x.DataConsulta,
                        x.DataRetorno,
                        x.Valor,
                        x.EstadoConsulta,
                        x.Laudo!.Select(y => y.Descricao).ToList(),
                        x.Exame == null ? "Não há exame" : x.Exame.Nome,
                        new PacienteResponseDto(x.Paciente!),
                        new MedicoResponseDto(x.Medico!)
                    ))
                .ToListAsync();
        }
        #endregion

        #region Repositório - Buscar Consulta Por ID do Médico
        public async Task<List<ConsultaResponseDto>> BuscarConsultaPorMedicoId(int id, StatusConsulta statusConsulta, string? dataInicial, string? dataFinal)
        {
            DateTime dataInicialConvertida = DateTime.Now;
            DateTime dataFinalConvertida = DateTime.Now;

            var query = _bancoContext.RegistrosConsultas
                .Where(x => statusConsulta == 0 ? x.MedicoId == id : x.MedicoId == id && x.EstadoConsulta == statusConsulta);


            if (dataInicial != string.Empty && dataInicial != null && dataFinal != null)
            {
                dataInicialConvertida = DateTime.Parse(dataInicial);
                dataFinalConvertida = DateTime.Parse(dataFinal);
                query = query.Where(x => dataInicial != string.Empty ? x.DataConsulta.Date > dataInicialConvertida.Date &&
                                                                       x.DataConsulta < dataFinalConvertida : x.MedicoId == id);
            }

            return await query
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Include(x => x.Laudo)
                .Include(x => x.Exame)
                .Select(x => new ConsultaResponseDto(
                        x.Id,
                        x.DataConsulta,
                        x.DataRetorno,
                        x.Valor,
                        x.EstadoConsulta,
                        x.Laudo!.Select(y => y.Descricao).ToList(),
                        x.Exame == null ? "Não há exame" : x.Exame.Nome,
                        new PacienteResponseDto(x.Paciente!),
                        new MedicoResponseDto(x.Medico!)
                    ))
                .ToListAsync();
        }
        #endregion

        #region Repositório - Buscar Consulta Por ID
        public async Task<ConsultaResponseDto> BuscarPorIdDto(int id)
        {
            var consulta = await _bancoContext.RegistrosConsultas
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Include(x => x.Laudo)
                .Include(x => x.Exame)
                .Where(x => x.Id == id)
                .Select(x => new ConsultaResponseDto(
                        x.Id,
                        x.DataConsulta,
                        x.DataRetorno,
                        x.Valor,
                        x.EstadoConsulta,
                        x.Laudo!.Select(y => y.Descricao).ToList(),
                        x.Exame == null ? "Não há exame" : x.Exame.Nome,
                        new PacienteResponseDto(x.Paciente!),
                        new MedicoResponseDto(x.Medico!)
                    ))
                .FirstOrDefaultAsync();

            if (consulta is null)
                throw new Exception("Nenhuma consulta foi encontrada");

            return consulta;

        }
        #endregion

        #region Repositório - Buscar Consulta Por ID
        public async Task<RegistroConsultaModel> BuscarPorId(int id)
        {
            var consulta = await _bancoContext.RegistrosConsultas
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Include(x => x.Laudo)
                .Include(x => x.Exame)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (consulta is null)
                throw new Exception("Nenhuma consulta foi encontrada");

            return consulta;

        }
        #endregion

        #region Repositório - Buscar Todas Consultas
        public async Task<List<ConsultaResponseDto>> BuscarTodosRegistrosConsultas()
        {
            var consultas = await _bancoContext.RegistrosConsultas
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Include(x => x.Exame)
                .Include(x => x.Laudo)
                .Select(x => new ConsultaResponseDto(
                        x.Id,
                        x.DataConsulta,
                        x.DataRetorno,
                        x.Valor,
                        x.EstadoConsulta,
                        x.Laudo!.Select(y => y.Descricao).ToList(),
                        x.Exame == null ? "Não há exame" : x.Exame.Nome,
                        new PacienteResponseDto(x.Paciente!),
                        new MedicoResponseDto(x.Medico!)
                    ))
                .ToListAsync();

            return consultas;
        }
        #endregion
    }
}
