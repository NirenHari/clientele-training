using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsbaBank.Core;

namespace AsbaBank.Domain.Commands
{
    public class FetchClient : ICommand
    {
        public int Id { get; set; }

        public FetchClient(int id)
        {
            Id = id;
        }
    }
}
