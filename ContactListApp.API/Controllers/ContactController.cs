using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactListApp.BAL.Features;
using ContactListApp.BAL.Features.Interfaces;
using ContactListApp.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactListApp.API.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> GetContactsAsync()
        {
            var contacts = await _contactService.GetAllContactAsync();
            return Ok(contacts);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(Guid id)
        {
            var contact = await _contactService.GetContactById(id);
            return Ok(contact);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Contact contact)
        {
            var _contact = await _contactService.AddContactAsync(contact);
            return Ok(_contact);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] Contact contact)
        {
            await _contactService.UpdateContactAsync(contact);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _contactService.DeleteContactAsync(id);
            return Ok();
        }
    }
}

