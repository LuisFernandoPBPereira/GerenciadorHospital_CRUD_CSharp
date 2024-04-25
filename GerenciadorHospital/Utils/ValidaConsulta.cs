using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Utils
{
    public class ValidaConsulta
    {
        private readonly IRegistroConsultaRepositorio _consultaRepositorio;
        private readonly RegistroConsultaModel _consultaModel;
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public ValidaConsulta(IRegistroConsultaRepositorio consultaRepositorio, 
                              RegistroConsultaModel consultaModel,
                              IPacienteRepositorio pacienteRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
            _consultaModel = consultaModel;
            _pacienteRepositorio = pacienteRepositorio;

        }
        public async Task<bool> ValidacaoConsulta()
        {
            int consultaId = 0;
            List<RegistroConsultaModel> listaConsultas =  await _consultaRepositorio.BuscarTodosRegistrosConsultas();

            foreach (var itemConsulta in listaConsultas)
            {
                if (_consultaModel.PacienteId == itemConsulta.PacienteId)
                    consultaId = itemConsulta.Id;
            }

            RegistroConsultaModel consultaPorId = await _consultaRepositorio.BuscarPorIdAoAdicionar(consultaId);

            var paciente = _consultaModel.PacienteId;
            PacienteModel pacientePorId = await _pacienteRepositorio.BuscarPorId(paciente);

            if(_consultaModel.DataConsulta < DateTime.Now)
                throw new Exception("A consulta não pode ser marcada para uma data passada");

            if(_consultaModel.EstadoConsulta is < StatusConsulta.Agendada or > StatusConsulta.Expirada)
                throw new Exception("Estado da consulta incorreto.");


            if (consultaPorId != null)
            {
                _consultaModel.Valor = 100;
                _consultaModel.EstadoConsulta = Enums.StatusConsulta.Agendada;
                
                if (pacientePorId.TemConvenio)
                {
                    _consultaModel.Valor = 0;
                }

                if (consultaPorId.EstadoConsulta == Enums.StatusConsulta.Expirada && pacientePorId.TemConvenio)
                {
                    _consultaModel.Valor = 100;
                }

                if (consultaPorId.EstadoConsulta == Enums.StatusConsulta.Atendida && pacientePorId.TemConvenio)
                {
                    _consultaModel.Valor = 0;
                }

                if (consultaPorId.EstadoConsulta == Enums.StatusConsulta.Agendada)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
