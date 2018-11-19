using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Options
{
    [Verb("rename-role", HelpText = "Rename role")]
    public class RenameRoleOptions
    {
        [Value(0, HelpText = "Role name", Required = true)]
        public string RoleName { get; set; }

        [Value(1, HelpText = "Role new name", Required = true)]
        public string NewRoleName { get; set; }
    }
}
