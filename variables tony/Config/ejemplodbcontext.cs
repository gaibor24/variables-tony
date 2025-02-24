using Microsoft.EntityFrameworkCore;
using variables.Models;

namespace variables.Config
{
    public class ejemplodbcontext:DbContext
    {
        public ejemplodbcontext(DbContextOptions contexto):base(contexto) {}


        public DbSet<ClienteModel> Clientes { get; set; }
    }
}
