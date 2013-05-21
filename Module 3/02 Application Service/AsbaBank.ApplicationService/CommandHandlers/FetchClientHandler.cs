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
    public class FetchClientHandler:IHandleCommand<FetchClient>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILog logger;

        public FetchClientHandler(IUnitOfWork unitOfWork, ILog logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public void Execute(FetchClient command)
        {
            var clientRepository = unitOfWork.GetRepository<Client>();

            try
            {
                var client = clientRepository.Get(command.Id);
              
                logger.Verbose("Fetch client {0}\n FirstName: {1} \n Surname: {2} \n Cell Number: {3}", client.Id,client.Name,client.Surname,client.PhoneNumber );
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
