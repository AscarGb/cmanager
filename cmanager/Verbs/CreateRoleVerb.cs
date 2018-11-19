using cmanager.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Verbs
{
    public class CreateRoleVerb : AbstractVerb<CreateRoleOptions>
    {
        public CreateRoleVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter) { }

        public override int Execute(CreateRoleOptions opts)
        {
            _roleManager.CreateAsync(new IdentityRole { Name = opts.RoleName }).GetAwaiter().GetResult()
                .Check();

            _consoleWriter.WriteText(string.Join(", ", _roleManager.Roles));

            return 0;
        }
    }
}