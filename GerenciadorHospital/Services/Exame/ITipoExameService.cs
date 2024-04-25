using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Exame
{
    public interface ITipoExameService
    {
        public Task<List<TipoExameModel>> BuscarTodosExames();
        public Task<TipoExameModel> BuscarPorId(int id);
        public Task<TipoExameModel> Adicionar(TipoExameDto exameDto);
        public Task<TipoExameModel> Atualizar(TipoExameDto exameDto, int id);
        public Task<bool> Apagar(int id);
    }
}
