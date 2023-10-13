using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using GestionContacts.Core.Services;
using GestionContacts.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class Program
{


    private static string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "_data.json");
    private static readonly JsonContactRepository _jsonContactRepository = new JsonContactRepository(jsonFilePath);
    private static readonly ContactService contactService = new ContactService(_jsonContactRepository);

    private static void Main(string[] args)
    {

        //    var serviceProvider = new ServiceCollection()
        //.AddLogging()
        //.AddScoped<IContactService, ContactService>()
        //.AddScoped<IContactRepository, JsonContactRepository>((_) => new JsonContactRepository(configuration["JsonRepository:filePath"]))
        //.BuildServiceProvider();

        //       configure console logging
        //       serviceProvider
        //           .GetService<ILoggerFactory>()
        //            .AddConsole(LogLevel.Debug);

        //var logger = serviceProvider.GetService<ILoggerFactory>()
        //    .CreateLogger<Program>();
        //logger.LogDebug("Starting application");

        Console.WriteLine(jsonFilePath);
        Console.WriteLine("Hi, what do you want to do with your contacts ? Show | Add ");

        var input = Console.ReadLine();

        switch (input)
        {
            case "Add":
                AddContact();
                break;

            case "Show":
                ShowAll();
                break;

        }
    }

    private static void AddContact()
    {
        Console.WriteLine("Adding a new contact ...");

        var firstName = AskStringValue("First name");
        var lastName = AskStringValue("Last name");
        var age = AskIntValue("Age");
        var city = AskStringValue("City");

        Contact newContact = new Contact(firstName, lastName, age, city);
        contactService.Add(newContact);

        Console.WriteLine("-----CREATION-------");

        Console.WriteLine("Prénom => " + newContact.FirstName);
        Console.WriteLine("Nom => " + newContact.LastName);
        Console.WriteLine("Âge => " + newContact.Age);
        Console.WriteLine("Ville => " + newContact.City);

        Console.WriteLine("--------------------");
    }

    private static void ShowAll()
    {
        Console.WriteLine("Showing all contacts ...");

        List<Contact>? contacts = _jsonContactRepository.GetAll();

        int totalContacts = contactService.CountTotal();

        Console.WriteLine("---------  You Have " + totalContacts + " contacts  ---------");
        foreach (Contact contact in contacts)
        {
            Console.WriteLine("Prénom => " + contact.FirstName);
            Console.WriteLine("Nom => " + contact.LastName);
            Console.WriteLine("Âge => " + contact.Age);
            Console.WriteLine("Ville => " + contact.City);
            Console.WriteLine("--------------------");
        }
    }


    private static void InvalidValue(string value)
    {
        Console.WriteLine("You entered an invalid " + value);
    }
    private static string AskStringValue(string question)
    {
        Console.WriteLine(question + " :");
        var output = Console.ReadLine();
        if (string.IsNullOrEmpty(output))
        {
            InvalidValue(question);
            Console.Write(question + " :");
            output = Console.ReadLine();
        }

        return output;
    }

    private static int AskIntValue(string question)
    {
        Console.WriteLine(question + " :");
        int output;
        while (!int.TryParse(Console.ReadLine(), out output))
        {
            InvalidValue(question);
            Console.Write(question + " :");
        }

        return output;
    }
}