﻿using System.Collections.Generic;

using AsbaBank.ApplicationService.CommandHandlers;
using AsbaBank.Core;
using AsbaBank.Infrastructure;
using AsbaBank.Presentation.Shell.ShellCommands;

namespace AsbaBank.Presentation.Shell
{
    public static class Environment
    {
        private static readonly BankContext DataStore;
        public static readonly ILog Logger;
        private static readonly Dictionary<string, IShellCommand> ShellCommands; 
        
        static Environment()
        {
            DataStore = new BankContext("Bank");
            Logger = new ConsoleWindowLogger();
            ShellCommands = new Dictionary<string, IShellCommand>();
            RegisterCommands();
        }

        public static IEnumerable<IShellCommand> GetShellCommands()
        {
            return ShellCommands.Values;
        }

        public static IShellCommand GetShellCommand(string key)
        {
            return ShellCommands[key];
        }

        private static void RegisterCommands()
        {
            RegisterCommand(new RegisterClientShell());   
            RegisterCommand(new FetchClientShell());
            RegisterCommand(new AddAddressToClientShell());
            RegisterCommand(new FetchClientAddressShell());
        }

        private static void RegisterCommand(IShellCommand command)
        {
            ShellCommands.Add(command.Key, command);
        }

        public static IPublishCommands GetCommandPublisher()
        {
            var commandPublisher = new LocalCommandPublisher();
            var unitOfWork = new UnitOfWork(DataStore);

            commandPublisher.Subscribe(new RegisterClientHandler(unitOfWork, Logger));
            commandPublisher.Subscribe(new FetchClientHandler(unitOfWork, Logger));
            commandPublisher.Subscribe(new AddAddressToClientHandler(unitOfWork, Logger));
            commandPublisher.Subscribe(new FetchClientAddressHandler(unitOfWork, Logger));
            return commandPublisher;
        }
    }
}