using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using GestionContacts.Core.Services;
using GestionContacts.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static IContactService? _contactService;

    public Program(IContactService contactService)
    {
        _contactService = contactService;
    }

    private static void Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();
        var program = host.Services.GetRequiredService<Program>();
        program.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "_data.json");
                services.AddTransient<IContactRepository>(_ => new JsonContactRepository(filePath));
                services.AddTransient<IContactService, ContactService>();
                services.AddTransient<Program>();
            });


    private  void Run()
    {
        Console.WriteLine("Hi, what do you want to do with your contacts? Show | Add ");

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
        _contactService.Add(newContact);

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

        List<Contact>? contacts = _contactService.GetAll();

        int totalContacts = _contactService.CountTotal();

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
