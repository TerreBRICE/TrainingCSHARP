using GestionContacts.Core;
using GestionContacts.Web.ViewModels;

namespace GestionContacts.Web.Mapping
{
    public class ContactMapping
    {
        public static ContactViewModel MappingIntoViewModelContact(Contact contact)
        {
            return new ContactViewModel(
                id: contact.Id,
               firstName: contact.FirstName,
               lastName: contact.LastName,
               age: contact.Age,
               city: contact.City
               );
        }


        public static Contact MappingIntoContact(ContactViewModel contactViewModel)
        {
            return new Contact(
                firstName: contactViewModel.FirstName,
                lastName: contactViewModel.LastName,
                age: contactViewModel.Age,
                city: contactViewModel.City
                 );
        }
    }

    public static class ListExtensions
    {
        public static List<ContactViewModel> ToViewModel(this List<Contact> allContacts)
        {


            List<ContactViewModel> allContactViewModel = new List<ContactViewModel>();

            foreach (var contact in allContacts)
            {
                allContactViewModel.Add(ContactMapping.MappingIntoViewModelContact(contact));
            }

            return allContactViewModel;

        }
    }
}
