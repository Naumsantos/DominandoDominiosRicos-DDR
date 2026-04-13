namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        public Student(string lastName, string document, string email, string firstName, object? address)
        {
            LastName = lastName;
            Document = document;
            Email = email;
            FirstName = firstName;
            Address = address;
        }

        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public object Address { get; }
        public List<Subscription> Subscriptions { get; set; }

        public void AddSubscription(Subscription subscription)
        {
            var hasActiveSubscription = Subscriptions.Any(s => s.Active);
            if (hasActiveSubscription)
                throw new Exception("You already have an active subscription.");
            Subscriptions.Add(subscription);
        }
    }
}
