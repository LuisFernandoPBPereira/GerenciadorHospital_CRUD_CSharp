﻿using Microsoft.AspNetCore.Identity;

namespace GerenciadorHospital.Models
{
    public class UsuarioModel : IdentityUser
    {
        #pragma warning disable CS0114 // O membro oculta o membro herdado; palavra-chave substituta ausente
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Senha { get; set; }
        public string? Endereco { get; set; }
        public DateTime? DataNasc { get; set; }
        public string? Role { get; set; }
    }
}
