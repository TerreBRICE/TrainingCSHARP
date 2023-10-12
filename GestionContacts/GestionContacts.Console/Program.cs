using GestionContacts.Core;
using GestionContacts.Core.Services;
using GestionContacts.Infrastructure;

internal class Program
{

    private static string jsonFilePath = @"C:\Users\lebuh\Desktop\_db.json";
    private static readonly JsonContactRepository _jsonContactRepository = new JsonContactRepository(jsonFilePath);
    private static readonly ContactService contactService = new ContactService(_jsonContactRepository);

    private static void Main(string[] args)
    {

        Console.WriteLine("Hi, what do you want to do with your contacts ? ShowAll | Add | ShowOne");

        var input = Console.ReadLine();

        switch (input)
        {
            case "Add":
                AddContact();
                break;

            case "ShowAll":
                ShowAll();
                break;

            case "ShowOne":
                Console.WriteLine("Id :");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    InvalidValue("Id");
                    Console.Write("Id :");
                }
                ShowContactById(id);
                break;
        }
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


    private static void AddContact()
    {
        Console.WriteLine("Adding a new contact ...");

        var firstName = AskStringValue("First name");
        var lastName = AskStringValue("Last name");
        var age = AskIntValue("Age");
        var city = AskStringValue("City");

        Contact newContact = new Contact(_jsonContactRepository.GetAll().Count + 1, firstName, lastName, age, city);
        contactService.AddContact(newContact);

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
        List<Contact> contacts = _jsonContactRepository.GetAll();
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

    private static void ShowContactById(int id)
    {
        Console.WriteLine("Showing contact with id = " + id);
        Contact contact = contactService.GetContactById(id);

        if (contact != null)
        {
            Console.WriteLine("Prénom => " + contact.FirstName);
            Console.WriteLine("Nom => " + contact.LastName);
            Console.WriteLine("Âge => " + contact.Age);
            Console.WriteLine("Ville => " + contact.City);
            Console.WriteLine("--------------------");
        }
        else
        {
            Console.WriteLine("Contact not found...");
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
}