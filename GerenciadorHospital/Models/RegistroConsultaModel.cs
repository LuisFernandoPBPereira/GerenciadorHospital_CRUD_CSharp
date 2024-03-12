namespace GerenciadorHospital.Models
{
    public class RegistroConsultaModel
    {
        public int Id { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public DateTime DataConsulta {  get; set; }
        //===========PARA CRIAR NOVA MIGRATION=======
        //public decimal Valor { get; set; }

        /*
         * Pegamos os objetos paciente e médico
        */
        public virtual PacienteModel? Paciente { get; set; }
        public virtual MedicoModel? Medico { get; set; }
    }
}
