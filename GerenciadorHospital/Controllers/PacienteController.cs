using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public PacienteController(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PacienteModel>>> BuscarTodosPacientes()
        {
            List<PacienteModel> pacientes = await _pacienteRepositorio.BuscarTodosPacientes();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PacienteModel>>> BuscarPorId(int id)
        {
            PacienteModel paciente = await _pacienteRepositorio.BuscarPorId(id);
            return Ok(paciente);
        }

        //Método POST com requisição pelo body para a criação do paciente de forma assíncrona
        [HttpPost]
        public async Task<ActionResult<PacienteModel>> Adicionar([FromBody] PacienteModel pacienteModel)
        {
            //Passamos os caminhos das imagens
            string caminhoCarteiraConvenio = "../../../Imagens/documentoConvenio.jpg";
            string caminhoDocumento = "../../../Imagens/documento.jpg";

            //Todos pacientes recebem a imagem de documento
            pacienteModel.ImgDocumento = caminhoDocumento;

            //Se o paciente tem comvênio, ele recebe a imagem da carteira do convênio
            if (pacienteModel.TemConvenio)
            {
                pacienteModel.ImgCarteiraDoConvenio = caminhoCarteiraConvenio;
            }

            PacienteModel paciente = await _pacienteRepositorio.Adicionar(pacienteModel);
            return Ok(paciente);
        }

        //Método PUT com requisição pelo body para a atualização do paciente de forma assíncrona
        [HttpPut("{id}")]
        public async Task<ActionResult<PacienteModel>> Atualizar([FromBody] PacienteModel pacienteModel, int id)
        {
            pacienteModel.Id = id;
            PacienteModel paciente = await _pacienteRepositorio.Atualizar(pacienteModel, id);
            return Ok(paciente);
        }

        //Método DELETE que busca o paciente pelo ID para deletar o paciente
        [HttpDelete("{id}")]
        public async Task<ActionResult<PacienteModel>> Apagar(int id)
        {
            bool apagado = await _pacienteRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
