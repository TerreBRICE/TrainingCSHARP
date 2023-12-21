using GestionContacts.Api.DTO;
using GestionContacts.Api.Mapping;
using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using GestionContacts.Core.Services;
using GestionContacts.Infrastructure;
using Microsoft.OpenApi.Writers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var jsonRepositoryOptions = configuration.GetSection(JsonRepositoryOptions.Key).Get<JsonRepositoryOptions>();
        
        builder
            .Services
            .AddScoped<IContactService, ContactService>();

        builder
            .Services
            .AddScoped<IContactRepository, JsonContactRepository>((_) => new JsonContactRepository(jsonRepositoryOptions));

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();


        app.MapGet("/contacts", (IContactService contactService) =>
            {
                List<Contact>? contacts = contactService.GetAll();
                return contacts.ToDTO();
            })
            .WithName("GetContacts");

        app.MapPost("/contacts", (IContactService contactService, ContactDTO contactDTO) =>
            {
                Contact newContact = ContactMapping.MappingIntoContact(contactDTO);
                contactService.Add(newContact);

                return Results.Created($"/contacts/{newContact.Id}", newContact);
            })
            .WithName("PostContact");

        app.Run();
    }
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}