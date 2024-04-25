using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;

namespace GerenciadorHospital.Services.Convenio
{
    public interface IConvenioService
    {
        public Task<List<ConvenioModel>> BuscarTodosConvenios();

        public Task<ConvenioModel> BuscarPorId(int id);

        public Task<ConvenioModel> Adicionar(ConvenioDto convenioDto);

        public Task<ConvenioModel> Atualizar(ConvenioDto convenioDto, int id);

        public Task<bool> Apagar(int id);
    }
}
