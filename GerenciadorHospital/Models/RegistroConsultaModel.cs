using GerenciadorHospital.Dto;
using GerenciadorHospital.Enums;

namespace GerenciadorHospital.Models
{
    public class RegistroConsultaModel
    {
        public int Id { get; set; }
        public DateTime DataConsulta {  get; set; }
        public decimal? Valor { get; set; }
        public DateTime? DataRetorno { get; set; }
        public StatusConsulta? EstadoConsulta { get; set; }
        public int PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public List<int>? LaudoIds { get; set; }
        public int? ExameId { get; set; }
        public virtual PacienteModel? Paciente { get; set; }
        public virtual MedicoModel? Medico { get; set; }
        public virtual List<LaudoModel>? Laudo { get; set; }
        public virtual TipoExameModel? Exame { get; set; }

        public RegistroConsultaModel() {    }

        public RegistroConsultaModel(RegistroConsultaDto consultaDto)
        {
            DataConsulta = consultaDto.DataConsulta;
            Valor = consultaDto.Valor;
            DataRetorno = consultaDto.DataRetorno;
            EstadoConsulta = consultaDto.EstadoConsulta;
            PacienteId = consultaDto.PacienteId;
            MedicoId = consultaDto.MedicoId;
            LaudoIds = consultaDto.LaudoIds;
            ExameId = consultaDto.ExameId;
        }
    }
}
