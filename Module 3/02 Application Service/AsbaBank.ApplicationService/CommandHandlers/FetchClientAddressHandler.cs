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
    public class FetchClientAddressHandler:IHandleCommand<FetchClientAddress>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILog logger;

        public FetchClientAddressHandler(IUnitOfWork unitOfWork, ILog logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public void Execute(FetchClientAddress command)
        {
            var addressRepository = unitOfWork.GetRepository<Address>();

            try
            {
                var addresses = addressRepository.Where(a => a.ClientId == command.ClientId).AsEnumerable();

                logger.Verbose(" Client Address: \n");
                foreach (var address in addresses)
                {
                    logger.Verbose(" Street Number: {0} \n Street: {1} \n Postal Code: {2} \n City: {3} \n", address.StreetNumber, address.Street,
                               address.PostalCode, address.City);
                }
                
            }
            catch(Exception ex)
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
