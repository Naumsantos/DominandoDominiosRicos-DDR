using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Flunt.Validations.Contract()
                .Requires()
                .IsEmail(Address, "Email.Address", "Email inválido!")
            );
        }
    }
}
