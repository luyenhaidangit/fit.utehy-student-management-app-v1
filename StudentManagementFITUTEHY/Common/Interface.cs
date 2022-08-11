using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Common
{
    public static class Interface
    {
        #region Khung giao diện
        static public void PrintFrame(int numberCol)
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
                    else if (i == 4 && numberCol == 1)
                    {
                        row = (k != 0 && k != 209) ? row += "═" : (k == 0) ? row += "╠" : row += "╣\n";
                    }
                    else if (i == 4 && numberCol == 2)
                    {
                        row = (k != 0 && k != 209 && k != 95) ? row += "═" : (k == 0) ? row += "╠" : (k == 95) ? row += "╦" : row += "╣\n";
                    }
                    //Loại
                    else if (i < 43 && numberCol == 1)
                    {
                        row = (k != 0 && k != 209) ? row += " " : (k == 0) ? row += "║" : row += "║\n";
                    }
                    else if (i < 43 && numberCol == 2)
                    {
                        row = (k != 0 && k != 209 && k != 95) ? row += " " : (k == 0) ? row += "║" : (k == 95) ? row += "║" : row += "║\n";
                    }
                    //Loại
                    else if (i == 43 && numberCol == 1)
                    {
                        row = (k != 0 && k != 209) ? row += "═" : (k == 0) ? row += "╠" : row += "╣\n";
                    }
                    else if (i == 43 && numberCol == 2)
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

        #region Form Lớp học
        public static void PrintInputFormClass()
        {
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 15);
            Display.Write("║  MÃ LỚP        :                                ║", 25, 16);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 17);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 18);
            Display.Write("║  TÊN LỚP       :                                ║", 25, 19);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 20);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 21);
            Display.Write("║  CHUYÊN NGÀNH  :                                ║", 25, 22);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 23);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 25);
            Display.Write("║                                                 ║", 25, 26);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 27);
        }

        public static void PrintDataTableClass(int a,int b,List<Class> list)
        {
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 4);
                table.PrintTitle(a, b + 1, "MÃ LỚP", "TÊN LỚP", "CHUYÊN NGÀNH", "SĨ SỐ");
                table.PrintBetweenLine(a, b + 2, 4);
                int x = a, y = b + 3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    table.PrintRow(x, y, list[i].IdClass, list[i].NameClass, list[i].NameSpecialized, list[i].NumberStudent.ToString());
                    y++;
                }
                table.PrintLastLine(x, y, 4);
                #endregion

                #region Xử lý trang
                y = y + 1;
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(new string(' ', 108));
                    y++;
                }
                Console.SetCursorPosition(106, 45);
                Console.Write("Nhấn  ◄/► để di chuyển giữa các trang:{0}     |Nhấn ENTER để tiếp tục!", curpage + "/" + totalpage);
                kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.RightArrow)
                {
                    if (curpage < totalpage) curpage = curpage + 1;
                    else curpage = 1;
                }
                else if (kt.Key == ConsoleKey.LeftArrow)
                {
                    if (curpage > 1) curpage = curpage - 1;
                    else curpage = totalpage;
                }
                #endregion

            } while (kt.Key == ConsoleKey.RightArrow || kt.Key == ConsoleKey.LeftArrow);
        }
        #endregion  
    }
}
