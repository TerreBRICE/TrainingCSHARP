using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using GestionContacts.Core;
using GestionContacts.Wpf.Models;

namespace GestionContacts.Wpf.Mapping;

public class ContactMapping : Profile
{
    public ContactMapping()
    {
        CreateMap<Contact, ContactModel>().ReverseMap();
    }
    
}