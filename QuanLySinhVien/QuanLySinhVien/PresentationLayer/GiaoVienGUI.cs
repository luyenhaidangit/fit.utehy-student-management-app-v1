using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.BusinessLayer;
using QuanLySinhVien.Entities;
using QuanLySinhVien.Utilities;
using QuanLySinhVien.PresentationLayer.Interface;
using QuanLySinhVien.BusinessLayer.Interface;
using System.Linq;
using System.Globalization;

namespace QuanLySinhVien.PresentationLayer
{
    public class GiaoVienGUI :IQuanLyGUI<GiangVien>
    {
        private GiangVienBLL gvBLL = new GiangVienBLL();

        #region Giao diện thêm và sửa
        CultureInfo VietNam = new CultureInfo("vi-VN");
        public void KhungNhapThongTin()
        {
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 15);
            Display.Write("║  MÃ GIÁO VIÊN  :                                ║", 25, 16);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 17);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 18);
            Display.Write("║  HỌ TÊN        :                                ║", 25, 19);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 20);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 21);
            Display.Write("║  GIỚI TÍNH     :                                ║", 25, 22);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 23);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 24);
            Display.Write("║  ĐỊA CHỈ       :                                ║", 25, 25);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 26);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 27);
            Display.Write("║  NGÀY SINH     :                                ║", 25, 28);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 29);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 30);
            Display.Write("║  SDT           :                                ║", 25, 31);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 32);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 37);
            Display.Write("║                                                 ║", 25, 38);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 39);
        }
        #endregion

        #region Thêm giáo viên
        public GiangVien NhapThem()
        {
            Display.PhanBang(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÊM THÔNG TIN GIÁO VIÊN", 40, 2);
            Console.ResetColor();
            KhungNhapThongTin();
            GiangVien gv = new GiangVien();

            //Mã giáo viên
            List<int> list = new List<int>();
            for (int i = 0; i < gvBLL.DocDuLieu().Count; i++)
            {
                list.Add(int.Parse(gvBLL.DocDuLieu()[i].MaGiangVien));
            }
            int max = list.Count != 0 ? list.Max() : 1220;

            gv.MaGiangVien = (max + 1).ToString();
            Display.Write(gv.MaGiangVien, 43, 16);

            //Tên giáo viên
            do
            {
                Console.SetCursorPosition(43, 19);
                gv.HoTen = Console.ReadLine();
                if (gv.HoTen.Length == 0 || gv.HoTen.Length > 30)
                {
                    Display.Write("Tên giáo viên không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 19);
                }
            } while (gv.HoTen.Length == 0 || gv.HoTen.Length > 30);
            Display.Write(new string(' ', 35), 26, 38);
            //Giới tính
            do
            {
                Console.SetCursorPosition(43, 22);
                gv.GioiTinh = Console.ReadLine();
                if (gv.GioiTinh.ToLower() != "nam" && gv.GioiTinh.ToLower() != "nữ")
                {
                    Display.Write("Giới tính không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 22);
                }
            } while (gv.GioiTinh.ToLower() != "nam" && gv.GioiTinh.ToLower() != "nữ");
            Display.Write(new string(' ', 35), 26, 38);
            //Địa chỉ
            do
            {
                Console.SetCursorPosition(43, 25);
                gv.DiaChi = Console.ReadLine();
                if (gv.DiaChi.Length == 0 || gv.DiaChi.Length > 30)
                {
                    Display.Write("Địa chỉ không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 25);
                }
            } while (gv.DiaChi.Length == 0 || gv.DiaChi.Length > 30);
            Display.Write(new string(' ', 35), 26, 38);
            //Ngày sinh
            bool check = true;
            do
            {
                try
                {
                    check = true;
                    Console.SetCursorPosition(43, 28);
                    gv.NgaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", VietNam);
                }
                catch (Exception)
                {
                    check = false;
                    Display.Write("Ngày sinh chỉ (dd-MM-yyyy/YYYY-mm-dd), nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 28);
                }
            } while (check == false);
            Display.Write(new string(' ', 48), 26, 38);
           
            //SDT
            do
            {
                Console.SetCursorPosition(43, 31);
                gv.Sdt = Console.ReadLine();
                if (gvBLL.SDTHopLe(gv.Sdt) == false)
                {
                    Display.Write("SDT không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 31);
                }
            } while (gvBLL.SDTHopLe(gv.Sdt) == false);
            Display.Write(new string(' ', 35), 26, 38);
            Display.Write("Thêm thông tin thành công!", 26, 38);
            return gv;
        }
        public void Them()
        {
            int check = 1;
            do
            {
                Console.Clear();
                GiangVien gv = NhapThem();
                gvBLL.Them(gv);
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

        #region Hiển thị giáo viên
        public void hienThi(int a,int b)
        {
            List<GiangVien> list = gvBLL.DocDuLieu();
            list.Reverse();
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÔNG TIN DANH SÁCH GIÁO VIÊN", 140, 2);
            Console.ResetColor();
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 6);
                table.PrintTitle(a, b + 1, "MÃ GIÁO VIÊN", "HỌ TÊN", "GIỚI TÍNH", "ĐỊA CHỈ", "NGÀY SINH", "SĐT");
                table.PrintBetweenLine(a, b + 2, 6);
                int x = a, y = b + 3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    table.PrintRow(x, y, list[i].MaGiangVien, list[i].HoTen, list[i].GioiTinh, list[i].DiaChi, list[i].NgaySinh.ToString("dd/MM/yyyy"), list[i].Sdt);
                    y++;
                }
                table.PrintLastLine(x, y, 6);
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

        #region Tìm kiếm giảng viên
        public void timKiem(int a,int b)
        {
            Console.Clear();
            Display.PhanBang(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("TÌM KIẾM THÔNG TIN GIÁO VIÊN", 40, 2);
            Display.Write("THÔNG TIN DANH SÁCH CÁC GIÁO VIÊN", 140, 2);
            Console.ResetColor();
            Display.Write("╔═════════════════════════════════════════════════════════════════════╗", 10, 15);
            Display.Write("║  NHẬP TỰ KHÓA TÌM KIẾM:                                             ║", 10, 16);
            Display.Write("╚═════════════════════════════════════════════════════════════════════╝", 10, 17);
            string id;
            Console.SetCursorPosition(35, 16);
            id = Console.ReadLine();
            List<GiangVien> list = gvBLL.timKiem(id);
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 6);
                table.PrintTitle(a, b + 1, "MÃ GIÁO VIÊN", "HỌ TÊN", "GIỚI TÍNH", "ĐỊA CHỈ", "NGÀY SINH", "SĐT");
                table.PrintBetweenLine(a, b + 2, 6);
                int x = a, y = b + 3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    if (Invalid.SoSanh(list[i].MaGiangVien, id) || Invalid.SoSanh(list[i].HoTen, id) || Invalid.SoSanh(list[i].GioiTinh, id) || Invalid.SoSanh(list[i].DiaChi, id) || Invalid.SoSanh(list[i].NgaySinh.ToString("dd/MM/yyyy"), id) || Invalid.SoSanh(list[i].Sdt, id))
                    {
                        table.PrintRowColorID(x, y, id, list[i].MaGiangVien, list[i].HoTen, list[i].GioiTinh, list[i].DiaChi, list[i].NgaySinh.ToString("dd/MM/yyyy"), list[i].Sdt);
                        y++;
                    }
                }
                table.PrintLastLine(x, y, 6);
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

        #region Sửa giảng viên
        public void Sua()
        {
            string id1;
            Display.PhanBang(2);
            hienThi(100, 15);

            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("CẬP NHẬT THÔNG TIN GIÁO VIÊN", 40, 2);
            Console.ResetColor();

            do
            {
                Display.Write("NHẬP MÃ GV CẦN ĐỔI THÔNG TIN :", 7, 44);
                Console.SetCursorPosition(37, 44);
                id1 = Console.ReadLine();
                if (gvBLL.MaGiangVienHopLe(id1) == true || id1.Length == 0)
                {
                    Display.Write("MÃ GIẢNG VIÊN KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (gvBLL.MaGiangVienHopLe(id1) == true || id1.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);


            #region Chọn thuộc tính sửa
            List<string> sua = new List<string>();
            sua.Add("╔════════════╗");
            sua.Add("║   HỌ TÊN   ║");
            sua.Add("╚════════════╝");
            sua.Add("╔════════════╗");
            sua.Add("║ GIỚI TÍNH  ║");
            sua.Add("╚════════════╝");
            sua.Add("╔════════════╗");
            sua.Add("║  ĐỊA CHỈ   ║");
            sua.Add("╚════════════╝");
            sua.Add("╔════════════╗");
            sua.Add("║  NGÀY SINH ║");
            sua.Add("╚════════════╝");
            sua.Add("╔════════════╗");
            sua.Add("║     SDT    ║");
            sua.Add("╚════════════╝");
            Menu menusua = new Menu(sua);
            int index = menusua.ThaoTac(12, 7, 15);
            int luachon = (index / 3) + 1;
            #endregion

            KhungNhapThongTin();
            GiangVien gv = gvBLL.DocDuLieu()[gvBLL.ViTri(id1)];
            //GiangVien gvnew = new GiangVien();
            //Hiện lại info
            Display.Write(gv.MaGiangVien, 43, 16);
            Display.Write(gv.HoTen, 43, 19);
            Display.Write(gv.GioiTinh, 43, 22);
            Display.Write(gv.DiaChi, 43, 25);
            Display.Write(gv.NgaySinh.ToString("dd/MM/yyyy"), 43, 28);
            Display.Write(gv.Sdt, 43, 31);
            if (luachon == 1)//Họ tên
            {
                Display.Write(new string(' ', 30), 43, 19);
                do
                {
                    Console.SetCursorPosition(43, 19);
                    gv.HoTen = Console.ReadLine();
                    if (gv.HoTen.Length == 0 || gv.HoTen.Length > 30)
                    {
                        Display.Write("Tên lớp không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 19);
                    }
                } while (gv.HoTen.Length == 0 || gv.HoTen.Length > 30);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            else if (luachon == 2)//Giới tính
            {
                Display.Write(new string(' ', 30), 43, 22);
                do
                {
                    Console.SetCursorPosition(43, 22);
                    gv.GioiTinh = Console.ReadLine();
                    if (gv.GioiTinh.ToLower() != "nam" && gv.GioiTinh.ToLower() != "nữ")
                    {
                        Display.Write("Giới tính không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 22);
                    }
                } while (gv.GioiTinh.ToLower() != "nam" && gv.GioiTinh.ToLower() != "nữ");
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            else if (luachon == 3)//Địa chỉ
            {
                //gvnew = gv;
                Display.Write(new string(' ', 30), 43, 25);
                do
                {
                    Console.SetCursorPosition(43, 25);
                    gv.DiaChi = Console.ReadLine();
                    if (gv.DiaChi.Length == 0 || gv.DiaChi.Length > 30)
                    {
                        Display.Write("Địa chỉ không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 25);
                    }
                } while (gv.DiaChi.Length == 0 || gv.DiaChi.Length > 30);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            else if (luachon == 4)//Ngày sinh
            {
                Display.Write(new string(' ', 30), 43, 28);
                bool check = true;
                do
                {
                    try
                    {
                        check = true;
                        Console.SetCursorPosition(43, 28);
                        gv.NgaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", VietNam);
                    }
                    catch (Exception)
                    {
                        check = false;
                        Display.Write("Ngày sinh chỉ (dd-MM-yyyy/YYYY-mm-dd), nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 28);
                    }
                } while (check == false);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            else 
            {
                Display.Write(new string(' ', 30), 43, 31);
                do
                {
                    Console.SetCursorPosition(43, 31);
                    gv.Sdt = Console.ReadLine();
                    if (gvBLL.SDTHopLe(gv.Sdt) == false)
                    {
                        Display.Write("SDT không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 31);
                    }
                } while (gvBLL.SDTHopLe(gv.Sdt) == false);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            gvBLL.Sua(id1, gv);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 7, 46);
            Console.ReadKey();
            Console.ReadLine();
        }
        #endregion

        #region Xóa thông giáo viên
        public void Xoa()
        {
            string id5;
            Display.PhanBang(2);
            hienThi(100, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("XÓA THÔNG TIN GIÁO VIÊN", 40, 2);
            Console.ResetColor();

            do
            {
                Display.Write("NHẬP MÃ GV CẦN XÓA THÔNG TIN :", 7, 44);
                Console.SetCursorPosition(37, 44);
                id5 = Console.ReadLine();
                if (gvBLL.MaGiangVienHopLe(id5) == true || id5.Length == 0)
                {
                    Display.Write("MÃ SINH VIÊN KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (gvBLL.MaGiangVienHopLe(id5) == true || id5.Length == 0);
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

            gvBLL.Xoa(id5);
            Display.Write("XÓA THÔNG TIN THÀNH CÔNG", 7, 44);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 7, 46);
            Console.ReadLine();
        }
        #endregion

        #region Menu quản lý sinh viên
        public int ChucNang()
        {
            Display.Write("▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌", 87, 10);
            Display.Write("▐  QUẢN LÝ GIÁO VIÊN  ▌", 87, 11);
            Display.Write("▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌", 87, 12);
            List<string> bang = new List<string>();
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     1.Nhập Thông Tin Giáo Viên      ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     2.Hiển Thị Thông Tin Giáo Viên  ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     3.Tìm Kiếm Thông Tin Giáo Viên  ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     4.Sửa Thông Tin Giáo Viên       ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     5.Xóa Thông tin Giáo Viên       ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     6.Trở Lại Trang Trước           ║");
            bang.Add("╚═════════════════════════════════════╝");
            Menu menu = new Menu(bang);
            int index = menu.ThaoTac(80,20);
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
