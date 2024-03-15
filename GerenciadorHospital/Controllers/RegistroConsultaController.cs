using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroConsultaController : ControllerBase
    {
        private readonly IRegistroConsultaRepositorio _consultaRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public RegistroConsultaController(IRegistroConsultaRepositorio consultaRepositorio, 
                                          IPacienteRepositorio pacienteRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
            _pacienteRepositorio = pacienteRepositorio;
        }

        /// <summary>
        /// Busca Todas Consultas
        /// </summary>
        /// <returns>Todas Consultas</returns>
        /// <response code="200">Consultas Retornadas com SUCESSO</response>
        [HttpGet]
        public async Task<ActionResult<List<RegistroConsultaModel>>> BuscarTodosRegistrosConsultas()
        {
            List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarTodosRegistrosConsultas();
            return Ok(consultas);
        }

        /// <summary>
        /// Busca Consulta por ID
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <returns>Consulta</returns>
        /// <response code="200">Consulta Retornada com SUCESSO</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RegistroConsultaModel>>> BuscarPorId(int id)
        {
            RegistroConsultaModel consultas = await _consultaRepositorio.BuscarPorId(id);
            return Ok(consultas);
        }

        /// <summary>
        /// Cadastrar Consulta
        /// </summary>
        /// <param name="consultaModel">Dados da Consulta</param>
        /// <returns>Consulta Cadastrada</returns>
        /// <response code="200">Consulta Cadastrada com SUCESSO</response>
        [HttpPost]
        public async Task<ActionResult<RegistroConsultaModel>> Adicionar([FromBody] RegistroConsultaModel consultaModel)
        {
            //Criamos uma lista de pacientes e uma lista de consultas
            //List<PacienteModel> listaPacientes = await _pacienteRepositorio.BuscarTodosPacientes();
            List<RegistroConsultaModel> listaConsultas = await _consultaRepositorio.BuscarTodosRegistrosConsultas();
            int consultaId = 0;

            //Para cada paciente e para cada consulta, procuramos uma consulta que exista para este paciente
            
                foreach (var itemConsulta in listaConsultas)
                {
                    if (consultaModel.PacienteId == itemConsulta.PacienteId)
                    {
                        consultaId = itemConsulta.Id;
                    }
                }
            //Buscamos a consulta e o paciente pelos IDs adquiridos 
            RegistroConsultaModel consultaPorId = await _consultaRepositorio.BuscarPorId(consultaId);
            var paciente = consultaModel.PacienteId;
            PacienteModel pacientePorId = await _pacienteRepositorio.BuscarPorId(paciente);
            
            //A consulta possui um valor padrão para quem não tem convênio
            consultaModel.Valor = 100;
            consultaModel.EstadoConsulta = Enums.StatusConsulta.Agendada;
            if (pacientePorId.TemConvenio)
            {
                consultaModel.Valor = 0;

            }
            //Se o paciente tem convênio e a consulta não foi realizada, será cobrado um valor padrão da consulta
            else if (consultaPorId.EstadoConsulta == Enums.StatusConsulta.Expirada && pacientePorId.TemConvenio)
            {
                consultaModel.Valor = 100;
            }
            //Caso contrário, a consulta não será cobrada
            else if(consultaPorId.EstadoConsulta == Enums.StatusConsulta.Atendida && pacientePorId.TemConvenio) 
            {
                consultaModel.Valor = 0;
            }

            //Se foi encontrada uma consulta
            if (consultaPorId != null)
            { 
                //E se o estado desta consulta for Agendada, será mostrado o código 400 com a seguinte mensagem
                if (consultaPorId.EstadoConsulta == Enums.StatusConsulta.Agendada)
                {
                    return BadRequest("Não foi possível agendar uma consulta, pois existe uma consulta agendada para este paciente");
                }
            }

            RegistroConsultaModel consulta = await _consultaRepositorio.Adicionar(consultaModel);
            
            if(consulta == null)
            {
                return BadRequest("Não foi possível agendar uma consulta");
            }

            return Ok(consulta);

        }

        /// <summary>
        /// Atualizar Consulta
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <param name="consultaModel">Dados da Consulta</param>
        /// <returns>Consulta Atualizada</returns>
        /// <response code="200">Consulta Atualizada com SUCESSO</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<RegistroConsultaModel>> Atualizar([FromBody] RegistroConsultaModel consultaModel, int id)
        {
            consultaModel.Id = id;

            if (consultaModel.EstadoConsulta == Enums.StatusConsulta.Atendida)
            {
                consultaModel.DataRetorno = DateTime.Now.AddDays(30);
            }

            RegistroConsultaModel consulta = await _consultaRepositorio.Atualizar(consultaModel, id);
            return Ok(consulta);
        }

        /// <summary>
        /// Apagar Consulta
        /// </summary>
        /// <param name="id">ID da Consulta</param>
        /// <returns>Booleano</returns>
        /// <response code="200">Consulta Apagada com SUCESSO</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroConsultaModel>> Apagar(int id)
        {
            bool apagado = await _consultaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
