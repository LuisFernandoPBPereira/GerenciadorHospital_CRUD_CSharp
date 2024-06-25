using GerenciadorHospital.Domain.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorHospital.Models
{
    public class LaudoEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataCriacao { get; set; }
        //[NotMapped]
        //public IFormFile? ImagemLaudo { get; set; }
        public string? CaminhoImagemLaudo { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public int? MedicamentoId { get; set; }
        public int? RegistroConsultaModelId { get; set; }
        public LaudoEntity() { }

        public LaudoEntity(
            int id,
            string descricao,
            DateTime? dataCriacao,
            string? caminhoImagemLaudo,
            int? pacienteId,
            int? medicoId,
            int? medicamentoId,
            int? registroConsultaModelId)
        {
            Id = id;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            CaminhoImagemLaudo = caminhoImagemLaudo;
            PacienteId = pacienteId;
            MedicoId = medicoId;
            MedicamentoId = medicamentoId;
            RegistroConsultaModelId = registroConsultaModelId;

            Validate();
        }

        private void Validate()
        {
            DomainValidation domainValidation = new DomainValidation();

            domainValidation.VerificaSeStringNulaVaziaOuComNumero(Descricao, nameof(Descricao));
            domainValidation.VerificaDataNaoPodeSerNoPassado(DataCriacao, nameof(DataCriacao));

            domainValidation.VerificaErros();
        }
    }
}
