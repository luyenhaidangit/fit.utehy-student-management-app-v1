using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Invalid
    {
        public static bool chiChuaSo(string value)
        {
            try
            {
                char[] chars = value.ToCharArray();
                foreach (char c in chars)
                {
                    if (!char.IsNumber(c))
                        return false;
                }
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public static bool SoSanh(string s, string s1)
        {
            s = s.ToLower();
            s1 = s1.ToLower();
            if (s.Contains(s1) == true || s1.Contains(s) == true)
            {
                return true;
            }
            int i, j, k, loi, saiSo;
            saiSo = (int)Math.Round(s.Length * 0.3);
            if (s1.Length < (s.Length - saiSo) || s1.Length > (s.Length + saiSo))
                return false;
            i = j = loi = 0;
            while (i < s.Length && j < s1.Length)
            {
                if (s[i] != s1[j])
                {
                    loi++; //so sánh từng ký tự của 2 string nếu không bằng nhau thì lỗi cộng thêm 1
                    for (k = 1; k <= saiSo; k++)//so sánh các từ lân cận tiếp theo của cả 2 string
                    {
                        if ((i + k < s.Length) && s[i + k] == s1[j])
                        {
                            i += k;
                            //loi += k – 1;
                            break;
                        }
                        else if ((j + k < s1.Length) && s[i] == s1[j + k])
                        {
                            j += k;
                            //loi += k – 1;
                            break;
                        }
                    }
                }
                i++;
                j++;
            }
            loi += s.Length - i + s1.Length - j;//1 xâu đã hết, xâu còn lại vẫn còn => cộng lỗi
            if (loi <= saiSo)
                return true;
            else return false;
        }
    }
}
