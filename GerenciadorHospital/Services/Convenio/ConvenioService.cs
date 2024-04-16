using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Convenio
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepositorio _convenioRepositorio;
        public ConvenioService(IConvenioRepositorio convenioRepositorio)
        {
            _convenioRepositorio = convenioRepositorio;   
        }

        public async Task<List<ConvenioModel>> BuscarTodosConvenios()
        {
            List<ConvenioModel> convenios = await _convenioRepositorio.BuscarTodosConvenios();
            return convenios;
        }

        public async Task<ConvenioModel> BuscarPorId(int id)
        {
            ConvenioModel convenio = await _convenioRepositorio.BuscarPorId(id);
            return convenio;
        }

        public async Task<ConvenioModel> Adicionar(ConvenioModel convenioModel)
        {
            ConvenioModel convenio = await _convenioRepositorio.Adicionar(convenioModel);
            return convenio;
        }

        public async Task<ConvenioModel> Atualizar(ConvenioModel convenioModel, int id)
        {
            convenioModel.Id = id;
            ConvenioModel convenio = await _convenioRepositorio.Atualizar(convenioModel, id);
            return convenio;
        }

        public async Task<bool> Apagar(int id)
        {
            bool apagado = await _convenioRepositorio.Apagar(id);
            return apagado;
        }
    }
}
