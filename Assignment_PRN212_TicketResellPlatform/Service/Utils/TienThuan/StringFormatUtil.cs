using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utils.TienThuan
{
    public class StringFormatUtil
    {
        // Output Sample: 123.000 ₫
        public static string FormatVND(long amount)
        {
            CultureInfo vietnameseCulture = new CultureInfo("vi-VN");
            return string.Format(vietnameseCulture, "{0:C0}", amount);
        }
    }
}
