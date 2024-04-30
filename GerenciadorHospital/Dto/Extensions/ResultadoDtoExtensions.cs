using FluentResults;
using GerenciadorHospital.Dto;
using System.Runtime.CompilerServices;

namespace GerenciadorHospital.Dto.Extensions
{
    public static class ResultadoDtoExtensions
    {
        public static ResultadoDto<TResponse> MostraResultadoDto<TResponse>(this Result<TResponse> resultado)
        {
            var mensagensErro = resultado.Errors?.Select(erro => erro.Message);

            return new ResultadoDto<TResponse>(resultado.IsSuccess, resultado.ValueOrDefault, mensagensErro);
        }
    }
}
