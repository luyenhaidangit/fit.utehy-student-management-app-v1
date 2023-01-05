using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace QuanLySinhVien.Utilities
{
    public class Display
    {
        #region Giao diện bảng
        static public void PhanBang(int loai)
        {
            string row = "";
            for (int i = 0; i <= 50; i++)
            {
                for (int k = 0; k < 210; k++)
                {
                    if (i == 0)
                    {
                        row = (k != 0 && k != 209) ? row += "═" : (k == 0) ? row += "╔" : row += "╗\n";
                    }

                    else if (i < 4)
                    {
                        row = (k != 0 && k != 209) ? row += " " : (k == 0) ? row += "║" : row += "║\n";
                    }

                    //Loại
                    else if (i == 4&& loai==1)
                    {
                        row = (k != 0 && k != 209) ? row += "═" : (k == 0) ? row += "╠"  : row += "╣\n";
                    }
                    else if (i == 4 && loai == 2)
                    {
                        row = (k != 0 && k != 209 && k != 95) ? row += "═" : (k == 0) ? row += "╠" : (k == 95) ? row += "╦" : row += "╣\n";
                    }
                    //Loại
                    else if(i<43&&loai==1)
                    {
                        row = (k != 0 && k != 209) ? row += " " : (k == 0) ? row += "║" : row += "║\n";
                    }
                    else if (i < 43&&loai==2)
                    {
                        row = (k != 0 && k != 209 && k != 95) ? row += " " : (k == 0) ? row += "║" : (k == 95) ? row += "║" : row += "║\n";
                    }
                    //Loại
                    else if(i==43&&loai==1)
                    {
                        row = (k != 0 && k != 209) ? row += "═" : (k == 0) ? row += "╠" : row += "╣\n";
                    }
                    else if (i == 43&&loai==2)
                    {
                        row = (k != 0 && k != 209 && k != 95) ? row += "═" : (k == 0) ? row += "╠" : (k == 95) ? row += "╩" : row += "╣\n";
                    }
                    else if (i < 47)
                    {
                        row = (k != 0 && k != 209) ? row += " " : (k == 0) ? row += "║" : row += "║\n";
                    }
                    else if (i == 47)
                    {
                        row = (k != 0 && k != 209) ? row += "═" : (k == 0) ? row += "╚" : row += "╝\n";
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(row);
            Console.ResetColor();
        }
        #endregion

        #region Hiển thị nội dung theo vị trí
        static public void Write(string s,int x,int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(s);
        }
        static public void Write(string s, int x, int y,ConsoleColor cl)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = cl;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static public void WriteBG(string s, int x, int y, ConsoleColor cl)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = cl;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        #endregion

        #region Giao diện bắt đầu
        static public void GiaoDienBatDau()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Menu Chính";
            //Console.CursorVisible = false; //con trỏ có thể chia sẻ
            PhanBang(1);
            Display.Write("TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN", 80, 1);
            Display.Write("KHOA CÔNG NGHỆ THÔNG TIN", 88, 2);
            Display.Write("********   *********     *******   ********** *********   ********  **********       ***", 53, 10, ConsoleColor.Green);
            Display.Write("***    **  ***    ***   ***   ***       ***    ***       ***           ***          *****", 53, 11, ConsoleColor.Green);
            Display.Write("***    *** ***    ***  ***     ***      ***    ***       ***           ***            ***", 53, 12, ConsoleColor.Green);
            Display.Write("*********  *********   ***     ***      ***    ********* ***           ***            ***", 53, 13, ConsoleColor.Green);
            Display.Write("***        ***    ***  ***     ***      ***    ***       ***           ***            ***", 53, 14, ConsoleColor.Green);
            Display.Write("***        ***     ***  ***   ***      ***     ***       ***           ***            ***", 53, 15, ConsoleColor.Green);
            Display.Write("***        ***      ***  *******   ******     *********   ********     ***          *******", 53, 16, ConsoleColor.Green);
            Display.Write("╔════════════════════════════════════════════════════════════════════════════════════════╗", 53, 19);
            Display.Write("║   CHÀO MỪNG BẠN ĐẾN VỚI ỨNG DỤNG QUẢN LÝ SINH VIÊN KHOA CNTT TRƯỜNG ĐH SPKT HƯNG YÊN   ║", 53, 20);
            Display.Write("╚════════════════════════════════════════════════════════════════════════════════════════╝", 53, 21);
            Display.Write("Giáo Viên Hướng dẫn: Nguyễn Hữu Đông", 80, 25);
            Display.Write("Sinh Viên thực hiện: Luyện Hải Đăng", 80, 26);
            Display.Write("Lớp                : 125201", 80, 27);
            Display.Write("Mã sinh viên       : 12520063", 80, 28);
            Display.Write("Hưng Yên 2021", 94, 42);
            Display.Write("Nhấn ENTER để vào menu chính!!!", 83, 45);
            Console.ReadKey();
        }
        #endregion

        #region Menu
        static public void MenuQL()
        {
            Console.Title = "Chương Trình Quản Lý Sinh Viên Khoa CNTT Trường ĐH SPKT Hưng Yên - Luyện Hải Đăng";
            Console.Clear();
            Display.PhanBang(1);
            Display.Write("▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌", 87, 7);
            Display.Write("▐       DANH MỤC      ▌", 87, 8);
            Display.Write("▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌ ", 87, 9);
            Display.Write("╔═════════════════════════════════════╗", 80, 13);
            Display.Write("║     1.QUẢN LÝ LỚP HỌC               ║", 80, 14);
            Display.Write("╚═════════════════════════════════════╝", 80, 15);
            Display.Write("╔═════════════════════════════════════╗", 80, 16);
            Display.Write("║     2.QUẢN LÝ SINH VIÊN             ║", 80, 17);
            Display.Write("╚═════════════════════════════════════╝", 80, 18);
            Display.Write("╔═════════════════════════════════════╗", 80, 19);
            Display.Write("║     3.QUẢN LÝ GIÁO VIÊN             ║", 80, 20);
            Display.Write("╚═════════════════════════════════════╝", 80, 21);
            Display.Write("╔═════════════════════════════════════╗", 80, 22);
            Display.Write("║     4.QUẢN LÝ MÔN HỌC               ║", 80, 23);
            Display.Write("╚═════════════════════════════════════╝ ", 80, 24);
            Display.Write("╔═════════════════════════════════════╗", 80, 25);
            Display.Write("║     5.QUẢN LÝ LỊCH HỌC              ║", 80, 26);
            Display.Write("╚═════════════════════════════════════╝ ", 80, 27);
            Display.Write("╔═════════════════════════════════════╗", 80, 28);
            Display.Write("║     6.QUẢN LÝ ĐIỂM THI              ║", 80, 29);
            Display.Write("╚═════════════════════════════════════╝ ", 80, 30);
            Display.Write("╔═════════════════════════════════════╗", 80, 31);
            Display.Write("║     7.THỐNG KÊ                      ║", 80, 32);
            Display.Write("╚═════════════════════════════════════╝ ", 80, 33);
            Display.Write("╔═════════════════════════════════════╗", 80, 34);
            Display.Write("║     8.TIỆN ÍCH                      ║", 80, 35);
            Display.Write("╚═════════════════════════════════════╝ ", 80, 36);
            Display.Write("╔═════════════════════════════════════╗", 80, 37);
            Display.Write("║     9.THOÁT                         ║", 80, 38);
            Display.Write("╚═════════════════════════════════════╝ ", 80, 39);
        }
        #endregion
 
    }
}
