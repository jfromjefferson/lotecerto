// LoteCerto.API/Program.cs

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "LoteCerto API",
        Version = "v1",
        Description = "API para gerenciamento de lotes e validades"
    });
});

var app = builder.Build();

// Configurar pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoteCerto API v1");
        c.RoutePrefix = "swagger"; // Acessível em /swagger
    });
}

// app.UseHttpsRedirection(); // Comente se estiver com problemas de SSL
app.UseAuthorization();
app.MapControllers();

app.Run();