﻿using GestaoDeProdutosAPI.Dominio.Constantes;
using GestaoDeProdutosAPI.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeProdutosAPI.Infra.DataContext
{
    public class GestaoDeProdutosDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=GestaoProdutos;User Id=sa;Password=1q2w3e4r@#$;");
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}