using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace cmanager.Options
{
    [Verb("add-user", HelpText = "Add new user, roles, claims")]
    public class AddUserOptions
    {
        [Option('u', "user-name", HelpText = "User name", Required = true)]
        public string UserName { get; set; }

        [Option('r', "role-names", HelpText = "Roles", Required = true)]
        public IEnumerable<string> Roles { get; set; }

        [Option('p', "password", HelpText = "Password", Required = true)]
        public string UserPassword { get; set; }

        [Option('m', "user-email", HelpText = "Email")]
        public string UserEMail { get; set; }

        [Option('h', "user-phone", HelpText = "Phone")]
        public string UserPhone { get; set; }

        [Option('c', "claims", HelpText = "Claims")]
        public IEnumerable<string> Claims { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Example", new AddUserOptions
                {
                    UserName = "Tom",
                    Roles = new[] { "User", "Admin", "NewRole" },
                    UserPassword = "123!@#qweQWE",
                    Claims = new[] {
                       "Name:Tomas",
                       "City:Ufa",
                    },
                    UserPhone = "+79171234567"
                });
            }
        }
    }
}
