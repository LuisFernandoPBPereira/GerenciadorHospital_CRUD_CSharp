using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Models
{
    public class RegistroConsultaEntity
    {
        public int Id { get; set; }
        public DateTime DataConsulta {  get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataRetorno { get; set; }
        //public StatusConsulta? EstadoConsulta { get; set; }
        public bool Retorno { get; set; }
        public int PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public int? ExameId { get; set; }

        public RegistroConsultaEntity() {    }

        public RegistroConsultaEntity(
            int id,
            DateTime dataConsulta,
            decimal? valor,
            DateTime? dataRetorno,
            bool retorno,
            int pacienteId,
            int? medicoId,
            int? exameId)
        {
            Id = id;
            DataConsulta = dataConsulta;
            Valor = valor;
            DataRetorno = dataRetorno;
            Retorno = retorno;
            PacienteId = pacienteId;
            MedicoId = medicoId;
            ExameId = exameId;

            Validate();
        }

        private void Validate()
        {
            DomainValidation domainValidation = new DomainValidation();

            domainValidation.VerificaDataNaoPodeSerNoPassado(DataConsulta, nameof(DataConsulta));
            domainValidation.VerificaPreco(Valor);

            domainValidation.VerificaErros();
        }
    }
}
