using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Options
{
    [Verb("create-role", HelpText = "Create role")]
    public  class CreateRoleOptions
    {
        [Value(0, HelpText = "Role name", Required = true)]
        public string RoleName { get; set; }
    }
}
