using GitHubBlipAPI.Services; // Para usar IGitHubService e GitHubService
using Microsoft.AspNetCore.Builder; // Para configurar o WebApplication
using Microsoft.Extensions.DependencyInjection; // Para configurar os serviços no DI (Injeção de Dependência)

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner de DI
builder.Services.AddControllers(); // Registra os controladores

// Registra o HttpClient e o GitHubService no DI
builder.Services.AddHttpClient<IGitHubService, GitHubService>(); // Registra o HttpClient para IGitHubService

var app = builder.Build();

// Configurações do pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Mostra a página de exceções detalhadas em modo de desenvolvimento
}

app.UseRouting(); // Ativa o roteamento

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Mapeia os controladores para as rotas
});

app.Run(); // Executa o aplicativo
