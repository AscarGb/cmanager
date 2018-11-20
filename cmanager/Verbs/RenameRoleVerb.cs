using cmanager.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Verbs
{
    public class RenameRoleVerb : AbstractVerb<RenameRoleOptions>
    {
        public RenameRoleVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter) { }
        public override int Execute(RenameRoleOptions opts)
        {
            var role = _roleManager.FindByNameAsync(opts.RoleName).Result;

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            role.Name = opts.NewRoleName;

            _roleManager.UpdateAsync(role).Result
                .Check();

            _consoleWriter.WriteText(string.Join(", ", _roleManager.Roles));

            return 0;
        }
    }
}
