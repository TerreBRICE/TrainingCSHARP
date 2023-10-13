using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace GestionContacts.Infrastructure;

public class JsonContactRepository : IContactRepository
{
    private string _filePath;

    public JsonContactRepository(string jsonFilePath)
    {
        _filePath = jsonFilePath;
    }


    public List<Contact>? GetAll()
    {
        string jsonString = File.ReadAllText(_filePath);
        //TODO: CHeck if file empty
        return JsonSerializer.Deserialize<List<Contact>>(jsonString);

    }

    public Contact? GetContactById(string id)
    {
        List<Contact>? contacts = GetAll();
        if (contacts != null)
            return contacts.Find(c => c.Id == id);
        return null;
    }
    public void Add(Contact contact)
    {
        List<Contact> contacts = GetAll();
        contacts.Add(contact);
        string jsonString = JsonSerializer.Serialize(contacts);
        File.WriteAllText(_filePath, jsonString);

    }
    public void Remove(string id)
    {

    }














}