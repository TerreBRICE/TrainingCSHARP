using GestionContacts.Core;
using GestionContacts.Core.Interfaces;

namespace GestionContacts.UnitTests;

public class LocalContactsRepository: IContactRepository
{

    public List<Contact> Contacts = new List<Contact>()
    {
        new Contact("Didier", "Costa",24, "Rennes"),
        new Contact("Dorian", "Molotov",14, "Paris"),
        new Contact("Paul", "Soyer",48, "Grenoble"),
        new Contact("Eloïse", "Fortin",25, "Rennes"),
    };


    public List<Contact> GetAll()
    {
        return Contacts;
    }
}
