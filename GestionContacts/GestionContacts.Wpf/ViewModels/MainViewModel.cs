using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AutoMapper;
using GestionContacts.Console.UseCases;
using GestionContacts.Core;
using GestionContacts.Core.Interfaces;
using GestionContacts.Wpf.Commands;
using GestionContacts.Wpf.Models;
using GestionContacts.Wpf.Views;


namespace GestionContacts.Wpf.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ObservableCollection<ContactModel> Contacts { get; set; }

    private ContactModel _selectedContact;

    public ContactModel SelectedContact
    {
        get { return _selectedContact; }
        set
        {
            _selectedContact = value;
            OnPropertyChanged(nameof(SelectedContact));
        }
    }

    private IContactService _contactService;
    private IMapper _mapper;

    public MainViewModel(IContactService contactService, IMapper mapper)
    {
        _contactService = contactService;
        _mapper = mapper;
        GetContacts();

        SelectedContact = new ContactModel() { FirstName = "", LastName = "", Age = 0, City = "" };
        Contacts.Add(SelectedContact);
    }

    private ICommand resetSelectedContact = new RelayCommand<ContactModel>(model =>
    {
        model.FirstName = "";
        model.LastName = "";
        model.Age = 0;
        model.City = "";
    });

    public ICommand ResetSelectedContact
    {
        get { return resetSelectedContact; }
    }

    private ICommand addContact;

    public ICommand AddContact
    {
        get
        {
            if (addContact == null)
            {
                addContact = new RelayCommand<object>((_) => CreateContact());
            }

            return addContact;
        }
    }

    private ICommand modifyContact;

    public ICommand ModifyContact
    {
        get
        {
            if (modifyContact == null)
            {
                modifyContact = new RelayCommand<object>(model => EditContact());
            }

            return modifyContact;
        }
    }

    private ICommand removeContact;

    public ICommand RemoveContact
    {
        get
        {
            if (removeContact == null)
            {
                removeContact = new RelayCommand<object>(model => DeleteContact());
            }

            return removeContact;
        }
    }

    private void GetContacts()
    {
        Contacts = _mapper.Map<ObservableCollection<ContactModel>>(_contactService.GetAll());
    }

    private void CreateContact()
    {
        SelectedContact = new ContactModel() { FirstName = "-", LastName = "-", Age = 0, City = "-" };
        Contacts.Add(SelectedContact);
        var newContact = _mapper.Map<Contact>(SelectedContact);
        _contactService.Add(newContact);
        GetContacts();
    }

    private void EditContact()
    {
        var updatedContact = _mapper.Map<Contact>(SelectedContact);
        _contactService.Edit(SelectedContact.Id, updatedContact);
        GetContacts();
    }


    private void DeleteContact()
    {
        var contactToRemove = _mapper.Map<Contact>(SelectedContact);
        _contactService.Remove(contactToRemove);
        GetContacts();
    }


    private bool CanAddContact(object obj)
    {
        return true;
    }


    public event PropertyChangedEventHandler? PropertyChanged;


    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}