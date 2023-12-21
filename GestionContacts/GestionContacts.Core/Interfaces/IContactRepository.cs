namespace GestionContacts.Core.Interfaces
{
    public interface IContactRepository
    {
        List<Contact>? GetAll();

        Contact? GetContactById(string id);
        void Remove(Contact contact);

        void Edit(string id, Contact updatedContact);

        void Add(Contact contact);
    }
}