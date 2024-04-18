namespace GerenciadorHospital.Enums
{
    public class MensagensLog
    {
        private readonly string[] mensagens = new string[]
        {
            "Erro ao buscar dados do convênio",
            "Erro ao cadastrar convênio",
            "Erro ao atualizar convênio",
            "Erro ao apagar convênio",

            "Erro ao buscar dados do laudo",
            "Erro ao cadastrar laudo",
            "Erro ao atualizar laudo",
            "Erro ao apagar laudo",

            "Erro ao buscar dados do medicamento",
            "Erro ao cadastrar medicamento",
            "Erro ao atualizar medicamento",
            "Erro ao apagar medicamento",

            "Erro ao buscar dados do médico",
            "Erro ao cadastrar médico",
            "Erro ao atualizar médico",
            "Erro ao apagar médico",

            "Erro ao buscar dados do paciente",
            "Erro ao cadastrar paciente",
            "Erro ao atualizar paciente",
            "Erro ao apagar paciente",

            "Erro ao buscar dados da consulta",
            "Erro ao cadastrar consulta",
            "Erro ao atualizar consulta",
            "Erro ao apagar consulta",

            "Erro ao buscar dados do exame",
            "Erro ao cadastrar exame",
            "Erro ao atualizar exame",
            "Erro ao apagar exame",

            "Erro ao buscar dados do usuário",
            "Erro ao cadastrar usuário",
            "Erro ao atualizar usuário",
            "Erro ao apagar usuário",
        };

        public string ExibirMensagem(CodigosLogErro codigosLog)
        {
            return mensagens[(int)codigosLog];
        }
    }
}
