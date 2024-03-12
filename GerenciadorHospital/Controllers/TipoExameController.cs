using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoExameController : ControllerBase
    {
        private readonly ITipoExameRepositorio _tipoExameRepositorio;
        public TipoExameController(ITipoExameRepositorio tipoExameRepositorio)
        {
            _tipoExameRepositorio = tipoExameRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoExameModel>>> BuscarTodosExames()
        {
            List<TipoExameModel> exames = await _tipoExameRepositorio.BuscarTodosExames();
            return Ok(exames);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TipoExameModel>>> BuscarPorId(int id)
        {
            TipoExameModel exames = await _tipoExameRepositorio.BuscarPorId(id);
            return Ok(exames);
        }

        //Método POST com requisição pelo body para a criação do exame de forma assíncrona
        [HttpPost]
        public async Task<ActionResult<TipoExameModel>> Adicionar([FromBody] TipoExameModel tipoExameModel)
        {
            TipoExameModel exame = await _tipoExameRepositorio.Adicionar(tipoExameModel);
            return Ok(exame);
        }

        //Método PUT com requisição pelo body para a atualização do exame de forma assíncrona
        [HttpPut("{id}")]
        public async Task<ActionResult<TipoExameModel>> Atualizar([FromBody] TipoExameModel tipoExameModel, int id)
        {
            tipoExameModel.Id = id;
            TipoExameModel exame = await _tipoExameRepositorio.Atualizar(tipoExameModel, id);
            return Ok(exame);
        }

        //Método DELETE que busca o exame pelo ID para deletar o exame
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoExameModel>> Apagar(int id)
        {
            bool apagado = await _tipoExameRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
