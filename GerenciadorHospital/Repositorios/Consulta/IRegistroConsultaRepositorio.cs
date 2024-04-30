using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Repositorios.Consulta
{
    public interface IRegistroConsultaRepositorio
    {
        Task<List<ConsultaResponseDto>> BuscarTodosRegistrosConsultas();
        Task<ConsultaResponseDto> BuscarPorIdDto(int id);
        Task<RegistroConsultaModel> BuscarPorId(int id);
        Task<List<RegistroConsultaModel>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta);
        Task<List<RegistroConsultaModel>> BuscarConsultaPorMedicoId(int id, StatusConsulta statusConsulta, string? dataInicial, string? dataFinal);
        Task<RegistroConsultaModel> Adicionar(RegistroConsultaModel registroConsulta);
        Task<RegistroConsultaModel> Atualizar(RegistroConsultaModel registroConsulta, int id);
        Task<bool> Apagar(int id);
    }
}
