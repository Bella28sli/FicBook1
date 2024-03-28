using FicBook.Model;
using FicBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FicBook.View
{
    /// <summary>
    /// Логика взаимодействия для FanficWindow.xaml
    /// </summary>
    public partial class FanficWindow : Window
    {
        public FanficWindow(string enteredname, ObservableCollection<User> users)
        {
            InitializeComponent();
            DataContext = new FanficViewModel(this, enteredname, users);

        }
    }
}
