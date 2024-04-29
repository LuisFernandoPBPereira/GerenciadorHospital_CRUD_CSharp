using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;

namespace GerenciadorHospital.Services.Exame
{
    public class TipoExameService : ITipoExameService
    {
        private readonly ITipoExameRepositorio _tipoExameRepositorio;
        private readonly ILogger<TipoExameController> _logger;
        MensagensLog mensagensLog = new MensagensLog();

        #region Construtor
        public TipoExameService(ITipoExameRepositorio tipoExameRepositorio,
                                ILogger<TipoExameController> logger)
        {
            _tipoExameRepositorio = tipoExameRepositorio;
            _logger = logger;
            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Os valores foram atribuídos no construtor da Service");
        }
        #endregion

        #region Service - Adicionar Exame
        public async Task<TipoExameModel> Adicionar(TipoExameDto exameDto)
        {
            TipoExameModel tipoExameModel = new TipoExameModel(exameDto);
            ValidaExame validaExame = new ValidaExame(tipoExameModel);
            validaExame.ValidacaoExame();

            TipoExameModel exame = await _tipoExameRepositorio.Adicionar(tipoExameModel);

            if (exame is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Cadastro do exame foi realizado");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_POST_Exame)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Exame)}");

            return exame ?? throw new Exception("Não foi possível cadastrar o exame, a response foi nula");
        }
        #endregion

        #region Service - Apagar Exame
        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _tipoExameRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Remoção do exame foi realizada");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_DEL_Exame)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_DEL_Exame)}");

            return apagado;
        }
        #endregion

        #region Service - Atualizar Exame
        public async Task<TipoExameModel> Atualizar(TipoExameDto exameDto, int id)
        {
            TipoExameModel tipoExameModel = new TipoExameModel(exameDto);
            ValidaExame validaExame = new ValidaExame(tipoExameModel);
            validaExame.ValidacaoExame();

            TipoExameModel exame = await _tipoExameRepositorio.Atualizar(tipoExameModel, id);

            if (exame is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Atualização do exame foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_PUT_Exame)}:  {mensagensLog.ExibirMensagem(CodigosLogErro.E_PUT_Exame)}");

            return exame ?? throw new Exception("Não foi possível atualizar o exame, a response foi nula");
        }
        #endregion

        #region Service - Buscar Exame Por ID
        public async Task<TipoExameModel> BuscarPorId(int id)
        {
            TipoExameModel exames = await _tipoExameRepositorio.BuscarPorId(id);

            if (exames is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Busca de exame com ID: {id} foi realizada");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Exame)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Exame)} ->
                                        Busca de exme com ID: {id} não foi realizada");

            return exames ?? throw new Exception("Não foi possível buscar o exame por ID, a busca retornou nulo");
        }
        #endregion

        #region Service - Buscar Todos Exames
        public async Task<List<TipoExameModel>> BuscarTodosExames()
        {
            List<TipoExameModel> exames = await _tipoExameRepositorio.BuscarTodosExames();

            if (exames is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Busca de todos exames foi realizada");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_GET_Exame)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Exame)}");

            return exames ?? throw new Exception("Não foi possível buscar todos exames, a busca retornou nulo");
        }
        #endregion
    }
}
