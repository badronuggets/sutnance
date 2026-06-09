using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sutnance.Areas.Identity.Data;
using sutnance.Data;
using sutnance.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("sutnanceContextConnection") ?? throw new InvalidOperationException("Connection string 'sutnanceContextConnection' not found.");

builder.Services.AddDbContext<sutnanceContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<sutnanceUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<sutnanceContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<MachineManager, MachineManager>();

var app = builder.Build();

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
// seeding data

using (var scope = app.Services.CreateScope())
{
    var machineManager = scope.ServiceProvider
        .GetRequiredService<MachineManager>();
    await machineManager.SeedAsync();
}
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
