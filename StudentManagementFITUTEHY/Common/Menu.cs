using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// references: https://youtu.be/qAWhGEPMlS8
    /// </summary>
    public class Menu
    {
        #region Khai báo thuộc tính
        private int index = 0;
        private List<string> content;
        #endregion

        #region Phương thức khởi tạo
        public Menu(List<string> content)
        {
            this.content = content;
            this.index = 0;
        }
        #endregion

        #region Menu nội dung trên một dòng
        //private void PrintColorMenu(int x, int y)
        //{
        //    ConsoleColor color = ConsoleColor.Black;
        //    for (int i = 0; i < content.Count; i++)
        //    {
        //        if (i == index)
        //        {
        //            color = ConsoleColor.DarkBlue;
        //        }
        //        else
        //        {
        //            color = ConsoleColor.Black;
        //        }
        //        Display.WriteBG(content[i], x, y, color);
        //        y++;
        //    }
        //}

        //public int ActionSelect(int x, int y)
        //{
        //    ConsoleKey key;
        //    do
        //    {
        //        PrintColorMenu(x, y);
        //        ConsoleKeyInfo keyInfo = Console.ReadKey();
        //        key = keyInfo.Key;
        //        if (key == ConsoleKey.UpArrow)
        //        {
        //            if (index - 1 <= 0) index = 0;
        //            else index = index - 1;
        //        }
        //        else if (key == ConsoleKey.DownArrow)
        //        {
        //            if (index + 1 >= content.Count) index = content.Count - 1;
        //            else index = index + 1;
        //        }
        //    } while (key != ConsoleKey.Enter);
        //    return index;
        //}
        #endregion

        #region Menu nội dung trên ba dòng
        //Menu theo chiều dọc
        /// <summary>
        /// Hiển thị menu theo chiều dọc
        /// </summary>
        /// <param name="x">Vị trị theo trục x trên tọa độ màn hình</param>
        /// <param name="y">Vị trí theo trục y trên tọa độ màn hình</param>
        private void PrintColorMenu(int x, int y)
        {
            ConsoleColor mau = ConsoleColor.Black;
            for (int i = 0; i < content.Count; i++)
            {
                if (i == index || i == index + 1 || i == index + 2)
                {
                    mau = ConsoleColor.DarkBlue;
                }
                else
                {
                    mau = ConsoleColor.Black;
                }
                Display.WriteBG(content[i], x, y, mau);
                y++;
            }
        }

        /// <summary>
        /// Xác định nội dung người dùng chọn
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Vị trí nội dung mà người dùng chọn</returns>
        public int ActionSelect(int x, int y)
        {
            ConsoleKey key;
            do
            {
                PrintColorMenu(x, y);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                key = keyInfo.Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (index - 3 <= 0) index = 0;
                    else index = index - 3;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (index + 3 >= content.Count) index = content.Count - 3;
                    else index = index + 3;
                }
            } while (key != ConsoleKey.Enter);
            return index;
        }

        /// <summary>
        /// Hiển thị menu theo chiều ngang
        /// </summary>
        /// <param name="x">Vị trị theo trục x trên tọa độ màn hình</param>
        /// <param name="y">Vị trí theo trục y trên tọa độ màn hình</param>
        /// <param name="distance">Khoảng cách giữa từng nội dung menu theo trục ngang</param>
        private void PrintColorMenu(int x, int y, int distance)
        {
            int sodu = y % 3;
            int ybandau = y;
            ConsoleColor mau = ConsoleColor.Black;
            for (int i = 0; i < content.Count; i++)
            {
                if (i == index || i == index + 1 || i == index + 2)
                {
                    mau = ConsoleColor.DarkYellow;
                }
                else
                {
                    mau = ConsoleColor.Black;
                }
                Display.WriteBG(content[i], x, y, mau);
                y++;
                if (y % 3 == sodu)
                {
                    y = ybandau;
                    x = x + distance;
                }
            }
        }

        /// <summary>
        /// Xác định nội dung người dùng chọn
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Vị trí nội dung mà người dùng chọn</returns>
        public int ActionSelect(int x, int y, int z)
        {
            ConsoleKey key;
            do
            {
                PrintColorMenu(x, y, z);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                key = keyInfo.Key;
                if (key == ConsoleKey.LeftArrow)
                {
                    if (index - 3 <= 0) index = 0;
                    else index = index - 3;
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    if (index + 3 >= content.Count) index = content.Count - 3;
                    else index = index + 3;
                }
            } while (key != ConsoleKey.Enter);
            return index;
        }
        #endregion
    }
}
