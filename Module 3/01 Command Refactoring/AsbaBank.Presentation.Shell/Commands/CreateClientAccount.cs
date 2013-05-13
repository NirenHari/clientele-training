using System;
using AsbaBank.Domain.Models;

namespace AsbaBank.Presentation.Shell.Commands
{
    public class CreateClientAccount: ICommand
    {
        public int ClientId { get; private set; }
        
        public CreateClientAccount(int clientId)
        {
            if (clientId == 0)
            {
                throw new ArgumentException("Please provide a valid client id..");
            }

            ClientId = clientId;
        }

        public void Execute()
        {
            //getting the unit of work like this is not ideal. Think of ways that we could solve this.
            var unitOfWork = Environment.GetUnitOfWork(); 
            var accountRepository = unitOfWork.GetRepository<Account>();

            try
            {
                var account = Account.OpenAccount(ClientId);
                accountRepository.Add(account);
                unitOfWork.Commit();

                Environment.Logger.Verbose("Account created for client id: {0}, account number: {1}.", account.ClientId,account.AccountNumber);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
