using EventManager.API.Data;
using EventManager.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o gerador de documentação (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Nossa configuração do Banco
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // A porta do Angular
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configura o Swagger (interface visual para testar)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- NOSSOS ENDPOINTS ---
app.UseCors("AllowAngular");

// app.UseHttpsRedirection(); // <--- Mantenha comentado por enquanto

// 1. Listar todos os eventos
app.MapGet("/events", async (AppDbContext db) =>
{
    return await db.Events
        .Include(e => e.Registrations) // Traz as inscrições junto (opcional)
        .ToListAsync();
});

// 2. Criar um novo evento
app.MapPost("/events", async (AppDbContext db, Event novoEvento) =>
{
    // Adiciona e salva
    db.Events.Add(novoEvento);
    await db.SaveChangesAsync();

    // Retorna código 201 (Created)
    return Results.Created($"/events/{novoEvento.Id}", novoEvento);
});

app.MapDelete("/events/{id}", (Guid id, AppDbContext db) =>
{
    var evento = db.Events.Find(id);
    if (evento == null) return Results.NotFound();

    db.Events.Remove(evento);
    db.SaveChanges();
    return Results.NoContent();
});

// 👇 NOVO: Rota para Atualizar (PUT)
app.MapPut("/events/{id}", (Guid id, Event eventoAtualizado, AppDbContext db) =>
{
    var evento = db.Events.Find(id);
    if (evento is null) return Results.NotFound();

    // Atualiza os dados
    evento.Title = eventoAtualizado.Title;
    evento.Description = eventoAtualizado.Description;
    evento.Date = eventoAtualizado.Date;
    evento.Location = eventoAtualizado.Location;

    db.SaveChanges();
    return Results.NoContent();
});

app.Run();