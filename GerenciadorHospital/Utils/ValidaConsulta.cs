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
            //Criamos uma lista de pacientes e uma lista de consultas
            List<RegistroConsultaModel> listaConsultas =  await _consultaRepositorio.BuscarTodosRegistrosConsultas();
            int consultaId = 0;

            //Para cada paciente e para cada consulta, procuramos uma consulta que exista para este paciente
            foreach (var itemConsulta in listaConsultas)
            {
                if (_consultaModel.PacienteId == itemConsulta.PacienteId)
                {
                    consultaId = itemConsulta.Id;
                }
            }
            //Buscamos a consulta e o paciente pelos IDs adquiridos 
            RegistroConsultaModel consultaPorId = await _consultaRepositorio.BuscarPorIdAoAdicionar(consultaId);
            var paciente = _consultaModel.PacienteId;
            PacienteModel pacientePorId = await _pacienteRepositorio.BuscarPorId(paciente);

            //Se foi encontrada uma consulta
            if (consultaPorId != null)
            {
                //A consulta possui um valor padrão para quem não tem convênio
                _consultaModel.Valor = 100;
                _consultaModel.EstadoConsulta = Enums.StatusConsulta.Agendada;
                if (pacientePorId.TemConvenio)
                {
                    _consultaModel.Valor = 0;

                }
                //Se o paciente tem convênio e a consulta não foi realizada, será cobrado um valor padrão da consulta
                if (consultaPorId.EstadoConsulta == Enums.StatusConsulta.Expirada && pacientePorId.TemConvenio)
                {
                    _consultaModel.Valor = 100;
                }
                //Caso contrário, a consulta não será cobrada
                if (consultaPorId.EstadoConsulta == Enums.StatusConsulta.Atendida && pacientePorId.TemConvenio)
                {
                    _consultaModel.Valor = 0;
                }

                //E se o estado desta consulta for Agendada, será mostrado o código 400 com a seguinte mensagem
                if (consultaPorId.EstadoConsulta == Enums.StatusConsulta.Agendada)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
