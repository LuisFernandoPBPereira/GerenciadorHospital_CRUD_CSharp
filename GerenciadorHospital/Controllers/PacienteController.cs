using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
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
        public async Task<ActionResult<PacienteModel>> Adicionar(PacienteResquestDto requestDto)
        {     
            //Se as fotos não forem carregadas, será retornado uma BadRequest
            if (requestDto.Doc == null || requestDto.Doc.Length == 0)
            {
                return BadRequest("Nenhuma foto de documento foi carregada");
            }
            if (requestDto.DocConvenio == null || requestDto.DocConvenio.Length == 0)
            {
                return BadRequest("Nenhuma foto de convênio foi carregada");
            }
            
            //Passamos os caminhos das imagens
            var caminhoDoc = Path.Combine("Imagens/", requestDto.Doc.FileName);
            var caminhoConvenio = Path.Combine("Imagens/", requestDto.DocConvenio.FileName);

            //Todos pacientes recebem a imagem de documento
            requestDto.ImgDocumento = caminhoConvenio;

            using (var stream = new FileStream(caminhoDoc, FileMode.Create))
            {
                await requestDto.Doc.CopyToAsync(stream);
            }

            using (var stream = new FileStream(caminhoConvenio, FileMode.Create))
            {
                await requestDto.DocConvenio.CopyToAsync(stream);
            }

            //Se o paciente tem comvênio, ele recebe a imagem da carteira do convênio
            
            if (requestDto.TemConvenio)
            {
                requestDto.ImgCarteiraDoConvenio = $"../../../Imagens/{requestDto.DocConvenio.FileName}";
            }

            requestDto.ImgDocumento = $"../../../Imagens/{requestDto.Doc.FileName}";
            
            PacienteModel paciente = await _pacienteRepositorio.Adicionar(requestDto);
            
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
