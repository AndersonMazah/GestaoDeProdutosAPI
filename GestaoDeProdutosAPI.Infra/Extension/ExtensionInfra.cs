using GestaoDeFornecedorsAPI.Infra.Repositorios;
using GestaoDeProdutosAPI.Infra.DataContext;
using GestaoDeProdutosAPI.Infra.Interfaces;
using GestaoDeProdutosAPI.Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeProdutosAPI.Infra.Extension
{
    public static class ExtensionInfra
    {
        public static IServiceCollection AddExtensionInfra(this IServiceCollection services)
        {
            services.AddDbContext<GestaoDeProdutosDataContext>(ServiceLifetime.Transient);

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();

            return services;
        }
    }
}
