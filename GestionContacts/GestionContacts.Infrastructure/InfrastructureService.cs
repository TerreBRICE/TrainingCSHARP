using GestionContacts.Core;
using System.Text.Json;

namespace GestionContacts.Infrastructure
{
    public class InfrastructureService
    {
        public InfrastructureService() { }
        public static void SaveDataToJsonFile(string fileName, object data)
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, jsonString);
        }
        public static T LoadDataFromJsonFile<T>(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            T data = JsonSerializer.Deserialize<T>(jsonString);
            return data;
        }

        public List<Contact> GetAll()
        {
           return LoadDataFromJsonFile<List<Contact>>("_data.json");
        }
/*        public Contact? GetContact(int contactId) { }*/
        public void AddContact(Contact contact)
        {
            SaveDataToJsonFile("_data.json", contact);
        }
        public void RemoveContact(Contact contact) { }

    }
}