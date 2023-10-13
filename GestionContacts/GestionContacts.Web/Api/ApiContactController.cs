using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using GestionContacts.Web.Mapping;
using GestionContacts.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionContacts.Web.Api
{
    [Route("api/contacts")]
    [ApiController]
    public class ApiContactController : ControllerBase
    {
        private readonly IContactService contactService;
        public ApiContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        // GET: api/<ApiContactController>
        [HttpGet]
        public List<ContactViewModel> Get()
        {
            List<ContactViewModel>? allContacts = contactService.GetAll().ToViewModel();
            return allContacts;
        }

        // GET api/<ApiContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiContactController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
