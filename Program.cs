using CarlosCustodio_Ap1_P2.Components;
using Microsoft.EntityFrameworkCore;
using CarlosCustodio_Ap1_P2.DAL;
using CarlosCustodio_Ap1_P2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//obtener el ConStr para usarlo en el contexto
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

//agregamos el contexto al builder con el ConStr
builder.Services.AddDbContextFactory<Contexto>(Options => Options.UseSqlServer(ConStr));

builder.Services.AddScoped<RegistroService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
