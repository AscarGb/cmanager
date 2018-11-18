using cmanager.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cmanager.Verbs
{
    public class UpdateUserVerb
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly ConsoleWriter _consoleWriter;
        public UpdateUserVerb(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ConsoleWriter consoleWriter)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _consoleWriter = consoleWriter;
        }

        public int UpdateUser(UpdateUserOptions opts)
        {
            if (opts.Claims.Any())
                ClaimsHelper.Check(opts.Claims);

            IdentityUser user = _userManager.FindByNameAsync(opts.UserName).Result;

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (opts.NewUserName != null)
            {
                user.UserName = opts.NewUserName;
                _userManager.UpdateAsync(user).Result
                    .Check();
            }

            if (opts.UserEmail != null)
            {
                user.Email = opts.UserEmail;
                _userManager.UpdateAsync(user).Result
                    .Check();
            }

            if (opts.UserPhone != null)
            {
                user.Email = opts.UserPhone;
                _userManager.UpdateAsync(user).Result
                    .Check();
            }

            if (opts.UserPassword != null)
            {
                var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                _userManager.ResetPasswordAsync(user, token, opts.UserPassword).Result
                    .Check();
            }

            if (opts.Roles != null && opts.Roles.Any())
            {
                _userManager.RemoveFromRolesAsync(user, _userManager.GetRolesAsync(user).Result).Result
                    .Check();

                foreach (var r in opts.Roles)
                {
                    if (_roleManager.FindByNameAsync(r).Result == null)
                    {
                        _roleManager.CreateAsync(new IdentityRole { Name = r }).GetAwaiter().GetResult()
                            .Check();
                    }
                    _userManager.AddToRoleAsync(user, r).GetAwaiter().GetResult()
                        .Check();
                }
            }

            if (opts.Claims != null && opts.Claims.Any())
            {
                _userManager.RemoveClaimsAsync(user, _userManager.GetClaimsAsync(user).Result)
                    .Result
                    .Check();

                _userManager.AddClaimsAsync(user, ClaimsHelper.Parse(opts.Claims))
                    .GetAwaiter().GetResult()
                    .Check();
            }


            _consoleWriter.WriteUsers(new[] { user });

            return 0;
        }
    }
}
