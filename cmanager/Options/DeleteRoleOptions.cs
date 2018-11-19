using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Options
{
    [Verb("delete-role", HelpText = "Delete role")]
    public class DeleteRoleOptions
    {
        [Value(0, HelpText = "Roles", Required = true)]
        public IEnumerable<string> Roles { get; set; }
    }
}
