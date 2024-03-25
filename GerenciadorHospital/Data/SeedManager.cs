using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Data
{
    public class SeedManager
    {
        public static async Task Seed(IServiceProvider services)
        {
            await SeedRoles(services);

            await SeedAdminUser(services);
            await SeedPaciente(services);
            await SeedMedico(services);
        }

        private static async Task SeedRoles(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Role.Admin));
            await roleManager.CreateAsync(new IdentityRole(Role.Paciente));
            await roleManager.CreateAsync(new IdentityRole(Role.Medico));
        }

        private static async Task SeedAdminUser(IServiceProvider services)
        {
            var context = services.GetRequiredService<BancoContext>();
            var userManager = services.GetRequiredService<UserManager<UsuarioModel>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var adminUser = await context.Usuarios.FirstOrDefaultAsync(user => user.UserName == "AuthenticationAdmin");

            if (adminUser is null)
            {
                adminUser = new UsuarioModel { 
                    UserName = "your@email.com", 
                    Nome = "Teste",
                    Cpf = "12345678900",
                    Endereco = "tal",
                    DataNasc = DateTime.Now,
                    Senha = "blabla"
                };
                await userManager.CreateAsync(adminUser, "VerySecretPassword!1");
                await userManager.AddToRoleAsync(adminUser, Role.Admin);
            }
        }

        private static async Task SeedPaciente(IServiceProvider services)
        {
            var context = services.GetRequiredService<BancoContext>();
            var userManager = services.GetRequiredService<UserManager<UsuarioModel>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var adminUser = await context.Usuarios.FirstOrDefaultAsync(user => user.UserName == "AuthenticationPaciente");

            if (adminUser is null)
            {
                adminUser = new UsuarioModel
                {
                    UserName = "your@email.com",
                    Nome = "Teste",
                    Cpf = "12345678900",
                    Endereco = "tal",
                    DataNasc = DateTime.Now,
                    Senha = "blabla"
                };
                await userManager.CreateAsync(adminUser, "VerySecretPassword!1");
                await userManager.AddToRoleAsync(adminUser, Role.Paciente);
            }
        }

        private static async Task SeedMedico(IServiceProvider services)
        {
            var context = services.GetRequiredService<BancoContext>();
            var userManager = services.GetRequiredService<UserManager<UsuarioModel>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var adminUser = await context.Usuarios.FirstOrDefaultAsync(user => user.UserName == "AuthenticationMedico");

            if (adminUser is null)
            {
                adminUser = new UsuarioModel
                {
                    UserName = "your@email.com",
                    Nome = "Teste",
                    Cpf = "12345678900",
                    Endereco = "tal",
                    DataNasc = DateTime.Now,
                    Senha = "blabla"
                };
                await userManager.CreateAsync(adminUser, "VerySecretPassword!1");
                await userManager.AddToRoleAsync(adminUser, Role.Medico);
            }
        }
    }
}
