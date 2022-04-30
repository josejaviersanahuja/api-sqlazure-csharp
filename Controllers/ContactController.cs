using Microsoft.AspNetCore.Mvc;
using api_sqlazure_csharp.Models;

namespace api_sqlazure_csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : Controller 
    {
        private ContactsContext contactContext;

        public ContactController(ContactsContext context)
        {
            contactContext = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Contacts> Get()
        {
            return contactContext.ContactSet.ToList();
        }

        // método destructor para que no evitar que el controlador genere desbordamiento de memoria al quedarse abierto.
        ~ContactController(){
            contactContext.Dispose();
        }
    }
}