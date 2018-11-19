using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Options
{
    [Verb("find-user", HelpText = "Search user")]
    public class FindUserOptions
    {
        [Value(0, HelpText = "User name")]
        public string UserName { get; set; }
    }
}
