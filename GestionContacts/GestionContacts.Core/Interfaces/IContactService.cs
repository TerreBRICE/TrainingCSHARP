using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContacts.Core.Interfaces
{
    interface IContactService
    {
        int CountTotal();

        int CountFromCity(string city);
    }
}
