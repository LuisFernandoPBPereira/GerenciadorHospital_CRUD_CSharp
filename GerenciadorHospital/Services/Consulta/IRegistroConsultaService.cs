﻿using GerenciadorHospital.Dto.Requests;
using GerenciadorHospital.Dto.Responses;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Services.Consulta
{
    public interface IRegistroConsultaService
    {
        public Task<List<ConsultaResponseDto>> BuscarTodosRegistrosConsultas();
        public Task<RegistroConsultaModel> BuscarPorId(int id);
        public Task<ConsultaResponseDto> BuscarPorIdDto(int id);
        public Task<List<ConsultaResponseDto>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta);
        public Task<List<ConsultaResponseDto>> BuscarConsultaPorMedicoId(int id, StatusConsulta statusConsulta, string? dataInicial, string? dataFinal);
        public Task<RegistroConsultaModel> Adicionar(RegistroConsultaDto consultaDto);
        public Task<RegistroConsultaModel> Atualizar(RegistroConsultaDto consultaDto, int id);
        public Task<bool> Apagar(int id);
    }
}
