using System;
using System.Collections.Generic;
using System.Text;


namespace QuanLySinhVien.Utilities
{
    class Menu
    {
        #region Khai báo thuộc tính
        private int viTri = 0;
        private List<string> noiDung;
        #endregion

        #region Phương thức khởi tạo
        public Menu(List<string> noiDung)
        {
            this.noiDung = noiDung;
            this.viTri = 0;
        }
        #endregion

        #region Menu
        private void DoiMauNoiDungTable(int x, int y)
        {
            ConsoleColor mau = ConsoleColor.Black;
            for (int i = 0; i < noiDung.Count; i++)
            {
                if (i == viTri)
                {
                    mau = ConsoleColor.DarkBlue;
                }
                else
                {
                    mau = ConsoleColor.Black;
                }
                Display.WriteBG(noiDung[i], x, y, mau);
                y++;
            }
        }

        public int ThaoTacTable(int x, int y)
        {
            ConsoleKey key;
            do
            {
                DoiMauNoiDungTable(x, y);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                key = keyInfo.Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (viTri - 1 <= 0) viTri = 0;
                    else viTri = viTri - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (viTri + 1 >= noiDung.Count) viTri = noiDung.Count - 1;
                    else viTri = viTri + 1;
                }
            } while (key != ConsoleKey.Enter);
            return viTri;
        }


        private void DoiMauNoiDung(int x, int y)
        {
            ConsoleColor mau = ConsoleColor.Black;
            for (int i = 0; i < noiDung.Count; i++)
            {
                if (i == viTri || i == viTri + 1 || i == viTri + 2)
                {
                    mau = ConsoleColor.DarkBlue;
                }
                else
                {
                    mau = ConsoleColor.Black;
                }
                Display.WriteBG(noiDung[i], x, y, mau);
                y++;
            }
        }

        public int ThaoTac(int x, int y)
        {
            ConsoleKey key;
            do
            {
                DoiMauNoiDung(x, y);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                key = keyInfo.Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (viTri - 3 <= 0) viTri = 0;
                    else viTri = viTri - 3;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (viTri + 3 >= noiDung.Count) viTri = noiDung.Count - 3;
                    else viTri = viTri + 3;
                }
            } while (key != ConsoleKey.Enter);
            return viTri;
        }

        private void DoiMauNoiDung(int x, int y, int z)
        {
            int sodu = y % 3;
            int ybandau = y;
            ConsoleColor mau = ConsoleColor.Black;
            for (int i = 0; i < noiDung.Count; i++)
            {
                if (i == viTri || i == viTri + 1 || i == viTri + 2)
                {
                    mau = ConsoleColor.DarkYellow;
                }
                else
                {
                    mau = ConsoleColor.Black;
                }
                Display.WriteBG(noiDung[i], x, y, mau);
                y++;
                if (y % 3 == sodu)
                {
                    y = ybandau;
                    x = x + z;
                }
            }
        }

        public int ThaoTac(int x, int y, int z)
        {
            ConsoleKey key;
            do
            {
                DoiMauNoiDung(x, y, z);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                key = keyInfo.Key;
                if (key == ConsoleKey.LeftArrow)
                {
                    if (viTri - 3 <= 0) viTri = 0;
                    else viTri = viTri - 3;
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    if (viTri + 3 >= noiDung.Count) viTri = noiDung.Count - 3;
                    else viTri = viTri + 3;
                }
            } while (key != ConsoleKey.Enter);
            return viTri;
        }
        #endregion
    }
}
