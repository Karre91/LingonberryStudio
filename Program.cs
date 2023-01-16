using LingonberryStudio.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LingonberryDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("LingonberryConnectionString")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	using (var appContext = scope.ServiceProvider.GetRequiredService<LingonberryDbContext>())
	{
		try
		{
			appContext.Database.Migrate();
		}
		catch (Exception ex)
		{
			//Log errors or do anything you think it's needed
			throw;
		}
	}

	var services = scope.ServiceProvider;
	if (app.Environment.IsDevelopment())
	{
		try
		{
			//Seed.Initialize(services);
		}
		catch (Exception ex)
		{
			//Log errors or do anything you think it's needed
			throw;
		}
	}
}

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	//app.UseExceptionHandler("/Home/Error");
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