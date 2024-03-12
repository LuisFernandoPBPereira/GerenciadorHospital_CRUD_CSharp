using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroConsultaController : ControllerBase
    {
        private readonly IRegistroConsultaRepositorio _consultaRepositorio;
        public RegistroConsultaController(IRegistroConsultaRepositorio consultaRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegistroConsultaModel>>> BuscarTodosRegistrosConsultas()
        {
            List<RegistroConsultaModel> consultas = await _consultaRepositorio.BuscarTodosRegistrosConsultas();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RegistroConsultaModel>>> BuscarPorId(int id)
        {
            RegistroConsultaModel consultas = await _consultaRepositorio.BuscarPorId(id);
            return Ok(consultas);
        }

        //Método POST com requisição pelo body para a criação da consulta de forma assíncrona
        [HttpPost]
        public async Task<ActionResult<RegistroConsultaModel>> Adicionar([FromBody] RegistroConsultaModel consultaModel)
        {
            RegistroConsultaModel consulta = await _consultaRepositorio.Adicionar(consultaModel);
            return Ok(consulta);
        }

        //Método PUT com requisição pelo body para a atualização da consulta de forma assíncrona
        [HttpPut("{id}")]
        public async Task<ActionResult<RegistroConsultaModel>> Atualizar([FromBody] RegistroConsultaModel consultaModel, int id)
        {
            consultaModel.Id = id;
            RegistroConsultaModel consulta = await _consultaRepositorio.Atualizar(consultaModel, id);
            return Ok(consulta);
        }

        //Método DELETE que busca a consulta pelo ID para deletar o consulta
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroConsultaModel>> Apagar(int id)
        {
            bool apagado = await _consultaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
