var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy.WithOrigins("https://pruebareact-frontend-shk5.vercel.app")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        // .AllowCredentials() // descomenta sólo si el frontend envía cookies/autenticación
                        );
});

var app = builder.Build();

// CORS debe ir antes de mapear controllers
app.UseCors("AllowReact");

// Registrar controllers siempre (fuera del bloque de Development)
if (app.Environment.IsDevelopment())
{
    // opcional: swagger, etc.
}

// Mapear controladores en todos los entornos
app.MapControllers();

// app.UseHttpsRedirection(); // opcional

app.Run();