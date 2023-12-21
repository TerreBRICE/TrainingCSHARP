using GestionContacts.Core;
using GestionContacts.Core.Interfaces;

namespace GestionContacts.UnitTests;

public class LocalContactsRepository: IContactRepository
{

    public List<Contact> Contacts = new List<Contact>()
    {
        new Contact("Didier", "Costa",24, "Rennes"),
        new Contact( "Dorian", "Molotov",14, "Paris"),
        new Contact( "Paul", "Soyer",48, "Grenoble"),
        new Contact( "Eloïse", "Fortin",25, "Rennes"),
    };


    public List<Contact>? GetAll()
    {
        return Contacts;
    }

    public Contact? GetContactById(string id)
    {
        throw new NotImplementedException();
    }

    public void Remove(Contact contact)
    {
        throw new NotImplementedException();
    }

    public void Edit(string id, Contact updatedContact)
    {
        throw new NotImplementedException();
    }

    public Contact? GetContactById(int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(string id)
    {
        Contact? item = Contacts.Find(c => c.Id == id);
        Contacts.Remove(item);
    }

    public void Add(Contact contact)
    {
        Contacts.Add(contact);
    }


}
