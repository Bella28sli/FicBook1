using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicBook.Model
{
    public enum AgeRatingEn
    {
        [Description("G")]
        G = 0,
        [Description("PG-13")]
        PG_13 = 1,
        [Description("R")]
        R = 2,
        [Description("NC-17")]
        NC_17 = 3,
        [Description("NC-21")]
        NC_21 = 4
    }
}
