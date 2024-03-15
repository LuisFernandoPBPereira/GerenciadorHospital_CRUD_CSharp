
using GerenciadorHospital.Data;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GerenciadorHospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {   
                c.SwaggerDoc("v1", new OpenApiInfo
                {

                });
                var xmlFile = "GerenciadorHospital.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            }); 

            //Configuramos o EntityFramework
            builder.Services.AddEntityFrameworkSqlServer().
                AddDbContext<BancoContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            //Configuramos as injeções de dependências para podermos acessar a controller
            builder.Services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
            builder.Services.AddScoped<IConvenioRepositorio, ConvenioRepositorio>();
            builder.Services.AddScoped<IMedicoRepositorio, MedicoRepositorio>();
            builder.Services.AddScoped<IMedicamentosPacienteRepositorio, MedicamentoPacienteRepositorio>();
            builder.Services.AddScoped<IRegistroConsultaRepositorio, RegistroConsultaRepositorio>();
            builder.Services.AddScoped<ILaudoRepositorio, LaudoRepositorio>();
            builder.Services.AddScoped<ITipoExameRepositorio, TipoExameRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
