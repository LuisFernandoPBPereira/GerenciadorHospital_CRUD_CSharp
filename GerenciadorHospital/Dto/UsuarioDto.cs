namespace GerenciadorHospital.Dto
{
    public class UsuarioDto
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Senha { get; set; }
        public string? Endereco { get; set; }
        public DateTime? DataNasc { get; set; }
        public string? Role { get; set; }
    }
}
