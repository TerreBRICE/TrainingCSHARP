using GestionContacts.Core;
using GestionContacts.Infrastructure;
using System.Text.Json;

namespace GestionContacts.IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        private static string jsonFilePath = @"C:\Users\lebuh\Desktop\_db.json";

        private readonly JsonContactRepository _jsonContactRepository = new JsonContactRepository(jsonFilePath);


        [TestMethod]
        public void WhenGetAllContacts_ShouldGet1Contact()
        {
            _jsonContactRepository.GetAll();

            Assert.AreEqual(1, _jsonContactRepository.GetAll().Count);
        }

        [TestMethod]
        public void WhenGetContactById_ShouldGetContactFirstNameDorian()
        {
            Contact contact = _jsonContactRepository.GetContactById(1);

            Assert.AreEqual("Dorian", contact.FirstName);
        }

        [TestMethod]
        public void WhenAddNewContact_ShouldNewContactExistInJsonRepository()
        {
            List<Contact> emptyContactsList = new List<Contact>();
            string tempFilePath = Path.GetTempFileName() + ".json";
            string jsonString = JsonSerializer.Serialize(emptyContactsList);
            File.WriteAllText(tempFilePath, jsonString);

            JsonContactRepository _tempJsonContactRepository = new JsonContactRepository(tempFilePath);

            Contact newContact = new Contact(1, "Didier", "Costa", 24, "Rennes");
            _tempJsonContactRepository.Add(newContact);

            Assert.AreEqual(1, _tempJsonContactRepository.GetAll().Count);

        }
}
}