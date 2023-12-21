using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContacts.Core.Interfaces
{
    public interface IContactService
    {
        int CountTotal();

        int CountFromCity(string city);
        int CountIsAdult();
        Contact? ShowContactById(int id);
        void Remove(Contact contact);
        void Add(Contact contact);
        void Edit(string id, Contact contact);
        List<Contact>? GetAll();

    }
}
