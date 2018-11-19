using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Options
{
    [Verb("delete-user", HelpText = "Delete user")]
    public class DeleteUserOptions
    {
        [Option('u', "user-name", HelpText = "User name", Required = true)]
        public string UserName { get; set; }
    }
}
