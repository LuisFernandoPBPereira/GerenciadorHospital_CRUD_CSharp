﻿using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Consulta;
using GerenciadorHospital.Repositorios.Paciente;

namespace GerenciadorHospital.Utils
{
    public class ValidaConsulta
    {
        private readonly IRegistroConsultaRepositorio _consultaRepositorio;
        private RegistroConsultaModel _consultaModel;
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public ValidaConsulta(IRegistroConsultaRepositorio consultaRepositorio, 
                              RegistroConsultaModel consultaModel,
                              IPacienteRepositorio pacienteRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
            _consultaModel = consultaModel;
            _pacienteRepositorio = pacienteRepositorio;

        }
        public async Task<bool> ValidacaoConsulta(int id = 0)
        {
            var paciente = _consultaModel.PacienteId;
            PacienteModel? pacientePorId = await _pacienteRepositorio.BuscarPorId(paciente);

            if(_consultaModel.DataConsulta < DateTime.Now && _consultaModel.Retorno == false)
                throw new Exception("A consulta não pode ser marcada para uma data passada");
            
            if(_consultaModel.DataRetorno < DateTime.Now)
                throw new Exception("O retorno não pode ser marcado para uma data passada");

            if(_consultaModel.EstadoConsulta is < StatusConsulta.Agendada or > StatusConsulta.Expirada)
                throw new Exception("Estado da consulta incorreto.");

            if (_consultaModel.PacienteId is < 1)
                throw new Exception("Informe um ID para o paciente corretamente");
            
            if (_consultaModel.MedicoId is < 1)
                throw new Exception("Informe um ID para o médico corretamente");

            if (_consultaModel.ExameId is < 1) 
                throw new Exception("Informe um ID para o exame corretamente");

            if (_consultaModel.EstadoConsulta == Enums.StatusConsulta.Atendida)
                _consultaModel.DataRetorno = DateTime.Now.AddDays(30);

            if(id != 0)
            {
                var consultaPorId = await _consultaRepositorio.BuscarPorId(id);

                if (consultaPorId is not null && pacientePorId is not null)
                {
                    _consultaModel.Valor = 100;
                
                    if (pacientePorId.TemConvenio)
                        _consultaModel.Valor = 0;

                    if (consultaPorId.EstadoConsulta == Enums.StatusConsulta.Expirada && pacientePorId.TemConvenio)
                        _consultaModel.Valor = 100;

                    if (_consultaModel.EstadoConsulta == Enums.StatusConsulta.Atendida)
                    {
                        RegistroConsultaModel novaConsulta = new RegistroConsultaModel();
                        novaConsulta.ExameId = _consultaModel.ExameId;
                        novaConsulta.MedicoId = _consultaModel.MedicoId;
                        novaConsulta.PacienteId = _consultaModel.PacienteId;
                        novaConsulta.Valor = 0;
                        novaConsulta.Retorno = true;
                        novaConsulta.EstadoConsulta = StatusConsulta.Agendada;
                        novaConsulta.DataConsulta = DateTime.Now.AddDays(30);
                        novaConsulta.DataRetorno = novaConsulta.DataConsulta;

                        var novoRetorno = await _consultaRepositorio.Adicionar(novaConsulta);

                        if (novoRetorno is null)
                            throw new Exception("Não foi possível atualizar a consulta");
                    }
                }
            }
            return true;

        }
    }
}
