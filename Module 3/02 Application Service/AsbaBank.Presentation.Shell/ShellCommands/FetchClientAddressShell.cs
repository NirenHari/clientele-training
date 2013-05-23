using System;
using AsbaBank.Core;
using AsbaBank.Domain.Commands;

namespace AsbaBank.Presentation.Shell.ShellCommands
{
    public class FetchClientAddressShell: IShellCommand
    {
        public string Usage { get { return String.Format("{0} <Client Id>", Key); } }
        public string Key { get { return "FetchClientAddress"; } }


        public ICommand Build(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException(String.Format("Incorrect number of parameters. Usage is: {0}", Usage));
            }

            return new FetchClientAddress(Convert.ToInt32(args[0]));
        }
    }
}
