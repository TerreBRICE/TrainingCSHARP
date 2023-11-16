using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GestionContacts.Console.UseCases;

public class ShowAll
{
    private readonly IServiceProvider _serviceProvider;

    public ShowAll(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Execute()
    {
        
         System.Console.WriteLine("Showing all contacts ...");


        List<Contact>? contacts = _serviceProvider.GetRequiredService<IContactService>().GetAll();

        int totalContacts = _serviceProvider.GetRequiredService<IContactService>().CountTotal();

         System.Console.WriteLine("---------  You Have " + totalContacts + " contacts  ---------");
        foreach (Contact contact in contacts)
        {
             System.Console.WriteLine("Prénom => " + contact.FirstName);
             System.Console.WriteLine("Nom => " + contact.LastName);
             System.Console.WriteLine("Âge => " + contact.Age);
             System.Console.WriteLine("Ville => " + contact.City);
             System.Console.WriteLine("--------------------");
        }
    }
}