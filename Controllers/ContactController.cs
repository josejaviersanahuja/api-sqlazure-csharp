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

        [HttpGet(Name = "contact")]
        public IEnumerable<Contacts> Get()
        {
            return contactContext.ContactSet.ToList();
        }

        // GET contact/{id} //@TODO pasa de string a Contacts
        [HttpGet("{id}")]
        public Contacts Get(int id){
            // con linq hacemos un query
            var selectedContact = (from c in contactContext.ContactSet
                                    where c.Identificador == id
                                    select c).FirstOrDefault(); // aunq el id sea unico, seleccionamos first or default
            return selectedContact;
        }

        // POST contact
        [HttpPost]
        public IActionResult Post([FromBody] Contacts value){
            Contacts newContact = value; // lo sacamos del body del request
            contactContext.ContactSet.Add(newContact); // añadimos al contexto de la app
            contactContext.SaveChanges(); // mandamos a cambiar la base de datos

            return Ok("Nuevo contacto agregado a la BD");
        }

        // put contact
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contacts value)
        {
            Contacts updatedContact = value;
            var selectedElement = contactContext.ContactSet.Find(updatedContact.Identificador);
            selectedElement.Nombre = value.Nombre;
            selectedElement.Email = value.Email;

            contactContext.SaveChanges();
            return Ok("Se ha modificado el contacto con id " + id.ToString());
        }

        // DELETE contact
        public IActionResult Delete(int id)
        {
            var selectedElement = contactContext.ContactSet.Find(id);
            contactContext.ContactSet.Remove(selectedElement);
            contactContext.SaveChanges();

            return Ok("Se ha eliminado el Contacto con id "+ id.ToString());
        }
        // método destructor para que no evitar que el controlador genere desbordamiento de memoria al quedarse abierto.
        ~ContactController(){
            contactContext.Dispose();
        }
    }
}