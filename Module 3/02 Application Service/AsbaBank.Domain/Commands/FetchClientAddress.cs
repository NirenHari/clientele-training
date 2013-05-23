using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsbaBank.Core;

namespace AsbaBank.Domain.Commands
{
    public class FetchClientAddress:ICommand
    {
        public int ClientId { get; set; }

        public FetchClientAddress(int clientId)
        {
            ClientId = clientId;
        }
    }
}
