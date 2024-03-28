using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicBook.Model
{
    public enum FocusEn
    {
        [Description("Гет")]
        Гет = 0,
        [Description("Слэш")]
        Слэш = 1,
        [Description("Фемслэш")]
        Фемслэш = 2,
        [Description("Джен")]
        Джен = 3,
        [Description("Смешанная")]
        Смешанная = 4,
        [Description("Другая")]
        Другая = 5,
        [Description("Статья")]
        Статья = 6,
    }
}
