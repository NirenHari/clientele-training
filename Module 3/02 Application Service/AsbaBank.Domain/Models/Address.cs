using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AsbaBank.Domain.Models
{
    public class Address
    {
        [Key]
        public int Id { get; protected set; }
        public string StreetNumber { get; protected set; }
        public string Street { get; protected set; }
        public string PostalCode { get; protected set; }
        public string City { get; protected set; }

        public int ClientId { get; protected set; }
        public Client Client { get; protected set; }

        protected Address()
        {
            //here for the deserializer
        }

        public Address(int clientId, string streetNumber, string street, string postalCode, string city)
        {
            ValidateInput("street number", streetNumber);
            ValidateInput("street", street);
            ValidateInput("postal code", postalCode);
            ValidateInput("city", city);

            ClientId = clientId;
            StreetNumber = streetNumber;
            Street = street;
            PostalCode = postalCode;
            City = city;
        }

        private void ValidateInput(string parameterName, string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(String.Format("Please provide a valid {0}.", parameterName));
            }
        }

        
    }
}