using FicBook.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FicBook.ViewModel;
using System.Collections.ObjectModel;
using FicBook.Model;
using FicBook.View;
using System.Windows;

namespace FicBook.ViewModel
{
    class RegistrationViewModel : BindingHelper
    {
        private ObservableCollection<User> users;
        public RegistrationWindow registrationWindow;

        public RegistrationViewModel(RegistrationWindow registrationWindow, ObservableCollection<User> users)
        {
            UserExistsCommand = new BindableCommand(_ => UserExists());


            this.users = users;

            this.registrationWindow = registrationWindow;
        }
        public RegistrationViewModel() { }

        private string enteredName;
        public string EnteredName
        {
            get { return enteredName; }
            set
            {
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
        public BindableCommand UserExistsCommand { get; set; }
        #endregion


        public void UserExists()
        {
            bool userexists = false;
            foreach (User item in users)
            {
                if (item.Username == enteredName)
                {
                    MessageBox.Show("Такой пользователь уже существует");
                    userexists = true;
                }
                if (enteredPassword == null|| enteredPassword == "") 
                {
                    MessageBox.Show("Добавьте пароль");
                    userexists = true;
                }
            }
            if(!userexists)
            {
                User newUser = new User();
                newUser.Username = enteredName;
                newUser.Password = enteredPassword;
                users.Add(newUser);
                MessageBox.Show("Вы зарегистрированы! Теперь войдите в систему");
                MainWindow mainWindow = new MainWindow(users);
                mainWindow.Show();
                registrationWindow.Close();
            }



        }
    }
}
