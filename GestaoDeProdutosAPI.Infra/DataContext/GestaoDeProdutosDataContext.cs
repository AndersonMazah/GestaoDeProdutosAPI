using GestaoDeProdutosAPI.Dominio.Constantes;
using GestaoDeProdutosAPI.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProdutosAPI.Infra.DataContext
{
    public class GestaoDeProdutosDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuracoes.ConnectionString);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}