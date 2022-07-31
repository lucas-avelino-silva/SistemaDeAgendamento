
using Bussines.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<DataModel> Agendamentos { get; set; }
    }
}