using GerenciadorHospital.Application.UseCases.Convenio;
using GerenciadorHospital.Domain.Repository;
using GerenciadorHospital.Infraestructure.Data.Context;
using GerenciadorHospital.Infraestructure.Data.ORM;
using GerenciadorHospital.Infraestructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using System.Text;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("INICIANDO APLICAÇÃO");

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Contexto do Banco (SQLite para testes no banco)
//builder.Services.AddDbContext<BancoContext>(options => options.UseSqlite(configuration.GetConnectionString("DataBase")));

#region Configuração do SQL Server

builder.Services.AddEntityFrameworkSqlServer().
    AddDbContext<DatabaseContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseMS"))
);

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


builder.Services.AddControllers();

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
builder.Services.AddScoped(typeof(IRepositorioORM<>), typeof(EntityFrameworkORM<>));
builder.Services.AddScoped<IConvenio, ConvenioRepository>();

builder.Services.AddScoped<BuscarTodosConveniosUseCase>();
builder.Services.AddScoped<BuscarPorIdConvenioUseCase>();
builder.Services.AddScoped<AdicionarConvenioUseCase>();
builder.Services.AddScoped<RemoverConvenioUseCase>();
builder.Services.AddScoped<AtualizarConvenioUseCase>();

#endregion

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();
        