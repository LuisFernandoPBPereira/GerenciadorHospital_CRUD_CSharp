using GerenciadorHospital.Dto;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios;
using GerenciadorHospital.Repositorios.Interfaces;
using GerenciadorHospital.Utils;

namespace GerenciadorHospital.Services.Consulta
{
    public class RegistroConsultaService
    {
        private readonly IRegistroConsultaRepositorio _consultaRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public RegistroConsultaService(IRegistroConsultaRepositorio consultaRepositorio,
                                       IPacienteRepositorio pacienteRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
            _pacienteRepositorio = pacienteRepositorio;
        }

        public async Task<RegistroConsultaModel> AdicionarConsulta(RegistroConsultaModel consultaModel)
        {
            //É instanciado um novo objeto para validar o cadastro da consulta
            ValidaConsulta validaConsulta = new ValidaConsulta(_consultaRepositorio, consultaModel, _pacienteRepositorio);
            var consultaValidada = validaConsulta.ValidacaoConsulta();

            if (await consultaValidada == false)
               throw new Exception("Não foi possível cadastrar uma nova consulta: paciente já tem uma consulta agendada");

            RegistroConsultaModel consulta = await _consultaRepositorio.Adicionar(consultaModel);

            return consulta ?? throw new Exception("Não foi possível agendar uma consulta");
        }
    }
}
