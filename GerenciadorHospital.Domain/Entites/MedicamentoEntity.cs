﻿namespace GerenciadorHospital.Models
{
    public class MedicamentoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Composicao { get; set; } = string.Empty;
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }

        public MedicamentoEntity(){  }
    }
}
