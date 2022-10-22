using Microsoft.EntityFrameworkCore;
using Proyecto_Periodico.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//Conection
builder.Services.AddDbContext<DBPERIODICOContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("cadena"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Principal}/{action=Index}/{id?}");

app.Run();
