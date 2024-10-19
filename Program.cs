using ControleDeContatos.Data;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ControleDeContatos.Repositorio;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);


builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
