
using GerenciadorHospital.Data;
using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using NLog;
using NLog.Web;
using GerenciadorHospital.Utils;
using GerenciadorHospital.Services.Consulta;
using GerenciadorHospital.Services.Convenio;
using GerenciadorHospital.Services.Exame;
using GerenciadorHospital.Services.Laudo;
using GerenciadorHospital.Services.Medicamento;
using GerenciadorHospital.Services.Medico;
using GerenciadorHospital.Services.Paciente;
using GerenciadorHospital.Services.Usuario;
using GerenciadorHospital.Repositorios.Convenio;
using GerenciadorHospital.Repositorios.Laudo;
using GerenciadorHospital.Repositorios.Medicamento;
using GerenciadorHospital.Repositorios.Medico;
using GerenciadorHospital.Repositorios.Paciente;
using GerenciadorHospital.Repositorios.Consulta;
using GerenciadorHospital.Repositorios.Exame;
using GerenciadorHospital.Data.ORM;
using Microsoft.Extensions.DependencyInjection;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("INICIANDO APLICAÇÃO");

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Contexto do Banco (SQLite para testes no banco)
//builder.Services.AddDbContext<BancoContext>(options => options.UseSqlite(configuration.GetConnectionString("DataBase")));

#region Configuração do SQL Server
// Configuramos o EntityFramework

builder.Services.AddEntityFrameworkSqlServer().
    AddDbContext<BancoContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseMS"))
);

#endregion

#region Configuração do Identity
// Configurando a adição do Identity
builder.Services.AddIdentity<UsuarioModel, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<BancoContext>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<BancoContext>()
    .AddDefaultTokenProviders();
#endregion

#region Configuração da Autenticação (JWT)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    #region Adicionando o JWT
    // Adição do JWT
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            RequireExpirationTime = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!)),
            ClockSkew = TimeSpan.Zero
        };
    });
#endregion
#endregion

#region Configuração de Autorização (Políticas e Roles)
// Adicionando políticas para travar os endpoints
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy =>
        policy.RequireRole(Role.Admin));
    options.AddPolicy("AdminAndDoctorRights", policy =>
        policy.RequireRole(Role.Admin, Role.Medico));
    options.AddPolicy("StandardRights", policy =>
        policy.RequireRole(Role.Admin, Role.Paciente, Role.Medico));
});
#endregion

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gerenciador de Hospital", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autorização JWT usando o esquema Bearer. \r\n\r\nInsira 'Bearer' [space] e seu token logo em seguida.\r\n\r\n Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
    });
#endregion

#region Configuração das Injeções de Dependência (adição do escopo)
//Configuramos as injeções de dependências para podermos acessar a controller
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IRegistroConsultaService, RegistroConsultaService>();
builder.Services.AddScoped<IConvenioService, ConvenioService>();
builder.Services.AddScoped<ITipoExameService, TipoExameService>();
builder.Services.AddScoped<ILaudoService, LaudoService>();
builder.Services.AddScoped<IMedicamentosService, MedicamentosService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
builder.Services.AddScoped<IConvenioRepositorio, ConvenioRepositorio>();
builder.Services.AddScoped<IMedicoRepositorio, MedicoRepositorio>();
builder.Services.AddScoped<IMedicamentosPacienteRepositorio, MedicamentoPacienteRepositorio>();
builder.Services.AddScoped<IRegistroConsultaRepositorio, RegistroConsultaRepositorio>();
builder.Services.AddScoped<ILaudoRepositorio, LaudoRepositorio>();
builder.Services.AddScoped<ITipoExameRepositorio, TipoExameRepositorio>();
builder.Services.AddScoped<IPasswordHasher<UsuarioModel>, BCryptPasswordHasher<UsuarioModel>>();
builder.Services.AddScoped(typeof(IRepositorioORM<>), typeof(EntityFrameworkORM<>));
#endregion

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

// Criamos o escopo das nossas seeds
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await SeedManager.Seed(services);
}

app.Run();
        