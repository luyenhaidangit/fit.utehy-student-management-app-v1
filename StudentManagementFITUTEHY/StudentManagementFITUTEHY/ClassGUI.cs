using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using BUS;
using DTO;

namespace GUI
{
    public class ClassGUI
    {
        private ClassBUS clBUS = new ClassBUS();

        #region Thêm lớp
        public Class NewClass()
        {
            List<Class> list = clBUS.GetData();
            list.Reverse();

            Interface.PrintFrame(2);
            Interface.PrintInputFormClass();
            Interface.PrintDataTableClass(100,15,list);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÊM THÔNG TIN LỚP HỌC", 40, 2);
            Console.ResetColor();

            Class cl = new Class();
            //Mã lớp
            List<int> listID = new List<int>();
            for (int i = 0; i < clBUS.GetData().Count; i++)
            {
                listID.Add(int.Parse(clBUS.GetData()[i].IdClass));
            }
            int max = list.Count != 0 ? listID.Max() : 125201;


            cl.IdClass = (max + 1).ToString();
            Display.Write(cl.IdClass, 43, 16);

            //Tên lớp
            do
            {
                Console.SetCursorPosition(43, 19);
                cl.NameClass = Console.ReadLine();
                if (cl.NameClass.Length == 0 || cl.NameClass.Length > 10)
                {
                    Display.Write("Tên lớp không hợp lệ, nhập lại", 26, 26);
                    Display.Write(new string(' ', 30), 43, 19);
                }
            } while (cl.NameClass.Length == 0 || cl.NameClass.Length > 10);
            Display.Write(new string(' ', 45), 26, 26);

            //Chuyên ngành
            do
            {
                Console.SetCursorPosition(43, 22);
                cl.NameSpecialized = Console.ReadLine();
                if (clBUS.CheckValidNameSpecialized(cl.NameSpecialized) == false)
                {
                    Display.Write("Tên chuyên ngành không hợp lệ, nhập lại", 26, 26);
                    Display.Write(new string(' ', 30), 43, 22);
                }
            } while (clBUS.CheckValidNameSpecialized(cl.NameSpecialized) == false);
            Display.Write(new string(' ', 45), 26, 26);

            cl.NumberStudent = 0;

            Display.Write("Thêm thông tin thành công!", 26, 26);
            return cl;
        }

        public void Add()
        {
            int check = 1;
            do
            {
                Console.Clear();
                Class lh = NewClass();
                clBUS.Add(lh);
                PrintDataTable(100, 15);
                Display.Write("BẠN CÓ MUỐN TIẾP TỤC NHẬP KHÔNG?", 30, 42);
                List<string> bang = new List<string>();
                bang.Add("╔══════════╗");
                bang.Add("║ TIẾP TỤC ║");
                bang.Add("╚══════════╝");
                bang.Add("╔══════════╗");
                bang.Add("║ DỪNG LẠI ║");
                bang.Add("╚══════════╝");
                Menu menu = new Menu(bang);
                int index = menu.ActionSelect(30, 44, 20);
                check = (index / 3) + 1;
            } while (check == 1);
            Display.Write(new string(' ', 60), 30, 42);
            Display.Write(new string(' ', 60), 30, 44);
            Display.Write(new string(' ', 60), 30, 45);
            Display.Write(new string(' ', 60), 30, 46);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 30, 45);
            Console.ReadLine();
        }

        public void PrintDataTable(int a, int b)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÔNG TIN DANH SÁCH CÁC LỚP HỌC", 140, 2);
            Console.ResetColor();
            List<Class> list = clBUS.GetData();
            list.Reverse();
            Interface.PrintDataTableClass(a,b,list);
        }
        #endregion

        #region Menu
        public void Menu()
        {
            Console.Clear();
            string check = "0";
            while (check == "0")
            {
                Interface.PrintFrame(1);
                Display.Write("▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌", 87, 10);
                Display.Write("▐   QUẢN LÝ LỚP HỌC   ▌", 87, 11);
                Display.Write("▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌ ", 87, 12);
                List<string> bang = new List<string>();
                bang.Add("╔═════════════════════════════════════╗");
                bang.Add("║     1.Nhập Thông Tin Lớp Học        ║");
                bang.Add("╚═════════════════════════════════════╝");
                bang.Add("╔═════════════════════════════════════╗");
                bang.Add("║     2.Hiển Thị Thông Tin Lớp Học    ║");
                bang.Add("╚═════════════════════════════════════╝");
                bang.Add("╔═════════════════════════════════════╗");
                bang.Add("║     3.Tìm Kiếm Thông Tin Lớp Học    ║");
                bang.Add("╚═════════════════════════════════════╝");
                bang.Add("╔═════════════════════════════════════╗");
                bang.Add("║     4.Sửa Thông Tin Lớp Học         ║");
                bang.Add("╚═════════════════════════════════════╝");
                bang.Add("╔═════════════════════════════════════╗");
                bang.Add("║     5.Xóa Thông Tin Lớp học         ║");
                bang.Add("╚═════════════════════════════════════╝");
                bang.Add("╔═════════════════════════════════════╗");
                bang.Add("║     6.Trở Lại Trang Trước           ║");
                bang.Add("╚═════════════════════════════════════╝");
                Menu menu = new Menu(bang);
                int index1 = menu.ActionSelect(80, 20);
                int mode = (index1 / 3) + 1;
                switch (mode.ToString())
                {
                    case "1":
                        Console.Clear();
                        Add();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Interface.PrintFrame(2);
                        PrintDataTable(100, 15);
                        Console.Clear();
                        break;
                    //case "3":
                    //    Console.Clear();
                    //    timKiem(100, 15);
                    //    Console.Clear();
                    //    break;
                    //case "4":
                    //    Console.Clear();
                    //    Sua();
                    //    Console.Clear();
                    //    break;

                    //case "5":
                    //    Console.Clear();
                    //    Xoa();
                    //    Console.Clear();
                    //    break;
                    case "6":
                        check = "1";
                        Display.MenuQL();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
        #endregion
    }
}
