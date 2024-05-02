using GerenciadorHospital.Models;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorHospital.Utils
{
    public class ValidaConvenio
    {
        private readonly ConvenioModel _convenioModel;
        public ValidaConvenio(ConvenioModel convenioModel)
        {
            _convenioModel = convenioModel;
        }

        public void ValidacaoConvenio()
        {
            if (_convenioModel.Nome.IsNullOrEmpty())
                throw new Exception("Nome do convênio não foi informado.");
            if (_convenioModel.Preco is 0 or < 0)
                throw new Exception("Preço não pode ser negativo, nem zero");
        }
    }
}
