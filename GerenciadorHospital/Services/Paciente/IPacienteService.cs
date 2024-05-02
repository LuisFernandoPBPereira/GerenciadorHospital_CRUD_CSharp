using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Paciente
{
    public interface IPacienteService
    {
        public Task<List<PacienteModel>> BuscarTodosPacientes();
        public Task<PacienteModel> BuscarPorId(int id);
        public Task<FileContentResult> BuscarDocConvenioPorId(int id);
        public Task<FileContentResult> BuscarDocPorId(int id);
        public Task<PacienteModel> AdicionarPaciente(PacienteDto pacienteDto);
        public Task<PacienteModel> Atualizar(PacienteDto pacienteDto, int id);
        public Task<DocumentoImagemDto> AtualizarDoc(DocumentoImagemDto documentoImagemDto, int id);
        public Task<bool> Apagar(int id);
    }
}
