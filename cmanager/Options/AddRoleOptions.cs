using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Options
{
    [Verb("add-role", HelpText = "Add role to user")]
    public class AddRoleOptions
    {
        [Value(0, HelpText = "User name", Required = true)]
        public string UserName { get; set; }

        [Value(1, HelpText = "Roles", Required = true)]
        public IEnumerable<string> Roles { get; set; }
    }
}
