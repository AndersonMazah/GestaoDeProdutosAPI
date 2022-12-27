using GestaoDeProdutosAPI.Dominio.Entidades;
using GestaoDeProdutosAPI.Infra.DataContext;
using GestaoDeProdutosAPI.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoDeFornecedorsAPI.Infra.Repositorios
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private GestaoDeProdutosDataContext Db;
        private DbSet<Fornecedor> DbSet;

        public FornecedorRepositorio(GestaoDeProdutosDataContext dbContext)
        {
            if (dbContext is null)
            {
                throw new Exception("Falha ao acessar o Banco de Dados.");
            }
            Db = dbContext;
            DbSet = Db.Set<Fornecedor>();
        }

        public async Task<Fornecedor> ObterPorCodigoAsync(int codigo)
        {
            return await DbSet.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }

        public async Task<List<Fornecedor>> ObterTodosAsync()
        {
            List<Fornecedor> lista = await DbSet.ToListAsync();
            return lista;
        }

        public async Task CadastrarAsync(Fornecedor fornecedor)
        {
            DbSet.Add(fornecedor);
            await Db.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Fornecedor fornecedor)
        {
            DbSet.Update(fornecedor);
            await Db.SaveChangesAsync();
        }

        public async Task DeletarAsync(Fornecedor fornecedor)
        {
            DbSet.Remove(fornecedor);
            await Db.SaveChangesAsync();
        }
    }
}