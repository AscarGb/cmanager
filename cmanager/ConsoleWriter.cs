using ConsoleTables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cmanager
{
    public sealed class ConsoleWriter
    {
        readonly UserManager<IdentityUser> _userManager;
        public ConsoleWriter(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public void WriteUsers(IEnumerable<IdentityUser> users)
        {
            var table = new ConsoleTable("Name", "Roles", "Claims");
            foreach (var u in users)
            {
                table.AddRow(u.UserName,
                    string.Join(", ", _userManager.GetRolesAsync(u).Result),
                   string.Join(", ", _userManager.GetClaimsAsync(u).Result.Select(a => a.Type + ":" + a.Value)));
            }
            table.Write();
        }

        public void CheckResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                throw new Exception(string.Join("; ", result.Errors.Select(a => a.Description)));
            }
        }

        public void WriteText(string s)
        {
            var t = new ConsoleTable(s);
            t.Options.EnableCount = false;
            t.Write();            
        }
    }
}
