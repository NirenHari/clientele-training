using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsbaBank.Core;


namespace AsbaBank.Domain.Commands
{
    public class AddAddressToClient: ICommand
    {
        public int Id { get; protected set; }
        public int ClientId { get; private set; }
        public string StreetNumber { get; protected set; }
        public string Street { get; protected set; }
        public string PostalCode { get; protected set; }
        public string City { get; protected set; }

        public AddAddressToClient(int clientId, string streetNumber, string street, string postalCode, string city)
        {
            if (String.IsNullOrEmpty(streetNumber))
            {
                throw new ArgumentException("Please provide a valid Street number.");
            }
            if (String.IsNullOrEmpty(street))
            {
                throw new ArgumentException("Please provide a valid street name.");
            }
            if (String.IsNullOrEmpty(postalCode) || postalCode.Length != 4 || !postalCode.IsDigitsOnly())
            {
                throw new ArgumentException("Please provide a valid postal code.");
            }
            if (String.IsNullOrEmpty(city))
            {
                throw new ArgumentException("Please provide a valid city name.");
            }

            ClientId = clientId;
            StreetNumber = streetNumber;
            Street = street;
            PostalCode = postalCode;
            City = city;
        }
    }
}
