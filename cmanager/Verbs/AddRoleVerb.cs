using cmanager.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Verbs
{
    public class AddRoleVerb : AbstractVerb<AddRoleOptions>
    {
        public AddRoleVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter) { }

        public override int Execute(AddRoleOptions opts)
        {
            var user = _userManager.FindByNameAsync(opts.UserName).Result;

            if (user == null)
            {
                throw new Exception("User not found");                
            }

            foreach (var r in opts.Roles)
            {
                if (_roleManager.FindByNameAsync(r).Result == null)
                {
                    _roleManager.CreateAsync(new IdentityRole { Name = r }).GetAwaiter().GetResult();
                }
                _userManager.AddToRoleAsync(user, r).GetAwaiter().GetResult();
            }

            _consoleWriter.WriteUsers(new[] { user });

            return 0;
        }
    }
}
