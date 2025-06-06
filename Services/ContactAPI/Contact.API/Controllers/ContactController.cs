using Contact.API.Infrastructure;
using Contact.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly IContactService contactService;
        public ContactController(IContactService ContactService)
        {
            contactService = ContactService;
        }

        [HttpGet("{Id}")]
        public ContactDTO Get(int Id) 
        { 
            return contactService.GetContactById(Id);
        }
        
    }
}
