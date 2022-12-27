using GestaoDeProdutosAPI.Dominio.Entidades;
using GestaoDeProdutosAPI.Infra.DataContext;
using GestaoDeProdutosAPI.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoDeProdutosAPI.Infra.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private GestaoDeProdutosDataContext Db;
        private DbSet<Produto> DbSet;

        public ProdutoRepositorio(GestaoDeProdutosDataContext dbContext)
        {
            if (dbContext is null)
            {
                throw new Exception("Falha ao acessar o Banco de Dados.");
            }
            Db = dbContext;
            DbSet = Db.Set<Produto>();
        }

        public async Task<Produto> ObterPorCodigoAsync(int codigo)
        {
            return await DbSet.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }

        public async Task<List<Produto>> ObterTodosAsync()
        {
            List<Produto> lista = await DbSet.ToListAsync();
            return lista;
        }

        public async Task CadastrarAsync(Produto produto)
        {
            DbSet.Add(produto);
            await Db.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            DbSet.Update(produto);
            await Db.SaveChangesAsync();
        }

        public async Task DeletarAsync(Produto produto)
        {
            DbSet.Remove(produto);
            await Db.SaveChangesAsync();
        }
    }
}