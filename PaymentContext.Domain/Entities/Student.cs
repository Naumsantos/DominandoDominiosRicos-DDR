using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get => _subscriptions.ToArray(); }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionsActive = false;

            foreach (var sub in Subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionsActive = true;
            }

            AddNotifications(new Contract().Requires()
                .IsFalse(hasSubscriptionsActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscriptions.Payment", "A assinatura deve ter pelo menos um pagamento"));

            //if (hasSubscriptionsActive)
            //    AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
            //else
            //    _subscriptions.Add(subscription);
        }
    }
}
