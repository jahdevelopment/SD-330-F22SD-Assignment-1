using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SD_330_F22SD_Assignment_1.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpotifyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpotifyContext") ?? throw new InvalidOperationException("Connection string 'SpotifyContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;

    await SeedData.Inittialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
