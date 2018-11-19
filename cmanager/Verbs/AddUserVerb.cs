using cmanager.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace cmanager.Verbs
{
    public class AddUserVerb : AbstractVerb<AddUserOptions>
    {
        public AddUserVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter) : base(userManager, roleManager, consoleWriter) { }

        override public int Execute(AddUserOptions opts)
        {
            if (opts.Claims.Any())
                ClaimsHelper.Check(opts.Claims);


            IdentityUser user = new IdentityUser { UserName = opts.UserName };

            _userManager.CreateAsync(user, opts.UserPassword).GetAwaiter().GetResult()
                .Check();

            foreach (var r in opts.Roles)
            {
                if (_roleManager.FindByNameAsync(r).Result == null)
                {
                    _roleManager.CreateAsync(new IdentityRole { Name = r }).GetAwaiter().GetResult();
                }
                _userManager.AddToRoleAsync(user, r).GetAwaiter().GetResult();
            }

            if (opts.Claims != null && opts.Claims.Any())
            {
                _userManager.AddClaimsAsync(user, ClaimsHelper.Parse(opts.Claims))
                    .GetAwaiter().GetResult()
                    .Check();
            }

            if (opts.UserEMail != null)
                user.Email = opts.UserEMail;

            if (opts.UserPhone != null)
                user.PhoneNumber = opts.UserPhone;

            _userManager.UpdateAsync(user).Result
                .Check();

            _consoleWriter.WriteUsers(new[] { user });

            return 0;
        }
    }
}