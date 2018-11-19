using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Verbs
{
    public abstract class AbstractUserVerb<T>
    {
        protected readonly UserManager<IdentityUser> _userManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly ConsoleWriter _consoleWriter;
        public AbstractUserVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _consoleWriter = consoleWriter;
        }

        public abstract int Execute(T opts);
    }
}