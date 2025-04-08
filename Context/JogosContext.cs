using Microsoft.EntityFrameworkCore;
using Projeto_Jogos.Domains;

namespace Projeto_Jogos.Context
{
    public class JogosContext : DbContext
    {
        //Método construtor tem o mesmo nome da classe:
        public JogosContext() { }
        public JogosContext(DbContextOptions<JogosContext> options) : base(options)
        {

        }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = NOTE43-S28\\SQLEXPRESS; Database=Jogos; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true");
            }
        }
    }
}
