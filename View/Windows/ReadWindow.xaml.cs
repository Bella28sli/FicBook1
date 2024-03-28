using FicBook.Model;
using FicBook.ViewModel;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
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

namespace FicBook.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReadWindow.xaml
    /// </summary>
    public partial class ReadWindow : Window
    {
        public ReadWindow(FanficWindow fanficWindow, Fanfic fanfic)
        {
            InitializeComponent();
            DataContext = new FicViewModel(fanfic, fanficWindow);
        }
    }
}
