using AutoMapper;
using GestaoDeFornecedorsAPI.Aplicacao.Services;
using GestaoDeProdutosAPI.Aplicacao.DTOs;
using GestaoDeProdutosAPI.Aplicacao.Interfaces;
using GestaoDeProdutosAPI.Aplicacao.Services;
using GestaoDeProdutosAPI.Dominio.Entidades;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeProdutosAPI.Aplicacao.Extensions
{
    public static class ExtensionAplicacao
    {
        public static IServiceCollection AddExtensionAplicacao(this IServiceCollection service)
        {
            service.AddScoped<IProdutoAplicacao, ProdutoAplicacao>();
            service.AddScoped<IFornecedorAplicacao, FornecedorAplicacao>();

            MapperConfiguration config = new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoDto, Produto>().ReverseMap();
                config.CreateMap<FornecedorDto, Fornecedor>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            service.AddSingleton(mapper);
            return service;
        }
    }
}
