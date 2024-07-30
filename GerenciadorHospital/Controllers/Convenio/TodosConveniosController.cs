using GerenciadorHospital.Application.UseCases.Convenio;
using GerenciadorHospital.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Convenio;

[Tags("Convênio")]
[Route("api/[controller]")]
[ApiController]
public class TodosConveniosController : ControllerBase
{
    private readonly TodosConveniosUseCase _buscarTodosConveniosUseCase;

    public TodosConveniosController(TodosConveniosUseCase buscarTodosConveniosUseCase)
    {
        _buscarTodosConveniosUseCase = buscarTodosConveniosUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodosConvenios()
    {
        try
        {
            var convenios = await _buscarTodosConveniosUseCase.Executar();
            return Ok(convenios);
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Mensagem);
        }
        
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
