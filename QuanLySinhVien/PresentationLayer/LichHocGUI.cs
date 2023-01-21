using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Entities;
using QuanLySinhVien.BusinessLayer;
using QuanLySinhVien.Utilities;
using QuanLySinhVien.PresentationLayer.Interface;

namespace QuanLySinhVien.PresentationLayer
{
    class LichHocGUI
    {
        private LichHocBLL lhBLL = new LichHocBLL();

        #region Thêm lịch học
        public void KhungNhapThongTin()
        {
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 15);
            Display.Write("║  MÃ LỚP HỌC    :                                ║", 25, 16);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 17);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 18);
            Display.Write("║  MÃ MÔN HỌC    :                                ║", 25, 19);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 20);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 21);
            Display.Write("║  MÃ GIÁO VIÊN  :                                ║", 25, 22);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 23);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 24);
            Display.Write("║  HỌC KỲ        :                                ║", 25, 25);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 26);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 37);
            Display.Write("║                                                 ║", 25, 38);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 39);
        }

        public LichHoc NhapThem()
        {
            Display.PhanBang(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÊM THÔNG TIN LỊCH HỌC", 40, 2);
            Console.ResetColor();
            KhungNhapThongTin();
            LichHoc lh = new LichHoc();
            //Mã lớp
            do
            {
                LopHocGUI lhGUI = new LopHocGUI();
                lhGUI.hienThi(100, 15);
                Console.SetCursorPosition(43, 16);
                lh.MaLopHoc = Console.ReadLine();
                if (lhBLL.MaLopHopLe(lh.MaLopHoc) == false)
                {
                    Display.Write("Mã lớp không tồn tại, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 16);
                }
            } while (lhBLL.MaLopHopLe(lh.MaLopHoc) == false);
            Display.Write(new string(' ', 35), 26, 38);
            //Mã môn
            do
            {
                MonHocGUI mhGUI = new MonHocGUI();
                mhGUI.hienThi(100, 15);
                Console.SetCursorPosition(43, 19);
                lh.MaMonHoc = Console.ReadLine();
                if (lhBLL.MaMonHocHopLe(lh.MaMonHoc) == false)
                {
                    Display.Write("Mã môn học không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 19);
                }
                if (lhBLL.MaHopLe(lh.MaLopHoc,lh.MaMonHoc) == true)
                {
                    Display.Write("Dữ liệu bị trùng lặp, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 19);
                }
            } while (lhBLL.MaMonHocHopLe(lh.MaMonHoc) == false || lhBLL.MaHopLe(lh.MaLopHoc, lh.MaMonHoc) == true);
            Display.Write(new string(' ', 35), 26, 38);
            //Mã giáo viên
            do
            {
                GiaoVienGUI gvGUI = new GiaoVienGUI();
                gvGUI.hienThi(100, 15);
                Console.SetCursorPosition(43, 22);
                lh.MaGiaoVien = Console.ReadLine();
                if (lhBLL.MaGiaoVienHopLe(lh.MaGiaoVien) == true)
                {
                    Display.Write("Mã giáo viên không tồn tại, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 22);
                }
            } while (lhBLL.MaGiaoVienHopLe(lh.MaGiaoVien) == true);
            Display.Write(new string(' ', 35), 26, 38);
            //Kỳ học
            bool check = true;
            do
            {
                try
                {
                    check = true;
                    Console.SetCursorPosition(43, 25);
                    lh.HocKy = int.Parse(Console.ReadLine());
                }catch(Exception)
                {
                    check = false;
                    Display.Write("Dữ liệu không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 25);
                }
                if (lh.HocKy < 1 || lh.HocKy > 8)
                {
                    
                    Display.Write("Học kỳ không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 25);
                }
            } while (lh.HocKy < 1 || lh.HocKy > 8||check == false);
            Display.Write(new string(' ', 35), 26, 38);
            Display.Write("Thêm thông tin thành công!", 26, 38);
            return lh;

        }

        public void Them()
        {
            int check = 1;
            do
            {
                Console.Clear();
                LichHoc lh = NhapThem();
                lhBLL.Them(lh);
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
            List<LichHoc> list = lhBLL.DocDuLieu();
            list.Reverse();
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÔNG TIN DANH SÁCH LỊCH HỌC", 140, 2);
            Console.ResetColor();
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 4);
                table.PrintTitle(a, b + 1, "MÃ LỚP HỌC", "MÃ MÔN HỌC", "MÃ GIÁO VIÊN", "HỌC KỲ");
                table.PrintBetweenLine(a, b + 2, 4);
                int x = a, y = b + 3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    table.PrintRow(x, y, list[i].MaLopHoc, list[i].MaMonHoc, list[i].MaGiaoVien, list[i].HocKy.ToString());
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

        #region Tìm kiếm
        public void timKiem(int a,int b)
        {
            Console.Clear();
            Display.PhanBang(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("TÌM KIẾM THÔNG TIN LỊCH HỌC", 40, 2);
            Display.Write("THÔNG TIN DANH SÁCH CÁC LỊCH HỌC", 140, 2);
            Console.ResetColor();
            Display.Write("╔═════════════════════════════════════════════════════════════════════╗", 10, 15);
            Display.Write("║  NHẬP TỰ KHÓA TÌM KIẾM:                                             ║", 10, 16);
            Display.Write("╚═════════════════════════════════════════════════════════════════════╝", 10, 17);
            string id;
            Console.SetCursorPosition(35, 16);
            id = Console.ReadLine();
            List<LichHoc> list = lhBLL.timKiem(id);
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 4);
                table.PrintTitle(a, b + 1, "MÃ LỚP HỌC", "MÃ MÔN HỌC", "MÃ GIÁO VIÊN", "HỌC KỲ");
                table.PrintBetweenLine(a, b + 2, 4);
                int x = a, y = b + 3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    if (Invalid.SoSanh(list[i].MaLopHoc, id) || Invalid.SoSanh(list[i].MaMonHoc, id) || Invalid.SoSanh(list[i].MaGiaoVien, id) || Invalid.SoSanh(list[i].HocKy.ToString(), id))
                    {
                        table.PrintRowColorID(x, y, id, list[i].MaLopHoc, list[i].MaMonHoc, list[i].MaGiaoVien, list[i].HocKy.ToString());
                        y++;
                    }
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

        #region Sửa 
        public void Sua(/*string idlop,string idmon,int luachon*/)
        {
            Display.PhanBang(2);
            hienThi(100, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("CẬP NHẬT THÔNG TIN LỊCH HỌC", 40, 2);
            Console.ResetColor();

            #region Nhập mã cần sửa
            string id2, id3;
            do
            {
                Display.Write("NHẬP MÃ LỚP CẦN ĐỔI THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(37, 44);
                id2 = Console.ReadLine();
                if (lhBLL.MaLopHopLe(id2) == false || id2.Length == 0)
                {
                    Display.Write("MÃ LỚP KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (lhBLL.MaLopHopLe(id2) == false || id2.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            do
            {
                Display.Write("NHẬP MÃ MÔN HỌC CẦN ĐỔI THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(41, 44);
                id3 = Console.ReadLine();
                if (lhBLL.MaMonHocHopLe(id3) == false)
                {
                    Display.Write("MÃ MÔN KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
                if (lhBLL.MaHopLe(id2, id3) == false)
                {
                    Display.Write("DỮ LIỆU KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (lhBLL.MaMonHocHopLe(id3) == false || lhBLL.MaHopLe(id2, id3) == false);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            #endregion

            #region Chọn thuộc tính sửa
            List<string> sua = new List<string>();
            sua.Add("╔════════════╗");
            sua.Add("║  GIÁO VIÊN ║");
            sua.Add("╚════════════╝");
            sua.Add("╔════════════╗");
            sua.Add("║   HỌC KỲ   ║");
            sua.Add("╚════════════╝");
            Menu menusua = new Menu(sua);
            int index = menusua.ThaoTac(28, 7, 25);
            int luachon = (index / 3) + 1;
            #endregion


            KhungNhapThongTin();
            LichHoc lh = lhBLL.DocDuLieu()[lhBLL.ViTri(id2,id3)];
            //Hiện lại info
            Display.Write(lh.MaLopHoc, 43, 16);
            Display.Write(lh.MaMonHoc, 43, 19);
            Display.Write(lh.MaGiaoVien, 43, 22);
            Display.Write(lh.HocKy.ToString(), 43, 25);
            if (luachon == 1)//Mã giáo viên
            {
                Display.Write(new string(' ', 30), 43, 22);
                do
                {
                    GiaoVienGUI gvGUI = new GiaoVienGUI();
                    gvGUI.hienThi(100, 15);
                    Console.SetCursorPosition(43, 22);
                    lh.MaGiaoVien = Console.ReadLine();
                    if (lhBLL.MaGiaoVienHopLe(lh.MaGiaoVien) == true)
                    {
                        Display.Write("Mã giáo viên không tồn tại, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 22);
                    }
                } while (lhBLL.MaGiaoVienHopLe(lh.MaGiaoVien) == true);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            else /*(luachon==2)*///Học kỳ
            {
                Display.Write(new string(' ', 30), 43, 25);
                bool check = true;
                do
                {
                    try
                    {
                        check = true;
                        Console.SetCursorPosition(43, 25);
                        lh.HocKy = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        check = false;
                        Display.Write("Dữ liệu không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 25);
                    }
                    if (lh.HocKy < 1 || lh.HocKy > 8)
                    {
                        Display.Write("Địa chỉ không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 25);
                    }
                } while (lh.HocKy < 1 || lh.HocKy > 8);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            lhBLL.Sua(id2,id3, lh);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 7, 46);
            Console.ReadKey();
        }
        public void Sua(string idsv)
        {

        }
        #endregion

        #region Xóa 
        public void Xoa()
        {
            
            Display.PhanBang(2);
            hienThi(100, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("XÓA THÔNG TIN LỊCH HỌC", 40, 2);
            Console.ResetColor();
            string id5, id6;
            do
            {
                Display.Write("NHẬP MÃ LỚP CẦN XÓA THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(37, 44);
                id5 = Console.ReadLine();
                if (lhBLL.MaLopHopLe(id5) == false || id5.Length == 0)
                {
                    Display.Write("MÃ LỚP KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (lhBLL.MaLopHopLe(id5) == false || id5.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            do
            {
                Display.Write("NHẬP MÃ MÔN HỌC CẦN XÓA THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(41, 44);
                id6 = Console.ReadLine();
                if (lhBLL.MaMonHocHopLe(id6) == false)
                {
                    Display.Write("MÃ LỚP KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
                if (lhBLL.MaHopLe(id5, id6) == false)
                {
                    Display.Write("DỮ LIỆU KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (lhBLL.MaMonHocHopLe(id6) == false || lhBLL.MaHopLe(id5, id6) == false);
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
            lhBLL.Xoa(id5,id6);
            Display.Write("XÓA THÔNG TIN THÀNH CÔNG", 7, 44);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 7, 46);
            Console.ReadLine();
        }
        public void Xoa(string idsv)
        {

        }
        #endregion

        #region Menu
        public int ChucNang()
        {
            Display.Write("▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌", 87, 10);
            Display.Write("▐   QUẢN LÝ LỊCH HỌC  ▌", 87, 11);
            Display.Write("▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌ ", 87, 12);
            List<string> bang = new List<string>();
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     1.Nhập Thông Tin Lịch Học       ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     2.Hiển Thị Thông Tin Lịch Học   ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     3.Tìm Kiếm Thông Tin Lịch Học   ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     4.Sửa Thông Tin Lịch Học        ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     5.Xóa Thông Tin Lịch Học        ║");
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
