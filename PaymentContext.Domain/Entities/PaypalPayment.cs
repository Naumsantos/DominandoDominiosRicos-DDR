using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(
                            string transactionCode,
                            DateTime paidDate, 
                            DateTime expireDate, 
                            decimal total, 
                            decimal totalPaid, 
                            Address address, 
                            Document document, 
                            string payer) : base(paidDate, expireDate, total, totalPaid, address, document, payer)
        {
            TransactionCode = transactionCode;
        }
        public string? TransactionCode { get; private set; }
    }
}
