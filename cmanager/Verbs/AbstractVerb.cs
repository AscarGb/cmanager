using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Verbs
{
    public abstract class BaseVerb
    {
        protected readonly UserManager<IdentityUser> _userManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly ConsoleWriter _consoleWriter;
        public BaseVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _consoleWriter = consoleWriter;
        }
    }

    public abstract class AbstractVerb : BaseVerb
    {
        public AbstractVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter)
        { }
        public abstract int Execute();
    }

    public abstract class AbstractVerb<T> : BaseVerb
    {
        public AbstractVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter)
        { }
        public abstract int Execute(T opts);
    }
}