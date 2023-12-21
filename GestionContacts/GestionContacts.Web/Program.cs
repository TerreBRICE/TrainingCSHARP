using GestionContacts.Core.Interfaces;
using GestionContacts.Core.Services;
using GestionContacts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var jsonRepositoryOptions = configuration.GetSection(JsonRepositoryOptions.Key).Get<JsonRepositoryOptions>();

builder
    .Services
    .AddScoped<IContactService,ContactService>();

builder
    .Services
    .AddScoped<IContactRepository,JsonContactRepository>((_) => new JsonContactRepository(jsonRepositoryOptions));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
