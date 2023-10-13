namespace GestionContacts.Core.Interfaces
{
    public interface IContactRepository
    {
        List<Contact>? GetAll();

        Contact? GetContactById(string id);
        void Remove(string id);

        void Add(Contact contact);
    }
}