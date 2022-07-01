//using Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Limpeza> Limpezas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Heroku Config
        //"Server=us-cdbr-east-05.cleardb.net;User Id=b4a4154b57bdb4;Database=heroku_96f4f1c4546dac0;Pwd=b857f5e2"

        // Local Config
        //"Server=localhost;User Id=root;Database=encryptme"
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql("Server=localhost;User Id=root;Database=hotel");
    }
}