using GerenciadorHospital.Models;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorHospital.Utils
{
    public class ValidaPaciente
    {
        private readonly PacienteModel _pacienteModel;
        public ValidaPaciente(PacienteModel pacienteModel)
        {
            _pacienteModel = pacienteModel;
        }

        public void ValidacaoPaciente()
        {
            if (_pacienteModel.Nome.IsNullOrEmpty())
                throw new Exception("Informe um nome para o paciente");

            if (_pacienteModel.Cpf.IsNullOrEmpty()) 
                throw new Exception("Informe um CPF para o paciente");

            if (_pacienteModel.DataNasc > DateTime.Now || _pacienteModel.DataNasc.Year < 1900) 
                throw new Exception("Informe uma data de nascimento corretamente");

            if (_pacienteModel.Endereco.IsNullOrEmpty())
                throw new Exception("Informe um endereço para o paciente");

            if (_pacienteModel.Senha.IsNullOrEmpty())
                throw new Exception("Informe a senha do paciente");

            if (_pacienteModel.Doc is null)
                throw new Exception("Imagem do documento não foi carregada");

            if (_pacienteModel.TemConvenio && _pacienteModel.DocConvenio is null)
                throw new Exception("Imagem da carteira do convênio não foi carregada");

            if (_pacienteModel.TemConvenio && _pacienteModel.ConvenioId is null or < 1)
                throw new Exception("Informe o ID do convênio corretamente");
        }
    }
}
