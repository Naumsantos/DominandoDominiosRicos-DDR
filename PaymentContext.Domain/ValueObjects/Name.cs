using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve conter no minimo 3 caracteres.")
                .HasMinLen(LastName, 3, "Name.LastName", "O sobrenome deve conter no minimo 3 caracteres.")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "O nome deve conter no minimo 3 caracteres."));
        }
    }
}
