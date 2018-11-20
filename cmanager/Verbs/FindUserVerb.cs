using cmanager.Options;
using CommandLine;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cmanager.Verbs
{

    public class FindUserVerb : AbstractVerb<FindUserOptions>
    {
        public FindUserVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter) { }

        override public int Execute(FindUserOptions opts)
        {
            if (opts.UserName != null)
            {
                var u = _userManager.FindByNameAsync(opts.UserName).Result;
                if (u == null)
                {
                    throw new Exception("User not found");
                }
                else
                {
                    _consoleWriter.WriteUsers(new[] { u });
                    return 0;
                }
            }
            else
            {
                if (_userManager.Users.Any())
                    _consoleWriter.WriteUsers(_userManager.Users);
            }

            return 0;
        }
    }
}
