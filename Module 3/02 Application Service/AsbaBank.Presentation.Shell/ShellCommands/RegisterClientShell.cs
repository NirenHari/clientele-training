﻿using System;

using AsbaBank.Core;
using AsbaBank.Domain.Commands;

namespace AsbaBank.Presentation.Shell.ShellCommands
{
    public class RegisterClientShell : IShellCommand
    {
        public string Usage { get { return String.Format("{0} <Name> <Surname> <Phone Number>", Key); } }
        public string Key  { get { return "RegisterClient"; } }
       
        public ICommand Build(string[] args)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException(String.Format("Incorrect number of parameters. Usage is: {0}", Usage));
            }

            return new RegisterClient(args[0], args[1], args[2]);
        }
    }
}