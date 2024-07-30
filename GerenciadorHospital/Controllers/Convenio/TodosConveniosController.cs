using GerenciadorHospital.Application.UseCases.Convenio;
using GerenciadorHospital.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Controllers.Convenio;

[Tags("Convênio")]
[Route("api/[controller]")]
[ApiController]
public class TodosConveniosController : ControllerBase
{
    private readonly BuscarTodosConveniosUseCase _buscarTodosConveniosUseCase;

    public TodosConveniosController(BuscarTodosConveniosUseCase buscarTodosConveniosUseCase)
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
