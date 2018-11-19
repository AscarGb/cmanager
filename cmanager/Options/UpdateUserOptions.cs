using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Options
{
    [Verb("update-user", HelpText = "Update user")]
    public class UpdateUserOptions
    {
        [Value(0, HelpText = "User name", Required = true)]
        public string UserName { get; set; }

        [Option('r', "role-names", HelpText = "New Roles")]
        public IEnumerable<string> Roles { get; set; }

        [Option('p', "password", HelpText = "New Password")]
        public string UserPassword { get; set; }

        [Option('n', "new-name", HelpText = "New user name")]
        public string NewUserName { get; set; }

        [Option('m', "user-email", HelpText = "New Email")]
        public string UserEmail { get; set; }

        [Option('h', "user-phone", HelpText = "New Phone")]
        public string UserPhone { get; set; }

        [Option('c', "claims", HelpText = "New Claims")]
        public IEnumerable<string> Claims { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Example", new UpdateUserOptions
                {
                    UserName = "Tom",
                    NewUserName = "Bob",
                    Roles = new[] { "User", "Admin", "NewRole" },
                    UserPassword = "NewPassword!@#123",
                    Claims = new[] {
                       "Name:Bobby",
                       "City:New York",
                    },
                    UserPhone = "+7917999988"
                });
            }
        }
    }
}
