using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Address address, Document document, string payer, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            PaidDate = DateTime.Now;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Document = document;
            Payer = payer;
            Email = email;

            AddNotifications(new Contract().Requires()
                .IsGreaterThan(Total, 0, "Payment.Total", "O total do pagamento deve ser maior que zero")
                .IsGreaterThan(TotalPaid, 0, "Payment.TotalPaid", "O total pago deve ser maior que zero")
                .IsGreaterThan(TotalPaid, Total, "Payment.TotalPaid", "O total pago deve ser maior ou igual ao total do pagamento")
                );
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Address Address { get; private set; }
        public Document Document { get; private set; }
        public string Payer { get; private set; }
        public Email Email { get; private set; }
    }
}
