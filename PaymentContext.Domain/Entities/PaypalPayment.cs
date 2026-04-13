namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public string TransactionCode { get; private set; }
    }
}
