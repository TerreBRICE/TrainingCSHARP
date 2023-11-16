
using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using GestionContacts.Core.Services;
using GestionContacts.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GestionContacts.Console.UseCases;

internal class Program
{ 
  private static  string jsonFilePathKey = "filePath";

    private static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var services = new ServiceCollection();
        ConfigureServices(services, configuration);
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        Run(serviceProvider);
    }

    private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
    {
        var jsonRepositoryOptions = configuration.GetSection(JsonRepositoryOptions.Key).Get<JsonRepositoryOptions>();
        services.AddTransient<IContactRepository>(_ => new JsonContactRepository(jsonRepositoryOptions));
        services.AddTransient<IContactService, ContactService>();
        services.AddSingleton<IConfiguration>(_ => configuration);
    }


    private static void Run(IServiceProvider serviceProvider)
    {
        var addContact = new AddContact(serviceProvider);
        var showAll = new ShowAll(serviceProvider);
        Console.WriteLine("Hi, what do you want to do with your contacts? Show | Add ");

        var input = Console.ReadLine();

        switch (input)
        {
            case "Add":
                addContact.Execute();
                break;

            case "Show":
                showAll.Execute();
                break;
        }
    }



 
}