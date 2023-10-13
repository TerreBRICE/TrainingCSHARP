namespace GestionContacts.Api.DTO
{
    public class ContactDTO
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }


        public ContactDTO(string id, string firstName, string lastName, int age, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
        }

        public ContactDTO()
        {

        }
    }
}
