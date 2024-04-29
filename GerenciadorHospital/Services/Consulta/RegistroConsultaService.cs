using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;

namespace GerenciadorHospital.Services.Consulta
{
    public class RegistroConsultaService : IRegistroConsultaService
    {
        private readonly IRegistroConsultaRepositorio _consultaRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly ILogger<RegistroConsultaController> _logger;
        MensagensLog mensagensLog = new MensagensLog();

        #region Construtor
        public RegistroConsultaService(IRegistroConsultaRepositorio consultaRepositorio,
                                       IPacienteRepositorio pacienteRepositorio,
                                       ILogger<RegistroConsultaController> logger)
        {
            _consultaRepositorio = consultaRepositorio;
            _pacienteRepositorio = pacienteRepositorio;
            _logger = logger;
            _logger.LogInformation($"{Enums.CodigosLogSucesso.S_Consulta}: Os valores foram atribuídos no construtor da Service.");
        }
        #endregion

        #region Service - Adicionar Consulta
        public async Task<RegistroConsultaModel> Adicionar(RegistroConsultaDto consultaDto)
        {
            RegistroConsultaModel consultaModel = new RegistroConsultaModel(consultaDto);

            ValidaConsulta validaConsulta = new ValidaConsulta(_consultaRepositorio, consultaModel, _pacienteRepositorio);
            var consultaValidada = validaConsulta.ValidacaoConsulta();

            if (await consultaValidada == false)
            {
                _logger.LogError(@$"{Enums.CodigosLogErro.E_POST_Consulta}:  
                                    {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Consulta)} ->
                                    paciente já tem uma consulta agendada");
                throw new Exception("Não foi possível cadastrar uma nova consulta: paciente já tem uma consulta agendada");
            }

            RegistroConsultaModel consulta = await _consultaRepositorio.Adicionar(consultaModel);
            
            if(consulta is not null) 
                _logger.LogInformation($"{Enums.CodigosLogSucesso.S_Consulta}: Consulta cadastrada com sucesso");
             else
                _logger.LogError(@$"{Enums.CodigosLogErro.E_POST_Consulta}: 
                                  {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Consulta)} ->
                                  Não foi possível agendar uma consulta");

            return consulta ?? throw new Exception("Não foi possível agendar uma consulta, reponse foi nulo");
        }
        #endregion

        #region Service - Apagar Consulta
        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _consultaRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Consulta)}: Remoção de consulta com o ID: {id} realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_DEL_Consulta)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_DEL_Consulta)} ->
                                        Remoção de consulta com o ID: {id} não foi concluída.");

            return apagado;
        }
        #endregion

        #region Service - Atualizar Consulta
        public async Task<RegistroConsultaModel> Atualizar(RegistroConsultaDto consultaDto, int id)
        {
            RegistroConsultaModel consultaModel = new RegistroConsultaModel(consultaDto);
            ValidaConsulta validaConsulta = new ValidaConsulta(_consultaRepositorio, consultaModel, _pacienteRepositorio);
            var consultaValidada = await validaConsulta.ValidacaoConsulta();

            if (consultaValidada == false)
                throw new Exception("Não foi possível atualizar a consulta.");

            if (consultaModel.EstadoConsulta == Enums.StatusConsulta.Atendida)
            {
                consultaModel.DataRetorno = DateTime.Now.AddDays(30);
            }

            RegistroConsultaModel consulta = await _consultaRepositorio.Atualizar(consultaModel, id);

            if (consulta is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Consulta)}: Atualização de consulta com o ID: {id} realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_PUT_Consulta)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_PUT_Consulta)} ->
                                        Atualização de consulta com o ID: {id} não foi concluída.");

            return consulta ?? throw new Exception("Não foi possível atualizar a consulta, response foi nulo");
        }
        #endregion

        #region Service - Buscar Consulta Por ID do Médico
        public async Task<List<RegistroConsultaModel>> BuscarConsultaPorMedicoId(int id, StatusConsulta statusConsulta, string? dataInicial, string? dataFinal)
        {
            if (dataInicial == null) dataInicial = string.Empty;
            if (dataFinal == null) dataFinal = string.Empty;
            List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarConsultaPorMedicoId(id, statusConsulta, dataInicial, dataFinal);

            if (consultas is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Consulta)}: Busca de consultas por Médico com ID: {id} e Status Consulta {statusConsulta} realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Consulta)}:  
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Consulta)} ->
                                        Busca de consultas por Médico com ID: {id} e Status Consulta {statusConsulta} realizada, porém sem conteúdo.");

            return consultas ?? throw new Exception("Não foi possível buscar a consulta com o ID do médico, a busca retornou nulo");
        }
        #endregion

        #region Service - Buscar Consulta Por ID do Paciente
        public async Task<List<RegistroConsultaModel>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta)
        {
            List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarConsultaPorPacienteId(id, statusConsulta);

            if (consultas is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Consulta)}: Busca de consultas por Paciente com ID: {id} e Status Consulta {statusConsulta} realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Consulta)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Consulta)} ->
                                        Busca de consultas por Paciente com ID: {id} e Status Consulta {statusConsulta} realizada, porém sem conteúdo.");

            return consultas ?? throw new Exception("Não foi possível buscar consulta por ID do paciente, a busca retornou nulo");
        }
        #endregion

        #region Service - Buscar Consulta Por ID
        public async Task<RegistroConsultaModel> BuscarPorId(int id)
        {
            RegistroConsultaModel consultas = await _consultaRepositorio.BuscarPorId(id);

            if (consultas is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Consulta)}: Busca de consulta com ID: {id} realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Consulta)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Consulta)} ->
                                        Busca de consulta com ID: {id} porém sem conteúdo.");

            return consultas ?? throw new Exception("Não foi possível buscar a consulta por ID, a busca retornou nulo");
        }
        #endregion

        #region Service - Buscar Todas Consultas
        public async Task<List<RegistroConsultaModel>> BuscarTodosRegistrosConsultas()
        {
            List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarTodosRegistrosConsultas();
            if(consultas is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Consulta)}: Busca de todas as consultas realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_GET_Consulta)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Consulta)}");


            return consultas ?? throw new Exception("Resultado da busca foi nulo");
        }
        #endregion
    }
}
