using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using GestionContacts.Core.Services;
using GestionContacts.Infrastructure;
using GestionContacts.Web.Mapping;
using GestionContacts.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionContacts.Web.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }


        // GET: ContactController
        public ActionResult Index()
        {
            List<Contact>? allContacts = contactService.GetAll();
            var allContactsViewModel = new ListContactViewModel() { Contacts = allContacts.ToViewModel(), Title = "Mes Contacts" };

            return View(allContactsViewModel);
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View(new ContactViewModel());
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactViewModel contactViewModel)
        {
            // Map into Contact
            if (ModelState.IsValid)
            {
                Contact newContact = ContactMapping.MappingIntoContact(contactViewModel);
                try
                {
                    contactService.Add(newContact);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
