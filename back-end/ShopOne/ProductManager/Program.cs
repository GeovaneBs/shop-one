using Microsoft.EntityFrameworkCore;
using ProductManager.Persistence;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = Environment.GetEnvironmentVariable("ALLOWED_ORIGINS")?.Split(',') ?? new[] { "http://localhost:3000" };

builder.Services.AddCors(options =>
{
    var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()
                         // Se não encontrar, tenta a variável de ambiente
                         ?? Environment.GetEnvironmentVariable("ALLOWED_ORIGINS")?.Split(',');

    // Se nenhum valor for definido, lança uma exceção
    if (allowedOrigins == null || allowedOrigins.Length == 0)
    {
        throw new InvalidOperationException("As origens permitidas para CORS não foram definidas");
    }

    // Configura o CORS com as origens dinâmicas
    options.AddPolicy("AllowSpecificOrigin",
        corsBuilder => corsBuilder
            .WithOrigins(allowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();
app.MigrateDatabase<ProductManagerDbContext>();
app.UseCors("AllowSpecificOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
