using GestionContacts.Core;
using GestionContacts.Infrastructure;

namespace GestionContacts.IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {

        private readonly InfrastructureService _infrastructureService;


        [TestMethod]
        public void WhenGetAllContacts_ShouldNewContactExistInJsonRepository()
        {
            _infrastructureService.GetAll();

            Assert.AreEqual(0, _infrastructureService.GetAll().Count);
        }

   /*     [TestMethod]
        public void WhenGetContactWithId1_ShouldGetContactWithFirstNameDidier()
        {
            Contact? contact = _infrastructureService.GetContact(1);

            Assert.AreEqual("Didier", contact.FirstName);
        }

        [TestMethod]
        public void WhenAddNewContact_ShouldNewContactExistInJsonRepository() 
        {
            Contact newContact = new Contact(1, "Eloïse", "Fortin", 25, "Rennes");

            _infrastructureService.AddContact(newContact);

            CollectionAssert.Contains(_infrastructureService.GetAll(), newContact);
            Assert.AreEqual(1, _infrastructureService.GetAll().Count);
        }

        [TestMethod]
        public void WhenRemoveContact_ShouldNewContactDoesntExistInJsonRepository()
        {
            Contact newContact = new Contact(1, "Eloïse", "Fortin", 25, "Rennes");

            _infrastructureService.AddContact(newContact);

            CollectionAssert.DoesNotContain(_infrastructureService.GetAll(), newContact);
            Assert.AreEqual(0, _infrastructureService.GetAll().Count);
        }*/
    }
}