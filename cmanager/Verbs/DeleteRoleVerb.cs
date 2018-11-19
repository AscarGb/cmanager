using cmanager.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Verbs
{
    public class DeleteRoleVerb : AbstractVerb<DeleteRoleOptions>
    {
        public DeleteRoleVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter) { }
        public override int Execute(DeleteRoleOptions opts)
        {
            foreach (var r in opts.Roles)
            {
                var role = _roleManager.FindByNameAsync(r).Result;
                if (role != null)
                {
                    _roleManager.DeleteAsync(role).Result
                        .Check();
                }
            }
            _consoleWriter.WriteText(string.Join(", ", _roleManager.Roles));
            return 0;
        }
    }
}
