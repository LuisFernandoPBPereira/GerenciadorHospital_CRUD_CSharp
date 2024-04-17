using GerenciadorHospital.Controllers;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace GerenciadorHospital.Services.Consulta
{
    public class RegistroConsultaService : IRegistroConsultaService
    {
        private readonly IRegistroConsultaRepositorio _consultaRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly ILogger<RegistroConsultaController> _logger;

        public RegistroConsultaService(IRegistroConsultaRepositorio consultaRepositorio,
                                       IPacienteRepositorio pacienteRepositorio,
                                       ILogger<RegistroConsultaController> logger)
        {
            _consultaRepositorio = consultaRepositorio;
            _pacienteRepositorio = pacienteRepositorio;
            _logger = logger;
        }

        public async Task<RegistroConsultaModel> Adicionar(RegistroConsultaModel consultaModel)
        {
            //É instanciado um novo objeto para validar o cadastro da consulta
            ValidaConsulta validaConsulta = new ValidaConsulta(_consultaRepositorio, consultaModel, _pacienteRepositorio);
            var consultaValidada = validaConsulta.ValidacaoConsulta();

            if (await consultaValidada == false)
            {
                _logger.LogError("Não foi possível cadastrar uma nova consulta: paciente já tem uma consulta agendada");
                throw new Exception("Não foi possível cadastrar uma nova consulta: paciente já tem uma consulta agendada");
            }

            RegistroConsultaModel consulta = await _consultaRepositorio.Adicionar(consultaModel);
            
            if(consulta is not null) 
                _logger.LogInformation("Consulta cadastrada com sucesso");
             else
                _logger.LogError("Não foi possível agendar uma consulta");

            return consulta ?? throw new Exception("Não foi possível agendar uma consulta");
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _consultaRepositorio.Apagar(id);
            return apagado;
        }

        public async Task<RegistroConsultaModel> Atualizar(RegistroConsultaModel consultaModel, int id)
        {
            consultaModel.Id = id;

            if (consultaModel.EstadoConsulta == Enums.StatusConsulta.Atendida)
            {
                consultaModel.DataRetorno = DateTime.Now.AddDays(30);
            }

            RegistroConsultaModel consulta = await _consultaRepositorio.Atualizar(consultaModel, id);
            return consulta;
        }

        public async Task<List<RegistroConsultaModel>> BuscarConsultaPorMedicoId(int id, StatusConsulta statusConsulta, string? dataInicial, string? dataFinal)
        {
            if (dataInicial == null) dataInicial = string.Empty;
            if (dataFinal == null) dataFinal = string.Empty;
            List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarConsultaPorMedicoId(id, statusConsulta, dataInicial, dataFinal);
            return consultas;
        }

        public async Task<List<RegistroConsultaModel>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta)
        {
            List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarConsultaPorPacienteId(id, statusConsulta);
            return consultas;
        }

        public async Task<RegistroConsultaModel> BuscarPorId(int id)
        {
            RegistroConsultaModel consultas = await _consultaRepositorio.BuscarPorId(id);
            return consultas;
        }

        public async Task<List<RegistroConsultaModel>> BuscarTodosRegistrosConsultas()
        {
            List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarTodosRegistrosConsultas();
            if(consultas is not null)
                _logger.LogInformation($"{nameof(Enums.CodigosLogSucesso.S_Consulta)}: Busca de todas as consultas realizada.");
            else
                _logger.LogInformation("Busca de todas as consultas porém sem conteúdo.");


            return consultas;
        }
    }
}
