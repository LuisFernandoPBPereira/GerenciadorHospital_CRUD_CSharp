using GerenciadorHospital.Controllers;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;

namespace GerenciadorHospital.Services.Exame
{
    public class TipoExameService : ITipoExameService
    {
        private readonly ITipoExameRepositorio _tipoExameRepositorio;
        private readonly ILogger<TipoExameController> _logger;
        public TipoExameService(ITipoExameRepositorio tipoExameRepositorio,
                                ILogger<TipoExameController> logger)
        {
            _tipoExameRepositorio = tipoExameRepositorio;
            _logger = logger;
            _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Os valores foram atribuídos no construtor da Service");
        }
        public async Task<TipoExameModel> Adicionar(TipoExameModel tipoExameModel)
        {
            TipoExameModel exame = await _tipoExameRepositorio.Adicionar(tipoExameModel);

            if (exame is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Cadastro do exame foi realizado");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Exame)}: Cadastro do exame não foi realizado");

            return exame;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _tipoExameRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Remoção do exame foi realizada");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Exame)}: Remoção do exame não foi realizada");

            return apagado;
        }

        public async Task<TipoExameModel> Atualizar(TipoExameModel tipoExameModel, int id)
        {
            tipoExameModel.Id = id;
            TipoExameModel exame = await _tipoExameRepositorio.Atualizar(tipoExameModel, id);

            if (exame is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Atualização do exame foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Exame)}: Atualização do exame não foi realizada.");

            return exame;
        }

        public async Task<TipoExameModel> BuscarPorId(int id)
        {
            TipoExameModel exames = await _tipoExameRepositorio.BuscarPorId(id);

            if (exames is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Busca de exame com ID: {id} foi realizada");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Exame)}: Busca de exme com ID: {id} não foi realizada");

            return exames;
        }

        public async Task<List<TipoExameModel>> BuscarTodosExames()
        {
            List<TipoExameModel> exames = await _tipoExameRepositorio.BuscarTodosExames();

            if (exames is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Exame)}: Busca de todos exames foi realizada");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_Exame)}: Busca de todos exames não foi realizada");

            return exames;
        }
    }
}
