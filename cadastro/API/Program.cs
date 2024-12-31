using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using API.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do SQLite no contexto de banco de dados
builder.Services.AddDbContext<CadastroContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));  // Usando SQLite

// Adicionando os serviços necessários
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Cadastro",
        Version = "v1",
        Description = "Uma API para gerenciar cadastros de clientes."
    });
});

// Configura o CORS para permitir o frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin() // Permite qualquer origem (não recomendado em produção)
                         .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
                         .AllowAnyHeader()); // Permite qualquer cabeçalho
});

var app = builder.Build();

// Habilitando o Swagger e o Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Cadastro v1");
        c.RoutePrefix = string.Empty;  // Acessível em "/"
    });
}

// Habilita o CORS antes do middleware de roteamento
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();