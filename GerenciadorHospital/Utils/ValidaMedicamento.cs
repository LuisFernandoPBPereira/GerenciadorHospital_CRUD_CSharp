using GerenciadorHospital.Models;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorHospital.Utils
{
    public class ValidaMedicamento
    {
        private readonly MedicamentoPacienteModel _medicamentoModel;
        public ValidaMedicamento(MedicamentoPacienteModel medicamentoModel)
        {
            _medicamentoModel = medicamentoModel;
        }

        public void ValidacaoMedicamento()
        {
            if (_medicamentoModel.Nome.IsNullOrEmpty())
                throw new Exception("Informe um nome para o medicamento");

            if (_medicamentoModel.Composicao.IsNullOrEmpty()) 
                throw new Exception("Informe a composição do medicamento");

            if (_medicamentoModel.DataFabricacao > DateTime.Now)
                throw new Exception("A data de criação não pode ser no futuro");

            if (_medicamentoModel.DataFabricacao == null)
                throw new Exception("Informe a data de fabricação");

            if (_medicamentoModel.DataValidade == null)
                throw new Exception("Informe a data de validade");

            if (_medicamentoModel.DataValidade < DateTime.Now)
                throw new Exception("A data de validade não pode ser uma data passada");
        }
    }
}
