#pragma warning disable SA1200 // Using directives should be placed correctly
using LingonberryStudio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LingonberryStudio.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LingonberryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LingonberryConnectionString")));

builder.Services.AddDbContext<LingonberryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LingonberryIdentityContextConnection")));

builder.Services.AddDefaultIdentity<LingonberryUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LingonberryIdentityContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    using (var appContext = scope.ServiceProvider.GetRequiredService<LingonberryDbContext>())
    {
        try
        {
            //appContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    var services = scope.ServiceProvider;
    try
    {
        Seed.Initialize(services);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        throw;
    }
}

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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