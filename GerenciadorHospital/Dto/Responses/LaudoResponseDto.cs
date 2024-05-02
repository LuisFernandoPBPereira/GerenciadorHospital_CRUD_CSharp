using GerenciadorHospital.Models;

namespace GerenciadorHospital.Dto.Responses
{
    public record LaudoResponseDto(
        int Id,
        string Descricao,
        DateTime? DataCriacao,
        int? PacienteId,
        int? MedicoId,
        int? MedicamentoId
    );
    
}
