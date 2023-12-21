using System.Windows;
using System.Windows.Controls;
using AutoMapper;
using GestionContacts.Core.Services;
using GestionContacts.Infrastructure;
using GestionContacts.Wpf.Mapping;
using GestionContacts.Wpf.ViewModels;

namespace GestionContacts.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContactMapping>();
            });
            var mapper = config.CreateMapper();

            InitializeComponent(); 
            MainViewModel mainViewModel = new MainViewModel(new ContactService(new FakeContactRepository()), mapper);

            this.DataContext = mainViewModel;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}