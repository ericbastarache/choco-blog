using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtApi.netcore.Data;
using JwtApi.netcore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JwtApi.netcore.Helpers
{
    public class Init
    {
        public static async Task CreateRoles(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roles = { "Admin", "Blogger", "Moderator" };
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    UserName = "Cynical",
                    Email = "cynical89@gmail.com",
                    FirstName = "Tony",
                    LastName = "M"
                },
                new ApplicationUser
                {
                    UserName = "Ericb",
                    Email = "eric_bastarache@hotmail.com",
                    FirstName = "Eric",
                    LastName = "B"
                }
            };

            foreach (var role in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            const string password = "Password123!";

            foreach (var x in users)
            {
                var user = await userManager.FindByEmailAsync(x.Email);
                if (user == null)
                {
                    var result = await userManager.CreateAsync(x, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(x, "Admin");
                        await userManager.AddToRoleAsync(x, "Blogger");
                        await userManager.AddToRoleAsync(x, "Moderator");
                    }
                }
            }
        }

        public static void HandleDatabaseChoices(IServiceCollection services, IConfiguration configuration)
        {
            var database = Environment.GetEnvironmentVariable("ASPNETCORE_DATABASE");

            if (string.IsNullOrEmpty(database))
            {
                /**
                 * This is where we configure the database without args. If we didn't add an argument for
                 * the database, and we haven't set the evironment variable, You can choose here what
                 * The server will use. Sql Server is the default. You will also want to let it set the
                 * environment variable for the appropriate database for configuring the context
                */

                // SQL Server -- Comment out these lines if you'd like to not use SQL Server

                //services.AddEntityFrameworkSqlServer().AddDbContext<AppDbContext>(options =>
                //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                //Environment.SetEnvironmentVariable("ASPNETCORE_DATABASE", "MSSQL");

                // MySQL -- Uncomment to use Entity Framework with MySql

                //services.AddEntityFrameworkMySql().AddDbContext<AppDbContext>(options =>
                //    options.UseMySql(configuration.GetConnectionString("MySqlConnection")));
                //Environment.SetEnvironmentVariable("ASPNETCORE_DATABASE", "MYSQL");

                //PostgreSQL -- Uncomment to use Entity Framework with PostgreSQL

                services.AddEntityFrameworkNpgsql().AddEntityFrameworkMySql().AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("NpgSqlConnection")));
                Environment.SetEnvironmentVariable("ASPNETCORE_DATABASE", "NPGSQL");

                return;
            }

            switch (database)
            {
                case "MSSQL":
                    services.AddEntityFrameworkSqlServer().AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                    break;
                case "MYSQL":
                    services.AddEntityFrameworkMySql().AddDbContext<AppDbContext>(options =>
                        options.UseMySql(configuration.GetConnectionString("MySqlConnection")));
                    break;
                case "NPGSQL":
                    services.AddEntityFrameworkNpgsql().AddEntityFrameworkMySql().AddDbContext<AppDbContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("MySqlConnection")));
                    break;
            }
        }
    }
}
