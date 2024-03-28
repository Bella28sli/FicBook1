using FicBook.Model;
using FicBook.View;
using FicBook.View.Windows;
using FicBook.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FicBook.ViewModel
{
    class FicViewModel : BindingHelper
    {

        private Uri imagePath;

        private FanficWindow fanficWindow;
        private Fanfic fanfic;
        public FicViewModel(Fanfic fanfic, FanficWindow fanficWindow) 
        {
            this.fanfic = fanfic;
            this.fanficWindow = fanficWindow;
            string coverpath = Environment.CurrentDirectory;
            imagePath = new Uri(coverpath.Remove(coverpath.Length-25)+ "\\Images\\" +fanfic.CoverPath);
            image = new BitmapImage(imagePath);
            title = fanfic.Title;
            focusActive = fanfic.Focus;
            ageActive = fanfic.AgeRate;
            size = fanfic.Size;
            likes = fanfic.Likes;
            author = fanfic.Author;
            fandom = fanfic.Fandom;
            tags = fanfic.Tags;
            description = fanfic.Desc;
            fulltext = fanfic.FullText;

            if(focusActive == FocusEn.Гет) { focusColor = new SolidColorBrush { Color = Color.FromRgb(13, 109, 30) }; }
            else if (focusActive == FocusEn.Джен) { focusColor = new SolidColorBrush { Color = Color.FromRgb(71, 55, 33) }; }
            else if (focusActive == FocusEn.Другая) { focusColor = new SolidColorBrush { Color = Color.FromRgb(6, 100, 90) }; }
            else if (focusActive == FocusEn.Слэш) { focusColor = new SolidColorBrush { Color = Color.FromRgb(9, 25, 129) }; }
            else if (focusActive == FocusEn.Фемслэш) { focusColor = new SolidColorBrush { Color = Color.FromRgb(109, 26, 104) }; }
            else if (focusActive == FocusEn.Смешанная) { focusColor = new SolidColorBrush { Color = Color.FromRgb(54, 9, 91) }; }
            else if (focusActive == FocusEn.Статья) { focusColor = new SolidColorBrush { Color = Color.FromRgb(80, 80, 80) }; }

            if (ageActive == AgeRatingEn.G) { ageColor = new SolidColorBrush { Color = Color.FromRgb(31, 210, 217) }; }
            else if (ageActive == AgeRatingEn.PG_13) { ageColor = new SolidColorBrush { Color = Color.FromRgb(73, 217, 31) }; }
            else if (ageActive == AgeRatingEn.R) { ageColor = new SolidColorBrush { Color = Color.FromRgb(201, 217, 31) }; }
            else if (ageActive == AgeRatingEn.NC_17) { ageColor = new SolidColorBrush { Color = Color.FromRgb(217, 145, 31) }; }
            else if (ageActive == AgeRatingEn.NC_21) { ageColor = new SolidColorBrush { Color = Color.FromRgb(217, 51, 31) }; }
            ReadFicCommand = new BindableCommand(_ => ReadFic());

        }

        public BindableCommand ReadFicCommand { get; set; }

        public void ReadFic()
        {
            ReadWindow readWindow = new ReadWindow(fanficWindow, fanfic);
            readWindow.Show();
            fanficWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        #region Привязки

        private string fulltext;
        public string FullText
        {
            get { return fulltext; }
            set
            { 
                fulltext = value;
                OnPropertyChanged();
            }
        }

        private BitmapImage image;
        public BitmapImage Image
        {
            get { return image; }
            set
            {
                image = value;
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
        private FocusEn focusActive;
        public FocusEn FocusActive
        {
            get { return focusActive; }
            set
            {
                focusActive = value;
                OnPropertyChanged();
            }
        }
        private AgeRatingEn ageActive;
        public AgeRatingEn AgeActive
        {
            get { return ageActive; }
            set
            {
                ageActive = value;
                OnPropertyChanged();
            }
        }
        private int size;
        public int Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged();
            }
        }
        private int likes;
        public int Likes
        {
            get { return likes; }
            set
            {
                likes = value;
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
        private ObservableCollection<string> tags;
        public ObservableCollection<string> Tags
        {
            get { return tags; }
            set
            {
                tags = value;
                OnPropertyChanged();
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        private SolidColorBrush focusColor;
        public SolidColorBrush FocusColor
        {
            get { return focusColor; }
            set
            {
                focusColor = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush ageColor;
        public SolidColorBrush AgeColor
        {
            get { return ageColor; }
            set
            {
                ageColor = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
