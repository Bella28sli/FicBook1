using FicBook.Model;
using FicBook.View;
using FicBook.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FicBook.ViewModel
{
    internal class MainWindowViewModel : BindingHelper
    {
        private ObservableCollection<User> users;
        private MainWindow mainWindow;
        public MainWindowViewModel(MainWindow mainWindow) {

            UserExistsCommand = new BindableCommand(_ => UserExists());
            RegistrationOpenCommand = new BindableCommand(_ => RegistrationOpen());

            User admin = new User("admin", "1");
            users = new ObservableCollection<User>() { admin };

            this.mainWindow = mainWindow;
        }
        public MainWindowViewModel(MainWindow mainWindow, ObservableCollection<User> users)
        {

            UserExistsCommand = new BindableCommand(_ => UserExists());
            RegistrationOpenCommand = new BindableCommand(_ => RegistrationOpen());
            
            this.users = users;

            this.mainWindow = mainWindow;
        }
        public MainWindowViewModel() { }

        private string enteredName;
        public string EnteredName
        {
            get { return enteredName; }
            set { 
                enteredName = value;
                OnPropertyChanged();
            }
        }
        private string enteredPassword;
        public string EnteredPassword
        {
            get { return enteredPassword; }
            set
            {
                enteredPassword = value;
                OnPropertyChanged();
            }
        }

        #region Команды
        public BindableCommand UserExistsCommand {  get; set; }
        public BindableCommand RegistrationOpenCommand { get; set; }
        #endregion
        public void UserExists()
        {
            foreach (User item in users)
            {
                if (item.Username == enteredName)
                {
                    if (item.Password == enteredPassword) {
                        ObservableCollection<Fanfic> fanfics = SerDeser.Deserialize<ObservableCollection<Fanfic>>("\\Model\\FicBook.json");
                        SerDeser.Serialize<ObservableCollection<Fanfic>>(fanfics, "\\Model\\FicBookSorted.json");
                        FanficWindow fanficWindow = new FanficWindow(enteredName, users);
                        fanficWindow.Show();
                        mainWindow.Close();
                    }
                }
            }
        }
        public void RegistrationOpen()
        {
            RegistrationWindow registrationWindow = new RegistrationWindow(users);
            registrationWindow.Show();
            mainWindow.Close() ;
        }
    }
}
