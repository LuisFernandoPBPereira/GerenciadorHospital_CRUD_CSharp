using GerenciadorHospital.Dto;
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
        public Task<PacienteModel> AdicionarPaciente(PacienteModel pacienteModel);
        public Task<PacienteModel> Atualizar( PacienteModel pacienteModel, int id);
        public Task<DocumentoImagemDto> AtualizarDoc(DocumentoImagemDto documentoImagemDto, int id);
        public Task<bool> Apagar(int id);
    }
}
