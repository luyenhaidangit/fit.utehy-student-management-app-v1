using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.BusinessLayer;
using QuanLySinhVien.Entities;
using QuanLySinhVien.Utilities;
using QuanLySinhVien.PresentationLayer.Interface;
using QuanLySinhVien.PresentationLayer;

namespace QuanLySinhVien.PresentationLayer
{
    public class MonHocGUI : IQuanLyGUI<MonHoc>
    {
        private MonHocBLL mhBLL = new MonHocBLL();

        #region Thêm
        public void KhungNhapThongTin()
        {
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 15);
            Display.Write("║  MÃ MÔN HỌC    :                                ║", 25, 16);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 17);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 18);
            Display.Write("║  TÊN MÔN HỌC   :                                ║", 25, 19);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 20);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 21);
            Display.Write("║  SỐ TÍN CHỈ    :                                ║", 25, 22);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 23);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 37);
            Display.Write("║                                                 ║", 25, 38);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 39);
        }

        public MonHoc NhapThem()
        {
            Display.PhanBang(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÊM THÔNG TIN MÔN HỌC", 40, 2);
            Console.ResetColor();
            KhungNhapThongTin();
            MonHoc mh = new MonHoc();
            do//Mã môn học
            {
                Console.SetCursorPosition(43, 16);
                mh.MaMonHoc = Console.ReadLine();
                if (mhBLL.MaMonHopLe(mh.MaMonHoc)==false)
                {
                    Display.Write("Mã môn học đã tồn tại, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 16);
                }
            } while (mhBLL.MaMonHopLe(mh.MaMonHoc) == false);
            Display.Write(new string(' ', 35), 26, 38);

            do//Tên môn học
            {
                Console.SetCursorPosition(43, 19);
                mh.TenMonHoc = Console.ReadLine();
                if (mh.TenMonHoc.Length == 0 || mh.TenMonHoc.Length > 30)
                {
                    Display.Write("Tên môn học không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 19);
                }
            } while (mh.TenMonHoc.Length == 0 || mh.TenMonHoc.Length > 30);
            Display.Write(new string(' ', 35), 26, 38);

            bool check = true;
            do//Số tín chỉ
            {
                try
                {
                    check = true;
                    Console.SetCursorPosition(43, 22);
                    mh.SoTC = int.Parse(Console.ReadLine());
                }
                catch
                {
                    check = false;
                    Display.Write("Số tín chỉ không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 22);
                }
                if (mh.SoTC > 10 || mh.SoTC < 1)
                {
                    Display.Write("Số tín chỉ không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 22);
                }
            } while (mh.SoTC > 10 || mh.SoTC < 1||check == false);
            Display.Write(new string(' ', 35), 26, 38);
            Display.Write("Thêm thông tin thành công!", 26, 38);
            return mh;
        }

        public void Them()
        {
            int check = 1;
            do
            {
                Console.Clear();
                MonHoc mh = NhapThem();
                mhBLL.Them(mh);
                hienThi(100, 15);
                Display.Write("BẠN CÓ MUỐN TIẾP TỤC NHẬP KHÔNG?", 30, 42);
                List<string> bang = new List<string>();
                bang.Add("╔══════════╗");
                bang.Add("║ TIẾP TỤC ║");
                bang.Add("╚══════════╝");
                bang.Add("╔══════════╗");
                bang.Add("║ DỪNG LẠI ║");
                bang.Add("╚══════════╝");
                Menu menu = new Menu(bang);
                int index = menu.ThaoTac(30,44,20);
                check = (index / 3) + 1;
            } while (check == 1);
            Display.Write(new string(' ', 60), 30, 42);
            Display.Write(new string(' ', 60), 30, 44);
            Display.Write(new string(' ', 60), 30, 45);
            Display.Write(new string(' ', 60), 30, 46);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 30, 45);
            Console.ReadLine();
        }
        #endregion

        #region Hiển thị
        public void hienThi(int a,int b)
        {
            List<MonHoc> list = mhBLL.DocDuLieu();
            list.Reverse();
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÔNG TIN DANH SÁCH MÔN HỌC", 140, 2);
            Console.ResetColor();
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 3);
                table.PrintTitle(a, b + 1, "MÃ MÔN HỌC", "TÊN MÔN HỌC", "SỐ TÍN CHỈ");
                table.PrintBetweenLine(a, b + 2, 3);
                int x = a, y = b + 3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    table.PrintRow(x, y, list[i].MaMonHoc, list[i].TenMonHoc, list[i].SoTC.ToString());
                    y++;
                }
                table.PrintLastLine(x, y, 3);
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

        #region Tìm kiếm
        public void timKiem(int a,int b)
        {
            Console.Clear();
            Display.PhanBang(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("TÌM KIẾM THÔNG TIN MÔN HỌC", 40, 2);
            Display.Write("THÔNG TIN DANH SÁCH CÁC MÔN HỌC", 140, 2);
            Console.ResetColor();
            Display.Write("╔═════════════════════════════════════════════════════════════════════╗", 10, 15);
            Display.Write("║  NHẬP TỰ KHÓA TÌM KIẾM:                                             ║", 10, 16);
            Display.Write("╚═════════════════════════════════════════════════════════════════════╝", 10, 17);
            string id;
            Console.SetCursorPosition(35, 16);
            id = Console.ReadLine();
            List<MonHoc> list = mhBLL.timKiem(id);
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 3);
                table.PrintTitle(a, b + 1, "MÃ MÔN HỌC", "TÊN MÔN HỌC", "SỐ TÍN CHỈ");
                table.PrintBetweenLine(a, b + 2,3);
                int x = a, y = b + 3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    if (Invalid.SoSanh(list[i].MaMonHoc, id) || Invalid.SoSanh(list[i].TenMonHoc, id) || Invalid.SoSanh(list[i].SoTC.ToString(), id))
                    {
                        table.PrintRowColorID(x, y, id, list[i].MaMonHoc, list[i].TenMonHoc, list[i].SoTC.ToString());
                        y++;
                    }
                }
                table.PrintLastLine(x, y,3);
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

        #region Sửa
        public void Sua()
        {
            Display.PhanBang(2);
            hienThi(100, 15);

            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("CẬP NHẬT THÔNG TIN MÔN HỌC", 40, 2);
            Console.ResetColor();

            #region Nhập mã cần sửa
            string id1;
            do
            {
                Display.Write("NHẬP MÃ MH CẦN ĐỔI THÔNG TIN :", 7, 44);
                Console.SetCursorPosition(37, 44);
                id1 = Console.ReadLine();
                if (mhBLL.MaMonHopLe(id1) == true || id1.Length == 0)
                {
                    Display.Write("MÃ MÔN HỌC KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (mhBLL.MaMonHopLe(id1) == true || id1.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            #endregion

            #region Chọn thuộc tính sửa
            List<string> sua = new List<string>();
            sua.Add("╔════════════════╗");
            sua.Add("║   TÊN MÔN HỌC  ║");
            sua.Add("╚════════════════╝");
            sua.Add("╔════════════════╗");
            sua.Add("║   SỐ TÍN CHỈ   ║");
            sua.Add("╚════════════════╝");
            Menu menusua = new Menu(sua);
            int index = menusua.ThaoTac(28, 7, 25);
            int luachon = (index / 3) + 1;
            #endregion


            KhungNhapThongTin();
            MonHoc mh = mhBLL.DocDuLieu()[mhBLL.ViTri(id1)];
            //Hiện lại info
            Display.Write(mh.MaMonHoc, 43, 16);
            Display.Write(mh.TenMonHoc, 43, 19);
            Display.Write(mh.SoTC.ToString(), 43, 22);
            if (luachon == 1)//Tên môn học
            {
                //mhnew = mh;
                Display.Write(new string(' ', 30), 43, 19);
                do
                {
                    Console.SetCursorPosition(43, 19);
                    mh.TenMonHoc = Console.ReadLine();
                    if (mh.TenMonHoc.Length == 0 || mh.TenMonHoc.Length > 30)
                    {
                        Display.Write("Tên môn học không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 19);
                    }
                } while (mh.TenMonHoc.Length == 0 || mh.TenMonHoc.Length > 30);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            else /*if(luachon==2)//Số tín chỉ*/
            {
                bool check = true;
                Display.Write(new string(' ', 30), 43, 22);
                do//Số tín chỉ
                {
                    try
                    {
                        check = true;
                        Console.SetCursorPosition(43, 22);
                        mh.SoTC = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        check = false;
                        Display.Write("Số tín chỉ không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 22);
                    }
                    if (mh.SoTC > 10 || mh.SoTC < 1)
                    {
                        Display.Write("Số tín chỉ không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 22);
                    }
                } while (mh.SoTC > 10 || mh.SoTC < 1||check == false);
                Display.Write(new string(' ', 35), 26, 38);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            mhBLL.Sua(id1, mh);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 7, 46);
            Console.ReadKey();
            Console.ReadLine();
        }
        #endregion

        #region Xóa
        public void Xoa()
        {
            string id5;
            Display.PhanBang(2);
            hienThi(100, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("XÓA THÔNG TIN MÔN HỌC", 40, 2);
            Console.ResetColor();
            do
            {
                Display.Write("NHẬP MÃ MH CẦN XÓA THÔNG TIN :", 7, 44);
                Console.SetCursorPosition(37, 44);
                id5 = Console.ReadLine();
                if (mhBLL.MaMonHopLe(id5) == true || id5.Length == 0)
                {
                    Display.Write("MÃ MÔN HỌC KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (mhBLL.MaMonHopLe(id5) == true || id5.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);

            Console.ForegroundColor = ConsoleColor.Red;
            Display.Write("╔════════════════════════════════════════════════════════════════════════╗", 10, 7);
            Display.Write("║  CẢNH BÁO: XÓA DỮ LIỆU CỦA SINH VIÊN CÓ THỂ ẢNH HƯỞNG TỚI DỮ LIỆU      ║", 10, 8);
            Display.Write("║  BẢNG ĐIỂM                                                             ║", 10, 9);
            Display.Write("║  NHẤN ESC ĐỂ DỪNG HOẶC NHẤN BẤT KÌ ĐỂ XÁC NHẬN XÓA                     ║", 10, 10);
            Display.Write("╚════════════════════════════════════════════════════════════════════════╝", 10, 11);
            Console.ResetColor();
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Menu();
            }

            mhBLL.Xoa(id5);

            Display.Write("XÓA THÔNG TIN THÀNH CÔNG", 7, 44);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 7, 46);
            Console.ReadLine();
        }
        #endregion

        #region Menu
        public int ChucNang()
        {
            Display.Write("▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌", 87, 10);
            Display.Write("▐   QUẢN LÝ MÔN HỌC   ▌", 87, 11);
            Display.Write("▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌ ", 87, 12);
            List<string> bang = new List<string>();
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     1.Nhập Thông Tin Môn Học        ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     2.Hiển Thị Thông Tin Môn Học    ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     3.Tìm Kiếm Thông Tin Môn Học    ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     4.Sửa Thông Tin Môn Học         ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     5.Xóa Thông Tin Môn Học         ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     6.Trở Lại Trang Trước           ║");
            bang.Add("╚═════════════════════════════════════╝");
            Menu menu = new Menu(bang);
            int index = menu.ThaoTac(80, 20);
            return (index / 3) + 1;
        }

        public void Menu()
        {
            Console.Clear();
            string check = "0";
            while (check == "0")
            {
                Display.PhanBang(1);
                int mode = ChucNang();
                switch (mode.ToString())
                {
                    case "1":
                        Console.Clear();
                        Them();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Display.PhanBang(2);
                        hienThi(100, 15);
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        timKiem(100, 15);
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        Sua();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        Xoa();
                        Console.Clear();
                        break;
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
