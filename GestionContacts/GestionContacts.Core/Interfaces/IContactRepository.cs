namespace GestionContacts.Core.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAll();

        Contact? GetContactById(int id);
        void Remove(int id);

        void Add(Contact contact);
    }
}