using Microsoft.EntityFrameworkCore;
using RegistroAsignaturas.Components;
using RegistroAsignaturas.DAL;
using RegistroAsignaturas.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Obtengo el ConStr para usarlo en el contexto
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

// Agrego el contexto al builder con el ConStr
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

// Inyección del service para Asignaturas
builder.Services.AddScoped<AsignaturasService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();



