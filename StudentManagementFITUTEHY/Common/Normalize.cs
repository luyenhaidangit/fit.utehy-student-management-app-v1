using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    static public class Normalize
    {
        public static string String(string name)
        {
            //"   lUyệN    Hải  ĐĂng   " -->"Luyện Hải Đăng"
            name = name.Trim(); //  "lUyện     Hải   ĐĂng"
            name = name.ToLower(); // "luyện     hải     đăng"    
            while (name.IndexOf("  ") != -1) // kiểm tra xem có dấu 2 dấu cách nào liền nhau hay không
            {
                name = name.Remove(name.IndexOf("  "), 1); // loại bỏ đi 1 trong 2 dấu cách
            }//"luyện hải đăng"
            string[] s = name.Split(' '); //     "a[]={luyện,hải,đăng}"
            string afterFormat = "";
            for (int i = 0; i < s.Length; ++i)
            {
                //VD:luyện
                string first = s[i].Substring(0, 1); //    "l"
                string another = s[i].Substring(1, s[i].Length - 1); //    "uyện"
                afterFormat += first.ToUpper() + another + " ";   //Luyện
            }//"Luyện Hải Đăng "
            afterFormat = afterFormat.Remove(afterFormat.LastIndexOf(' '), 1);
            return afterFormat;
        }

        public static double Number(double num)//9,3416987...-->9.31
        {
            return Math.Round(num, 2);
        }
    }
}
