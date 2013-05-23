using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsbaBank.Core;
using AsbaBank.Domain.Commands;
using AsbaBank.Domain.Models;

namespace AsbaBank.ApplicationService.CommandHandlers
{
    public class AddAddressToClientHandler: IHandleCommand<AddAddressToClient>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILog logger;

        public AddAddressToClientHandler(IUnitOfWork unitOfWork, ILog logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public void Execute(AddAddressToClient command)
        {
            var AddressReposity = unitOfWork.GetRepository<Address>();

            try
            {
                var address = new Address(command.ClientId, command.StreetNumber, command.Street,command.PostalCode,command.City);
                AddressReposity.Add(address);
                unitOfWork.Commit();

                logger.Verbose("Address added to client id {0}.", address.Id);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
