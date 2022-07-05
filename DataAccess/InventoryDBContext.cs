using DataAccess.Models;
using System.Data.Entity;

namespace DataAccess
{
    public class InventoryDBContext :DbContext
    {
        public InventoryDBContext()
            :base("Server=(localdb)\\MSSQLLocalDB;Database=InventoryDB;Trusted_Connection=True;")
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
