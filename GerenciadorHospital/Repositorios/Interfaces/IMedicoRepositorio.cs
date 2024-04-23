using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Repositorios.Interfaces
{
    public interface IMedicoRepositorio
    {
        Task<List<MedicoModel>> BuscarTodosMedicos();
        Task<MedicoModel> BuscarPorId(int id);
        Task<MedicoModel> BuscarDocMedicoPorId(int id);
        Task<MedicoModel> Adicionar(MedicoModel medico);
        Task<MedicoModel> Atualizar(MedicoModel medico, int id);
        Task<bool> Apagar(int id);
    }
}
