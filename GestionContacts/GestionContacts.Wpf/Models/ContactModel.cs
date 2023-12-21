using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestionContacts.Wpf.Models;

public class ContactModel : INotifyPropertyChanged
{
    private string id;
    public string Id;
    private string firstName;
    private string lastName;
    private int age;
    private string city;
    public event PropertyChangedEventHandler? PropertyChanged;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            firstName = value;
            OnPropertyChanged(nameof(firstName));
        }
    }
    
    public string LastName
    {
        get { return lastName; }
        set
        {
            lastName = value;
            OnPropertyChanged(nameof(lastName));
        }
    }
    
    public int Age
    {
        get { return age; }
        set
        {
            age = value;
            OnPropertyChanged(nameof(age));
        }
    }
    
    public string City
    {
        get { return city; }
        set
        {
            city = value;
            OnPropertyChanged(nameof(city));
        }
    }
    


    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}