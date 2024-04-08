using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Repositorios.Interfaces
{
    public interface IRegistroConsultaRepositorio
    {
        Task<List<RegistroConsultaModel>> BuscarTodosRegistrosConsultas();
        Task<RegistroConsultaModel> BuscarPorId(int id);
        Task<List<RegistroConsultaModel>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta);
        Task<RegistroConsultaModel> Adicionar(RegistroConsultaModel registroConsulta);
        Task<RegistroConsultaModel> Atualizar(RegistroConsultaModel registroConsulta, int id);
        Task<bool> Apagar(int id);
    }
}
