using System.ComponentModel.DataAnnotations;
namespace api_sqlazure_csharp.Models
{
    public class Contacts 
    {
        [Key]
        public int Identificador { get; set;}
        
        public string Nombre { get; set;}
        
        public string Email { get; set;}
        
        public string Telefono { get; set;}
    }
}