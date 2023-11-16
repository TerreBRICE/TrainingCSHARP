using GestionContacts.Console.Helpers;
using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GestionContacts.Console.UseCases;

public class AddContact
{
    private readonly IServiceProvider _serviceProvider;

    public AddContact(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Execute()
    {
        var textConsoleGenerator = new TextConsoleGenerator();
        System.Console.WriteLine("Adding a new contact ...");

        var firstName = textConsoleGenerator.AskStringValue("First name");
        var lastName = textConsoleGenerator.AskStringValue("Last name");
        var age = textConsoleGenerator.AskIntValue("Age");
        var city = textConsoleGenerator.AskStringValue("City");

        Contact newContact = new Contact(firstName, lastName, age, city);
        _serviceProvider.GetRequiredService<IContactService>().Add(newContact);

         System.Console.WriteLine("-----CREATION-------");

         System.Console.WriteLine("Prénom => " + newContact.FirstName);
         System.Console.WriteLine("Nom => " + newContact.LastName);
         System.Console.WriteLine("Âge => " + newContact.Age);
         System.Console.WriteLine("Ville => " + newContact.City);

         System.Console.WriteLine("--------------------");
    }
}