namespace GestionContacts.Core
{
    public class Contact
    {
        public string Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public bool IsAdult { get
            {
                return Age > 18;
            }
        }

        public Contact(string firstName, string lastName, int age, string city)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
        }
        
    }
}