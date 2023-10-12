using GestionContacts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContacts.Core.Services;

public class ContactService
{

    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public int CountTotal()
    {
        return _contactRepository.GetAll().Count;
    }

    public int CountFromCity(string city)
    {
        var count = 0;
        foreach (Contact contact in _contactRepository.GetAll())
        {
            if (contact.City == city)
                count++;
        }
        return count;
    }

    public int CountIsAdult()
    {
        var count = 0;
        foreach (Contact contact in _contactRepository.GetAll())
        {
            if (contact.Age > 18)
                count++;
        }
        return count;
    }

    public Contact? GetContactById(int id)
    {
        Contact? item = _contactRepository.GetContactById(id);
        return item;
    }

    public void RemoveContactById(int id)
    {
        _contactRepository.Remove(id);

    }

    public void AddContact(Contact contact)
    {
        _contactRepository.Add(contact);
    }
}
