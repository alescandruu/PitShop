using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PitShop.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages((options =>
{
    options.Conventions.AuthorizeFolder("/Cars");
    options.Conventions.AuthorizeFolder("/Bookings");
    options.Conventions.AuthorizeFolder("/Mechanics");
}));
builder.Services.AddDbContext<PitShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PitShopContext") ?? throw new InvalidOperationException("Connection string 'PitShopContext' not found.")));
builder.Services.AddDbContext<PitShopIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PitShopContext") ?? throw new InvalidOperationException("Connection string 'PitShopContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PitShopIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
