namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscriptions;

        public Student(string lastName, string document, string email, string firstName, object? address)
        {
            LastName = lastName;
            Document = document;
            Email = email;
            FirstName = firstName;
            Address = address;
            _subscriptions = new List<Subscription>();
        }

        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public object Address { get; }
        public IReadOnlyCollection<Subscription> Subscriptions { get => _subscriptions.ToArray(); }

        public void AddSubscription(Subscription subscription)
        {
            foreach (var sub in Subscriptions)
                sub.ActiveSubscription();

            _subscriptions.Add(subscription);
        }
    }
}
