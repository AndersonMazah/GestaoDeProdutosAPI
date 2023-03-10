using GestaoDeProdutosAPI.Aplicacao.Extensions;
using GestaoDeProdutosAPI.Dominio.Constantes;
using GestaoDeProdutosAPI.Infra.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Configuracoes.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddExtensionInfra();
builder.Services.AddExtensionAplicacao();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
