using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido!")
                );
        }

        private bool Validate()
        {
            if (Number.Length == 14 && Type == EDocumentType.CNPJ)
                return true;

            if (Number.Length == 11 && Type == EDocumentType.CPF)
                return true;
            
            return false;
        }
    }
}
