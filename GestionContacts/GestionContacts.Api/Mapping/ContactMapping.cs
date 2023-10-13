using GestionContacts.Api.DTO;
using GestionContacts.Core;

namespace GestionContacts.Api.Mapping
{
    public class ContactMapping
    {
        public static ContactDTO MappingIntoDTOContact(Contact contact)
        {
            return new ContactDTO(
                id: contact.Id,
               firstName: contact.FirstName,
               lastName: contact.LastName,
               age: contact.Age,
               city: contact.City
               );
        }


        public static Contact MappingIntoContact(ContactDTO contactDTO)
        {
            return new Contact(
                firstName: contactDTO.FirstName,
                lastName: contactDTO.LastName,
                age: contactDTO.Age,
                city: contactDTO.City
                 );
        }
    }

    public static class ListExtensions
    {
        public static List<ContactDTO> ToDTO(this List<Contact> allContacts)
        {


            List<ContactDTO> allContactViewModel = new List<ContactDTO>();

            foreach (var contact in allContacts)
            {
                allContactViewModel.Add(ContactMapping.MappingIntoDTOContact(contact));
            }

            return allContactViewModel;

        }
    }
}
