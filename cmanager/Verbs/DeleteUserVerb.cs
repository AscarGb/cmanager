using cmanager.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Verbs
{
    public class DeleteUserVerb : AbstractVerb<DeleteUserOptions>
    {
        public DeleteUserVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter) { }

        override public int Execute(DeleteUserOptions opts)
        {
            var u = _userManager.FindByNameAsync(opts.UserName).Result;
            if (u == null)
            {
                _consoleWriter.WriteText("Not found");
                return 1;
            }

            var result = _userManager.DeleteAsync(u).Result;
            _consoleWriter.WriteUsers(new[] { u });
            return 0;
        }
    }
}
