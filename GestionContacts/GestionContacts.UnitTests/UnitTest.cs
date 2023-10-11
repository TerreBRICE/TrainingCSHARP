using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using GestionContacts.Core.Services;

namespace GestionContacts.UnitTests
{
    [TestClass]
    public class UnitTest
    {
        static IContactRepository localContactsRepository = new LocalContactsRepository();
        ContactService contactService = new ContactService(localContactsRepository);

        [TestMethod]
        public void WhenCountTotal_ShouldHave4()
        {
            var total = contactService.CountTotal();

            Assert.AreEqual(4, total);
        }

        [TestMethod]
        public void WhenCountFromCityRennes_ShouldHave2()
        {

            var countCity = contactService.CountFromCity("Rennes");

            Assert.AreEqual(2, countCity);
        }

        [TestMethod]
        public void WhenCountIsAdult_ShouldHave3()
        {

            var countIsAdult = contactService.CountIsAdult();

            Assert.AreEqual(3, countIsAdult);
        }
    }
}