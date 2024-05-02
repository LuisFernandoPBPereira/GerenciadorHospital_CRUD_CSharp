using GerenciadorHospital.Models;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorHospital.Utils
{
    public class ValidaExame
    {
        private readonly TipoExameModel _exameModel;
        public ValidaExame(TipoExameModel exameModel)
        {
            _exameModel = exameModel;
        }

        public void ValidacaoExame()
        {
            if (_exameModel.Nome.IsNullOrEmpty())
                throw new Exception("Nome do exame não pode ser vazio.");
            if (_exameModel.PacienteId is null or < 1)
                throw new Exception("Informe um ID para paciente corretamente");
            if (_exameModel.MedicoId is null or < 1)
                throw new Exception("Informe um ID para médico corretamente");
        }
    }
}
