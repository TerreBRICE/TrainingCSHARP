using GestionContacts.Core;
using GestionContacts.Core.Interfaces;

namespace GestionContacts.Infrastructure;

public class FakeContactRepository : IContactRepository
{
    private List<Contact> fakeContacts = new List<Contact>()
    {
        new Contact("Dorian", "Lasticot", 25, "Paris"),
        new Contact("Martin", "Corimar", 25, "Paris"),
        new Contact("Hugo", "Chevon", 25, "Paris")
    };
    public List<Contact>? GetAll()
    {
        return fakeContacts;
    }

    public Contact? GetContactById(string id)
    {
        throw new NotImplementedException();
    }

    public void Remove(Contact contact)
    {
        fakeContacts.Remove(contact);
    }

    public void Add(Contact contact)
    {
        fakeContacts.Add(contact);
    }
    
    public void Edit(string id, Contact updatedContact)
    {
       var contactToUpdate =  fakeContacts.FirstOrDefault(c => c.Id == id);
       if (contactToUpdate != null)
       {
           contactToUpdate = updatedContact;
       }
       else
       {
           throw new ArgumentException("EDIT CONTACT : Contact not found");
       }
    }
}