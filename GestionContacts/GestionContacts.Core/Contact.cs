﻿namespace GestionContacts.Core
{
    public class Contact
    {
        public int Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public bool IsAdult { get
            {
                return Age > 18;
            }
        }

        public Contact(int id, string firstName, string lastName, int age, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
        }
    }
}