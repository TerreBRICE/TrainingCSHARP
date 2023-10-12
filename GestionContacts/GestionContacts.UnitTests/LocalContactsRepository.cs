using GestionContacts.Core;
using GestionContacts.Core.Interfaces;

namespace GestionContacts.UnitTests;

public class LocalContactsRepository: IContactRepository
{

    public List<Contact> Contacts = new List<Contact>()
    {
        new Contact(1,"Didier", "Costa",24, "Rennes"),
        new Contact(2, "Dorian", "Molotov",14, "Paris"),
        new Contact(3, "Paul", "Soyer",48, "Grenoble"),
        new Contact(4, "Eloïse", "Fortin",25, "Rennes"),
    };


    public List<Contact> GetAll()
    {
        return Contacts;
    }

    public Contact? GetContactById(int id)
    {
       return Contacts.Find(c => c.Id == id);
    }

    public void Remove(int id)
    {
        Contact? item = Contacts.Find(c => c.Id == id);
        Contacts.Remove(item);
    }

    public void Add(Contact contact)
    {
        Contacts.Add(contact);
    }


}
