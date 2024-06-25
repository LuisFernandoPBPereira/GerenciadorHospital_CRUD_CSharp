namespace GerenciadorHospital.Domain.Exceptions;

public class DomainException : Exception
{
    public string? Mensagem { get; set; }
    
    public DomainException(List<string> mensagens)
    {
        foreach (var mensagem in mensagens)
        {
            Mensagem += $"{mensagem}\n";
        }
    }

    public DomainException(string mensagem)
    {
        Mensagem = mensagem;
    }

    public DomainException() 
    {
        Mensagem = Message;
    }
}
