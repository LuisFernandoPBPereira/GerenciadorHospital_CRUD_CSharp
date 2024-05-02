using GerenciadorHospital.Entities;
using GerenciadorHospital.Models;
using GerenciadorHospital.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorHospital.Data
{
    public class SeedManager
    {
        static BCryptPasswordHasher<UsuarioModel> senhaComHash = new BCryptPasswordHasher<UsuarioModel>();

        #region Seeds
        public static async Task Seed(IServiceProvider services)
        {
            await SeedRoles(services);

            await SeedAdminUser(services);
            await SeedPaciente(services);
            await SeedMedico(services);
        }
        #endregion

        #region Seeds das Roles
        private static async Task SeedRoles(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Role.Admin));
            await roleManager.CreateAsync(new IdentityRole(Role.Paciente));
            await roleManager.CreateAsync(new IdentityRole(Role.Medico));
        }
        #endregion

        #region Seed Admin
        private static async Task SeedAdminUser(IServiceProvider services)
        {
            var context = services.GetRequiredService<BancoContext>();
            var userManager = services.GetRequiredService<UserManager<UsuarioModel>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var adminUser = await context.Usuarios.FirstOrDefaultAsync(user => user.UserName == "AuthenticationAdmin");

            if (adminUser is null)
            {
                adminUser = new UsuarioModel {
                    UserName = "adminUser",
                    Nome = "adminUser",
                    Cpf = "00000000000",
                    Endereco = "tal",
                    DataNasc = DateTime.Now,
                    Senha = "Admin123*",
                    Role = Role.Admin
                };

                var senhaAdmin = senhaComHash.HashPassword(adminUser, adminUser.Senha);
                adminUser.Senha = senhaAdmin;

                await userManager.CreateAsync(adminUser, adminUser.Senha);
                await userManager.AddToRoleAsync(adminUser, Role.Admin);
            }
        }
        #endregion

        #region Seed Paciente
        private static async Task SeedPaciente(IServiceProvider services)
        {
            var context = services.GetRequiredService<BancoContext>();
            var userManager = services.GetRequiredService<UserManager<UsuarioModel>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var pacienteUser = await context.Usuarios.FirstOrDefaultAsync(user => user.UserName == "AuthenticationPaciente");

            if (pacienteUser is null)
            {
                pacienteUser = new UsuarioModel
                {
                    UserName = "pacienteUser",
                    Nome = "pacienteUser",
                    Cpf = "12345678900",
                    Endereco = "tal",
                    DataNasc = DateTime.Now,
                    Senha = "Paciente123*",
                    Role = Role.Paciente
                };

                var senhaPaciente = senhaComHash.HashPassword(pacienteUser, pacienteUser.Senha);
                pacienteUser.Senha = senhaPaciente;

                await userManager.CreateAsync(pacienteUser, pacienteUser.Senha);
                await userManager.AddToRoleAsync(pacienteUser, Role.Paciente);
            }
        }
        #endregion

        #region Seed Médico
        private static async Task SeedMedico(IServiceProvider services)
        {
            var context = services.GetRequiredService<BancoContext>();
            var userManager = services.GetRequiredService<UserManager<UsuarioModel>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var medicoUser = await context.Usuarios.FirstOrDefaultAsync(user => user.UserName == "AuthenticationMedico");

            if (medicoUser is null)
            {
                medicoUser = new UsuarioModel
                {
                    UserName = "medicoUser",
                    Nome = "medicoUser",
                    Cpf = "00000000000",
                    Endereco = "tal",
                    DataNasc = DateTime.Now,
                    Senha = "Medico123*",
                    Role = Role.Medico
                };

                var senhaMedico = senhaComHash.HashPassword(medicoUser, medicoUser.Senha);
                medicoUser.Senha = senhaMedico;

                await userManager.CreateAsync(medicoUser, medicoUser.Senha);
                await userManager.AddToRoleAsync(medicoUser, Role.Medico);
            }
        }
        #endregion
    }
}
