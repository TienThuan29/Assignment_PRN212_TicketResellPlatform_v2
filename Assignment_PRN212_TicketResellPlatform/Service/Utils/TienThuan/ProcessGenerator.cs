using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utils.TienThuan
{
    public class ProcessGenerator
    {

        public static string GeneralProcessToName(string generalProcess)
        {
            switch(generalProcess)
            {
                case "WAITING":
                    return "Chờ kiểm duyệt";
                    break;
                case "SELLING":
                    return "Đang bán";
                    break;
                default:
                    return "N/A";

            }
        }

    }
}
