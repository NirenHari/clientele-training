using System;

namespace AsbaBank.Presentation.Shell.Commands
{
    public class CreateClientAccountShell: IShellCommand
    {
        public string Usage { get { return String.Format("{0} <Client Id>", Key); } }
        public string Key { get { return "CreateClientAccount"; } }

        public ICommand Build(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException(String.Format("Incorrect number of parameters. Usage is: {0}", Usage));
            }

            return new CreateClientAccount(Convert.ToInt32(args[0]));
        }
    }
}
