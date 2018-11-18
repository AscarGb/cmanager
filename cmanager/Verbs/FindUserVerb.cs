using cmanager.Options;
using CommandLine;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cmanager.Verbs
{

    public class FindUserVerb
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly ConsoleWriter _consoleWriter;
        public FindUserVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _consoleWriter = consoleWriter;
        }
        public int FindUser(FindUserOptions opts)
        {
            if (opts.UserName != null)
            {
                var u = _userManager.FindByNameAsync(opts.UserName).Result;
                if (u == null)
                {
                    _consoleWriter.WriteText("Not found");
                    return 1;
                }
                else
                {
                    _consoleWriter.WriteUsers(new []{ u });
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
