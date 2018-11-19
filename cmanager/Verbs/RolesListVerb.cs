using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Verbs
{
    public class RolesListVerb : AbstractVerb
    {
        public RolesListVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter) { }

        public override int Execute()
        {
            _consoleWriter.WriteText(string.Join(", ", _roleManager.Roles));
            return 0;
        }
    }
}
