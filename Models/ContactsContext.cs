using Microsoft.EntityFrameworkCore;

namespace api_sqlserver_csharp.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contacts> ContactSet {get; set;}
    }
}