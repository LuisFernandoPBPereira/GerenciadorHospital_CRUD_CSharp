using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Consulta
{
    public interface IRegistroConsultaService
    {
        public Task<List<RegistroConsultaModel>> BuscarTodosRegistrosConsultas();
        public Task<RegistroConsultaModel> BuscarPorId(int id);
        public Task<List<RegistroConsultaModel>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta);
        public Task<List<RegistroConsultaModel>> BuscarConsultaPorMedicoId(int id, StatusConsulta statusConsulta, string? dataInicial, string? dataFinal);
        public Task<RegistroConsultaModel> Adicionar(RegistroConsultaModel consultaModel);
        public Task<RegistroConsultaModel> Atualizar( RegistroConsultaModel consultaModel, int id);
        public Task<bool> Apagar(int id);
    }
}
