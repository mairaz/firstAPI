using firstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options)
            : base(options)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
        
    }
}