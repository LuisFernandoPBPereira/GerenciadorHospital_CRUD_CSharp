using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Medicamento;
using GerenciadorHospital.Utils;

namespace GerenciadorHospital.Services.Medicamento
{
    public class MedicamentosService : IMedicamentosService
    {
        private readonly IMedicamentosPacienteRepositorio _medicamentosPacienteRepositorio;
        private readonly ILogger<MedicamentosPacienteController> _logger;
        MensagensLog mensagensLog = new MensagensLog();

        #region Construtor
        public MedicamentosService(IMedicamentosPacienteRepositorio medicamentosPacienteRepositorio,
                                   ILogger<MedicamentosPacienteController> logger)
        {
            _medicamentosPacienteRepositorio = medicamentosPacienteRepositorio;
            _logger = logger;
        }
        #endregion

        #region Service - Adicionar Medicamento
        public async Task<MedicamentoPacienteModel> Adicionar(MedicamentoDto medicamentoDto)
        {
            MedicamentoPacienteModel medicamentoModel = new MedicamentoPacienteModel(medicamentoDto);
            ValidaMedicamento validaMedicamento = new ValidaMedicamento(medicamentoModel);
            validaMedicamento.ValidacaoMedicamento();

            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Adicionar(medicamentoModel);

            if (medicamentos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medicamento)}: Cadastro do medicamento foi realizado.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_POST_Medicamento)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Medicamento)}");

            return medicamentos ?? throw new Exception("Não foi possível cadastrar um medicamento, a response foi nula");
        }
        #endregion

        #region Service - Apagar Medicamento
        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _medicamentosPacienteRepositorio.Apagar(id);

            if (apagado)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medicamento)}: Remoção do medicamento foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_DEL_Medicamento)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_DEL_Medicamento)}");

            return apagado;
        }
        #endregion

        #region Service - Atualizar Medicamento
        public async Task<MedicamentoPacienteModel> Atualizar(MedicamentoDto medicamentoDto, int id)
        {
            MedicamentoPacienteModel medicamentoModel = new MedicamentoPacienteModel(medicamentoDto);
            ValidaMedicamento validaMedicamento = new ValidaMedicamento(medicamentoModel);
            validaMedicamento.ValidacaoMedicamento();

            MedicamentoPacienteModel medicamentos = await _medicamentosPacienteRepositorio.Atualizar(medicamentoModel, id);

            if (medicamentos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medicamento)}: Atualização do medicamento foi realizada.");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_PUT_Medicamento)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_POST_Medicamento)}");

            return medicamentos ?? throw new Exception("Não foi possível atualizar o medicamento, a response foi nula");
        }
        #endregion

        #region Service - Buscar Laudo Por ID
        public async Task<MedicamentoPacienteModel> BuscarPorId(int id)
        {
            MedicamentoPacienteModel? medicamentos = await _medicamentosPacienteRepositorio.BuscarPorId(id);

            if (medicamentos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medicamento)}: Busca de medicamento com ID: {id} foi realizada.");
            else
                _logger.LogInformation(@$"{nameof(Enums.CodigosLogErro.E_GET_Medicamento)}: 
                                        {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Medicamento)} ->
                                        Busca do medicamento com ID: {id} foi realizada.");

            return medicamentos ?? throw new Exception("Não foi possível buscar o medicamento, a busca retornou nulo");
        }
        #endregion

        #region Service - Buscar Todos Medicamentos
        public async Task<List<MedicamentoPacienteModel>> BuscarTodosMedicamentosPaciente()
        {
            List<MedicamentoPacienteModel> medicamentos = await _medicamentosPacienteRepositorio.BuscarTodosMedicamentosPaciente();

            if (medicamentos is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Medicamento)}: Busca de todos os medicamentos foi relizada");
            else
                _logger.LogInformation($"{nameof(Enums.CodigosLogErro.E_GET_Medicamento)}: {mensagensLog.ExibirMensagem(CodigosLogErro.E_GET_Medicamento)}");
            
            return medicamentos ?? throw new Exception("Não foi possível buscar todos os medicamentos, a busca retornou nulo");
        }
        #endregion
    }
}
