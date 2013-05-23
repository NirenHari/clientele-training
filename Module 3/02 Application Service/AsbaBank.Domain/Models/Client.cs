using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AsbaBank.Core;

namespace AsbaBank.Domain.Models
{
    public class Client
    {
        [Key]
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public List<Address> Address { get; protected set; }

        protected Client()
        {
            //here for the deserializer
        }

        public Client(string clientName, string clientSurname, string phoneNumber)
        {
            if (String.IsNullOrEmpty(clientName) || clientName.Length < 3)
            {
                throw new ArgumentException("Please provide a valid client name of at least three characters.");
            }

            if (String.IsNullOrEmpty(clientSurname) || clientSurname.Length < 3)
            {
                throw new ArgumentException("Please provide a valid client name of at least three characters.");
            }

            if (String.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length != 10 || !phoneNumber.IsDigitsOnly())
            {
                throw new ArgumentException("Please provide a valid telephone number.");
            }

            Name = clientName;
            Surname = clientSurname;
            PhoneNumber = phoneNumber;
        }
    }
}