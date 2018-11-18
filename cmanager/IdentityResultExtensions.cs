using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cmanager
{
    internal static class IdentityResultExtensions
    {
        public static void Check(this IdentityResult result)
        {
            if (!result.Succeeded)
            {
                throw new Exception(string.Join("; ", result.Errors.Select(a => a.Description)));
            }
        }
    }
}
