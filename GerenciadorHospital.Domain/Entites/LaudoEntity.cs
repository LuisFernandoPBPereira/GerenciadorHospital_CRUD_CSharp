using GerenciadorHospital.Domain.Validations;

namespace GerenciadorHospital.Domain.Entites
{
    public class LaudoEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public int? MedicamentoId { get; set; }
        public int? RegistroConsultaModelId { get; set; }
        public LaudoEntity() 
        { 
            Descricao = string.Empty;
        }

        public LaudoEntity(
            string descricao,
            DateTime? dataCriacao,
            int? pacienteId,
            int? medicoId,
            int? medicamentoId,
            int? registroConsultaModelId)
        {
            Descricao = descricao;
            DataCriacao = dataCriacao;
            PacienteId = pacienteId;
            MedicoId = medicoId;
            MedicamentoId = medicamentoId;
            RegistroConsultaModelId = registroConsultaModelId;

            Validate();
        }
        
        public LaudoEntity(
            int id,
            string descricao,
            DateTime? dataCriacao,
            int? pacienteId,
            int? medicoId,
            int? medicamentoId,
            int? registroConsultaModelId)
        {
            Id = id;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            PacienteId = pacienteId;
            MedicoId = medicoId;
            MedicamentoId = medicamentoId;
            RegistroConsultaModelId = registroConsultaModelId;

            Validate();
        }

        private void Validate()
        {
            DomainValidation domainValidation = new DomainValidation();

            domainValidation.VerificaId(PacienteId);
            domainValidation.VerificaId(MedicoId);
            domainValidation.VerificaId(RegistroConsultaModelId);
            domainValidation.VerificaIdPossivelmenteNulo(MedicamentoId);
            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Descricao, nameof(Descricao));
            domainValidation.VerificaDataNaoPodeSerNoPassado(DataCriacao, nameof(DataCriacao));

            domainValidation.VerificaErros();
        }
    }
}
