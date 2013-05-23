using System;
using AsbaBank.Core;
using AsbaBank.Domain.Commands;

namespace AsbaBank.Presentation.Shell
{
    public class FetchClientShell : IShellCommand
    {
        public string Usage { get { return String.Format("{0} <Id>", Key); } }
        public string Key { get { return "FetchClient"; } }
       

        public ICommand Build(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException(String.Format("Incorrect number of parameters. Usage is: {0}", Usage));
            }

            return new FetchClient(Convert.ToInt32(args[0]));
        }
    }
}