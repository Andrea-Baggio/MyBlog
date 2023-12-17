using Microsoft.Extensions.Hosting;
using MyBlog.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

//Seeder
using(var ctx = new BlogContext())
{
    ctx.Seed();
}

app.Run(); //qua viene eseguita l'app e lanciato il server, sopra sono solo configurazioni
