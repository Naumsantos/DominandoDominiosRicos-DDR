using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string zipCode, string city, string state, string country, string neighborhood)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
            State = state;
            Country = country;
            Neighborhood = neighborhood;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(street, 3, "Name.FirstName", "A rua deve conter no minimo 3 caracteres.")
                .HasMinLen(zipCode, 3, "Name.LastName", "O CEP deve conter 8 caracteres.")
                );
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Neighborhood { get; set; }
    }
}
