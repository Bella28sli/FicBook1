using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FicBook.Model
{
    public class Fanfic
    {
        public string Title {  get; set; } //поиск //поиск р
        public string Desc { get; set; } 
        public string Author { get; set; } //поиск р
        public string Fandom { get; set; } //поиск //поиск р
        public ObservableCollection<string> Tags {  get; set; } //поиск р
        public int Size { get; set; } //поиск р
        public FocusEn Focus { get; set; } //поиск
        public AgeRatingEn AgeRate { get; set; } //поиск р
        public string CoverPath {  get; set; }
        public int Likes { get; set; }
        public string FullText { get; set; }
    }
}
