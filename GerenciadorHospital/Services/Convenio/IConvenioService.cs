using GerenciadorHospital.Models;

namespace GerenciadorHospital.Services.Convenio
{
    public interface IConvenioService
    {
        public Task<List<ConvenioModel>> BuscarTodosConvenios();

        public Task<ConvenioModel> BuscarPorId(int id);

        public Task<ConvenioModel> Adicionar(ConvenioModel convenioModel);

        public Task<ConvenioModel> Atualizar(ConvenioModel convenioModel, int id);

        public Task<bool> Apagar(int id);
    }
}
