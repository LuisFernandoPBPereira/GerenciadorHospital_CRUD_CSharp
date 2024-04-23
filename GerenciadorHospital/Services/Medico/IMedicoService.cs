using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Medico
{
    public interface IMedicoService
    {
        public Task<List<MedicoModel>> BuscarTodosMedicos();
        public Task<MedicoModel> BuscarPorId(int id);
        public Task<FileContentResult> BuscarDocMedicoPorId(int id);
        public Task<MedicoModel> Adicionar(MedicoModel medicoModel);
        public Task<MedicoModel> Atualizar(MedicoModel medicoModel, int id);
        public Task<bool> Apagar(int id);
    }
}
