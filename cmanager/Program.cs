using System;
using System.IO;
using cmanager.Options;
using cmanager.Verbs;
using CommandLine;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cmanager
{
    class Program
    {
        static int Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext<IdentityUser>>()
                .AddDefaultTokenProviders();

            services.AddTransient<AddUserVerb>();
            services.AddTransient<UpdateUserVerb>();
            services.AddTransient<FindUserVerb>();
            services.AddSingleton<ConsoleWriter>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var dbType = configuration.GetSection("DbType").Get<string>();

            switch (dbType)
            {
                case "MsSql":
                    services.AddDbContext<IdentityDbContext<IdentityUser>>(options => options.UseSqlServer(connectionString));
                    break;
                case "MySql":
                    services.AddDbContext<IdentityDbContext<IdentityUser>>(options => options.UseMySql(connectionString));
                    break;
            }

            var provider = services.BuildServiceProvider();

            try
            {
                return Parser.Default.ParseArguments<AddUserOptions,
                    UpdateUserOptions, FindUserOptions>(args)
                    .MapResult(
                    (AddUserOptions opts) => provider.GetService<AddUserVerb>().AddNewUser(opts),
                    (UpdateUserOptions opts) => provider.GetService<UpdateUserVerb>().UpdateUser(opts),
                    (FindUserOptions opts) => provider.GetService<FindUserVerb>().FindUser(opts),
                    errs => 1);
            }
            catch (Exception e)
            {
                provider.GetService<ConsoleWriter>().WriteText(e.Message);
                return 1;
            }
        }
    }
}
