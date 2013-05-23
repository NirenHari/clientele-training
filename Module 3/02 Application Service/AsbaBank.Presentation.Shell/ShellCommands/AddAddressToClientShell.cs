using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsbaBank.Core;
using AsbaBank.Domain.Commands;

namespace AsbaBank.Presentation.Shell.ShellCommands
{
    public class AddAddressToClientShell: IShellCommand 
    {
        public string Usage { get { return String.Format("{0} <Client Id> <Street Number> <Street> <Postal Code> <City>", Key); } }
        public string Key { get { return "AddAddressToClient"; } }

        public ICommand Build(string[] args)
        {
            if (args.Length != 5)
            {
                throw new ArgumentException(String.Format("Incorrect number of parameters. Usage is: {0}", Usage));
            }

            return new AddAddressToClient(Convert.ToInt32(args[0]), args[1], args[2],args[3],args[4]);
        }
    }
}
