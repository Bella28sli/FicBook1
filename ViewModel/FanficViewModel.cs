using FicBook.Model;
using FicBook.View;
using FicBook.View.Pages;
using FicBook.View.Windows;
using FicBook.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FicBook.ViewModel
{
    internal class FanficViewModel : BindingHelper
    {
        private FanficWindow fanficWindow;
        private string username;
        private User user;
        private ObservableCollection<User> users;

        private Page readAll;
        private Page liked;
        private Page myFics;

        private ObservableCollection<Fanfic> allFics = new ObservableCollection<Fanfic>();

        public FanficViewModel(FanficWindow fanficWindow, string username, ObservableCollection<User> users)
        {
            readAll = new View.Pages.ReadAllPage(fanficWindow);


            this.fanficWindow = fanficWindow;
            this.username = username;
            this.users = users;
            CurrentPage = readAll;

            foreach (User item in users)
            {
                if (item.Username == username)
                {
                    user = item;
                }
            }
            allFics = SerDeser.Deserialize<ObservableCollection<Fanfic>>("\\Model\\FicBookSorted.json");
            foreach (Fanfic fanfic in allFics)
            {
                AllFicsView.Add(new FicView(fanfic, fanficWindow));
            }
            ExitCommand = new BindableCommand(_ => Exit());
            SortCommand = new BindableCommand(_ => Sort());
        }
        public FanficViewModel(FanficWindow fanficWindow) {

            this.fanficWindow = fanficWindow;

            allFics = SerDeser.Deserialize<ObservableCollection<Fanfic>>("\\Model\\FicBookSorted.json");
            foreach (Fanfic fanfic in allFics)
            {
                AllFicsView.Add(new FicView(fanfic, fanficWindow));
            }
            CurrentPage = readAll;
            ExitCommand = new BindableCommand(_ => Exit());
            SortCommand = new BindableCommand(_ => Sort());

        }
        public BindableCommand ExitCommand { get; set; }

        public void Exit()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            fanficWindow.Close();
        }

        public BindableCommand SortCommand { get; set; }

        private void Sort()
        {
            allFics = SerDeser.Deserialize<ObservableCollection<Fanfic>>("\\Model\\FicBook.json");

            ObservableCollection<Fanfic> allFicsSorted = new ObservableCollection<Fanfic>();
            foreach (var fanfic in allFics)
            {
                if (fanfic.Title == Title || fanfic.Fandom == Fandom || fanfic.Focus == Focus || fanfic.Author == Author || fanfic.Size.ToString() == Size || fanfic.AgeRate == Ages)
                {
                    allFicsSorted.Add(fanfic);
                }
            }
            
            AllFicsView.Clear();
            foreach (Fanfic fanfic in allFicsSorted)
            {
                AllFicsView.Add(new FicView(fanfic, fanficWindow));
            }
            allFics = new ObservableCollection<Fanfic>(allFicsSorted.Distinct());
            SerDeser.Serialize<ObservableCollection<Fanfic>>(allFicsSorted, "\\Model\\FicBookSorted.json");
            FanficWindow NewfanficWindow = new FanficWindow(username, users);
            NewfanficWindow.Show();
            fanficWindow.Close();

        }
        #region Привязки
        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }



        private ObservableCollection<FicView> allFicsView = new ObservableCollection<FicView>();
        public ObservableCollection<FicView> AllFicsView
        {
            get { return allFicsView; }
            set
            {
                allFicsView = value;
                OnPropertyChanged();
            }
        }
        private FicView selectedFic;
        public FicView SelectedFic
        {
            get { return selectedFic; }
            set
            {
                selectedFic = value;
                OnPropertyChanged();
            }
        }
        private string fullText;
        public string FullText
        {
            get { return fullText; }
            set
            {
                fullText = value;
                OnPropertyChanged();
            }
        }
        private FocusEn focus;
        public FocusEn Focus
        {
            get { return focus; }
            set
            {
                focus = value;
                OnPropertyChanged();
            }
        }
        private TagEn tags;
        public TagEn Tags
        {
            get { return tags; }
            set
            {
                tags = value;
                OnPropertyChanged();
            }
        }
        private AgeRatingEn ages;
        public AgeRatingEn Ages
        {
            get { return ages; }
            set
            {
                ages = value;
                OnPropertyChanged();
            }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string fandom;
        public string Fandom
        {
            get { return fandom; }
            set
            {
                fandom = value;
                OnPropertyChanged();
            }
        }
        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged();
            }
        }
        private string size;
        public string Size
        {
            get { return size; }
            set 
            { 
                size = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
