using Microsoft.EntityFrameworkCore;
using WebApi8.Models;

namespace WebApi8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<AluguelLivroModel> AluguelLivros { get; set; }
    }

}
