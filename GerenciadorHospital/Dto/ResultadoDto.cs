namespace GerenciadorHospital.Dto
{
    public class ResultadoDto<TResponse>
    {
        public const string Type = "ResultadoDto";
        public bool IsSuccess { get; set; }
        public TResponse Resultado { get; set;}
        public IEnumerable<string>? Erros { get; set;}

        public ResultadoDto(bool isSuccess, TResponse resultado, IEnumerable<string>? erros)
        {
            IsSuccess = isSuccess;
            Resultado = resultado;
            Erros = erros;
        }
    }
}
