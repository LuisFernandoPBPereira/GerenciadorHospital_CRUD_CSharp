using GerenciadorHospital.Domain.Exceptions;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace GerenciadorHospital.Domain.Validations;

public class DomainValidation
{
    public List<string> Erros { get; set; } = [];

    public void VerificaSeStringNulaVaziaOuComNumero(string campo, string nomeDoCampo)
    {
        if (campo is null || campo.Equals(string.Empty) || Regex.IsMatch(campo, "[0-9]+")) 
            Erros.Add($"{nomeDoCampo} inválido");
    }
    
    public void VerificaSeStringNulaVazia(string? campo, string nomeDoCampo)
    {
        if (campo is null || campo.Equals(string.Empty)) 
            Erros.Add($"{nomeDoCampo} inválido");
    }
    
    public void VerificaCpf(string cpf)
    {
        if (cpf is null || Regex.IsMatch(cpf, "^\\d{3}\\d{3}\\d{3}\\d{2}$") is false)
            Erros.Add("CPF inválido");
    }

    public void VerificaDataDeNascimento(DateTime date)
    {
        if (date <= DateTime.Parse("1900-01-01") || date.Date >= DateTime.Now.Date)
            Erros.Add("Data de nascimento inválida");            
    }

    public void VerificaDataNaoPodeSerNoPassado(DateTime? date, string nomeCampo)
    {
        if(date < DateTime.Now)
            Erros.Add($"{nomeCampo} inválida");
    }

    public void VerificaSenha(string senha)
    {
        if (senha is null || Regex.IsMatch(senha, "^(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,}$") is false)
        {
            Erros.Add(
                "A senha deve conter no mínimo 6 caracteres, no mínimo 1 letra maiúscula, no mínimo 1 número e no mínimo 1 caractere especial"
            );
        }
    }

    public void VerificaPreco(decimal? preco)
    {
        if (preco is null || preco < 0)
            Erros.Add("Preço não pode ser negativo");
    }

    public void VerificaCrm(string crm)
    {
        if(crm is null || crm == string.Empty || crm.Length >= 10)
        {
            Erros.Add("CRM inválido");
        }
    }

    public void VerificaId(int? id)
    {
        if(id is null || id <= 0)
        {
            Erros.Add("Id inválido");
        }
    }
    
    public void VerificaIdPossivelmenteNulo(int? id)
    {
        if(id is not null && id <= 0)
        {
            Erros.Add("Id inválido");
        }
    }

    public void VerificaEndereco(string endereco)
    {
        if (endereco is null || endereco.Equals(string.Empty) || Information.IsNumeric(endereco))
            Erros.Add($"Endereço inválido");
    }

    public void VerificaErros()
    {
        if (Erros.Count != 0) throw new DomainException(Erros);
    }
}
