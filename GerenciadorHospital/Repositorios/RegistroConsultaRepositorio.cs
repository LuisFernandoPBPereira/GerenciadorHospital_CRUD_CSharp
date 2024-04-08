using GerenciadorHospital.Data;
using GerenciadorHospital.Enums;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Repositorios
{
    public class RegistroConsultaRepositorio : IRegistroConsultaRepositorio
    {
        //Criamos o conexto do banco de dados
        private readonly BancoContext _bancoContext;
        //Injetamos no construtor
        public RegistroConsultaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<RegistroConsultaModel> Adicionar(RegistroConsultaModel registroConsulta)
        {
            //Adicionamos uma consulta na tabela RegistrosConsultas e salvamos as alterações
            await _bancoContext.RegistrosConsultas.AddAsync(registroConsulta);
            await _bancoContext.SaveChangesAsync();

            return registroConsulta;
        }

        public async Task<bool> Apagar(int id)
        {
            //Pegamos a primeira consulta pelo ID de forma assíncrona
            RegistroConsultaModel consultaPorId = await BuscarPorId(id);
            if (consultaPorId == null)
            {
                throw new Exception($"Consulta para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Removemos do banco de dados e salvamos as alterações
            _bancoContext.RegistrosConsultas.Remove(consultaPorId);
            await _bancoContext.SaveChangesAsync();

            return true;
        }

        public async Task<RegistroConsultaModel> Atualizar(RegistroConsultaModel registroConsulta, int id)
        {
            //Pegamos a consulta pelo ID de forma assíncrona
            RegistroConsultaModel consultaPorId = await BuscarPorId(id);
            if (consultaPorId == null)
            {
                throw new Exception($"Consulta para o ID: {id} não foi encontrado no banco de dados.");
            }

            //Atualizamos os devidos campos
            consultaPorId.EstadoConsulta = registroConsulta.EstadoConsulta;
            consultaPorId.DataConsulta = registroConsulta.DataConsulta;
            consultaPorId.DataRetorno = registroConsulta.DataRetorno;
            consultaPorId.Valor = registroConsulta.Valor;
            consultaPorId.MedicoId = registroConsulta.MedicoId;
            consultaPorId.PacienteId = registroConsulta.PacienteId;
            consultaPorId.LaudoId = registroConsulta.LaudoId;
            consultaPorId.ExameId = registroConsulta.ExameId;

            //Atualizamos no banco de dados e salvamos as alterações
            _bancoContext.RegistrosConsultas.Update(consultaPorId);
            await _bancoContext.SaveChangesAsync();

            return consultaPorId;
        }

        public async Task<List<RegistroConsultaModel>> BuscarConsultaPorPacienteId(int id, StatusConsulta statusConsulta)
        {
            return await _bancoContext.RegistrosConsultas
                .Where(x => statusConsulta == 0 ? x.PacienteId == id : x.PacienteId == id && x.EstadoConsulta == statusConsulta)
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Include(x => x.Laudo)
                .Include(x => x.Exame)
                .ToListAsync();
        }

        /*
         * Retornamos a primeira consulta ou o padrão pelo ID, incluindo
         * os objetos Medico e Paciente
        */
        public async Task<RegistroConsultaModel> BuscarPorId(int id)
        {
            return await _bancoContext.RegistrosConsultas
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Include(x => x.Laudo)
                .Include(x => x.Exame)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<RegistroConsultaModel>> BuscarTodosRegistrosConsultas()
        {
            //Retornamos todas as consultas com os objetos medico e paciente
            return await _bancoContext.RegistrosConsultas
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Include(x => x.Laudo)
                .Include(x => x.Exame)
                .ToListAsync();
        }
    }
}
