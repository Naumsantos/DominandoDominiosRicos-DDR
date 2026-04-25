using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Enttites
{
    [TestClass]
    public class StudentTests
    {
        public readonly Student _student;
        public readonly Subscription _subscription;
        public readonly Name _name;
        public readonly Document _document;
        public readonly Email _email;
        public readonly Address _address;
        public readonly PaypalPayment _payment;
        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("02102861191", EDocumentType.CPF);
            _email = new Email("bruce.wayne@example.com");
            _address = new Address("Sao Paulo", "500", "65910220", "Gotham", "NY", "USA", "Vila Lobao");
            _student = new Student(_name, _document, _email, _address);
            _subscription = new Subscription(null);
            _payment = new PaypalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 100, 100, _address, _document, "Wayne Enterprises", _email);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            _subscription.AddPayment(_payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {
            _subscription.AddPayment(_payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}