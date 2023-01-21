using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.BusinessLayer;
using QuanLySinhVien.Entities;
using QuanLySinhVien.Utilities;
using System.Threading;
using QuanLySinhVien.PresentationLayer.Interface;

namespace QuanLySinhVien.PresentationLayer
{
    public class LopHocGUI : IQuanLyGUI<LopHoc>
    {
        private LopHocBLL lhBLL = new LopHocBLL();

        #region Thêm lớp
        public void KhungNhapThongTin()
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

        public LopHoc NhapThem()
        {
            Display.PhanBang(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÊM THÔNG TIN LỚP HỌC", 40, 2);
            Console.ResetColor();
            KhungNhapThongTin();
            LopHoc lh = new LopHoc();
            //Mã lớp
            do
            {
                Console.SetCursorPosition(43, 16);
                lh.MaLop = Console.ReadLine();
                if (lhBLL.MaLopHopLe(lh.MaLop) == false)
                {
                    Display.Write("Mã lớp đã tồn tại, nhập lại", 26, 26);
                    Display.Write(new string(' ', 30), 43, 16);

                }
            } while (lhBLL.MaLopHopLe(lh.MaLop) == false);
            Display.Write(new string(' ', 45), 26, 26);

            //Tên lớp
            do
            {
                Console.SetCursorPosition(43, 19);
                lh.TenLop = Console.ReadLine();
                if (lh.TenLop.Length == 0 || lh.TenLop.Length > 10)
                {
                    Display.Write("Tên lớp không hợp lệ, nhập lại", 26, 26);
                    Display.Write(new string(' ', 30), 43, 19);
                }
            } while (lh.TenLop.Length == 0 || lh.TenLop.Length > 10);
            Display.Write(new string(' ', 45), 26, 26);

            //Chuyên ngành
            do
            {
                Console.SetCursorPosition(43, 22);
                lh.ChuyenNganh = Console.ReadLine();
                if (lhBLL.ChuyenNganhHopLe(lh.ChuyenNganh) == false)
                {
                    Display.Write("Tên chuyên ngành không hợp lệ, nhập lại", 26, 26);
                    Display.Write(new string(' ', 30), 43, 22);
                }
            } while (lhBLL.ChuyenNganhHopLe(lh.ChuyenNganh) == false);
            Display.Write(new string(' ', 45), 26, 26);

            Display.Write("Thêm thông tin thành công!", 26, 26);
            return lh;
        }

        public void Them()
        {
            int check = 1;
            do
            {
                Console.Clear();
                LopHoc lh = NhapThem();
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
            } while (check==1);
            Display.Write(new string(' ', 60), 30, 42);
            Display.Write(new string(' ', 60), 30, 44);
            Display.Write(new string(' ', 60), 30, 45);
            Display.Write(new string(' ', 60), 30, 46);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 30, 45);
            Console.ReadLine();
        }
        #endregion

        #region Hiển thị lớp
        public void hienThi(int a,int b)
        {
            SinhVienBLL svBLL = new SinhVienBLL();
            List<LopHoc> list = lhBLL.DocDuLieu();
            list.Reverse();
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÔNG TIN DANH SÁCH CÁC LỚP HỌC", 140, 2);
            Console.ResetColor();
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 4);
                table.PrintTitle(a, b+1, "MÃ LỚP", "TÊN LỚP", "CHUYÊN NGÀNH","SĨ SỐ");
                table.PrintBetweenLine(a, b+2, 4);
                int x = a, y = b+3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    table.PrintRow(x, y, list[i].MaLop, list[i].TenLop, list[i].ChuyenNganh,svBLL.ListSinhVien_MaLop(list[i].MaLop).Count.ToString());
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

        #region Tìm kiếm lớp
        public void timKiem(int a,int b)
        {
            Console.Clear();
            Display.PhanBang(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("TÌM KIẾM THÔNG TIN LỚP HỌC", 40, 2);
            Display.Write("THÔNG TIN DANH SÁCH CÁC LỚP HỌC", 140, 2);
            Console.ResetColor();
            Display.Write("╔═════════════════════════════════════════════════════════════════════╗", 10, 15);
            Display.Write("║  NHẬP TỰ KHÓA TÌM KIẾM:                                             ║", 10, 16);
            Display.Write("╚═════════════════════════════════════════════════════════════════════╝", 10, 17);
            string id;
            Console.SetCursorPosition(35, 16);
            id = Console.ReadLine();
            List<LopHoc> list = lhBLL.timKiem(id);
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 3);
                table.PrintTitle(a, b+1, "MÃ LỚP", "TÊN LỚP", "CHUYÊN NGÀNH");
                table.PrintBetweenLine(a, b+2, 3);
                int x = a, y = b+3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    if (Invalid.SoSanh(list[i].MaLop, id) || Invalid.SoSanh(list[i].TenLop, id) || Invalid.SoSanh(list[i].ChuyenNganh, id))
                    {
                        table.PrintRowColorID(x, y, id, list[i].MaLop, list[i].TenLop, list[i].ChuyenNganh);
                        y++;
                    }
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

        #region Sửa lớp
        public void Sua()
        {
            string id3;
            Display.PhanBang(2);
            hienThi(100, 15);
            Display.Write("CẬP NHẬT THÔNG TIN LỚP HỌC", 40, 2,ConsoleColor.Blue);

            #region Nhập thông tin
            do
            {
                Display.Write("NHẬP MÃ LỚP CẦN ĐỔI THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(37, 44);
                id3 = Console.ReadLine();
                if (lhBLL.MaLopHopLe(id3) == true || id3.Length == 0)
                {
                    Display.Write("MÃ LỚP KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (lhBLL.MaLopHopLe(id3) == true || id3.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            #endregion

            #region Chọn thuộc tính
            List<string> sua = new List<string>();
            sua.Add("╔═══════════════╗");
            sua.Add("║    TÊN LỚP    ║");
            sua.Add("╚═══════════════╝");
            sua.Add("╔═══════════════╗");
            sua.Add("║ CHUYÊN NGÀNH  ║");
            sua.Add("╚═══════════════╝");
            Menu menusua = new Menu(sua);
            int index = (menusua.ThaoTac(30, 7, 20) / 3) + 1;
            #endregion

            KhungNhapThongTin();
            LopHoc lh = lhBLL.DocDuLieu()[lhBLL.ViTri(id3)];
            //Hiện lại info
            Display.Write(lh.MaLop, 43, 16);
            Display.Write(lh.TenLop, 43, 19);
            Display.Write(lh.ChuyenNganh, 43, 22);
            int luachon = index;
            if (luachon == 1)//Tên lớp
            {
                Display.Write(new string(' ', 30), 43, 19);
                do
                {
                    Console.SetCursorPosition(43, 19);
                    lh.TenLop = Console.ReadLine();
                    if (lh.TenLop.Length == 0 || lh.TenLop.Length > 10)
                    {
                        Display.Write("Tên lớp không hợp lệ, nhập lại", 26, 26);
                        Display.Write(new string(' ', 30), 43, 19);
                    }
                } while (lh.TenLop.Length == 0 || lh.TenLop.Length > 10);
                Display.Write("Sửa thông tin thành công!", 26, 26);
            }
            else//Chuyên ngành
            {
                Display.Write(new string(' ', 30), 43, 22);
                do
                {
                    Console.SetCursorPosition(43, 22);
                    lh.ChuyenNganh = Console.ReadLine();
                    if (lhBLL.ChuyenNganhHopLe(lh.ChuyenNganh) == false)
                    {
                        Display.Write("Tên chuyên ngành không hợp lệ, nhập lại", 26, 26);
                        Display.Write(new string(' ', 30), 43, 22);
                    }
                } while (lhBLL.ChuyenNganhHopLe(lh.ChuyenNganh) == false);
                Display.Write("Sửa thông tin thành công!", 26, 26);
            }
            lhBLL.Sua(id3, lh);
            Display.Write("SỬA THÔNG TIN THÀNH CÔNG", 7, 44);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 7, 46);
            Console.ReadLine();
        }
        #endregion

        #region Xóa lớp
        public void Xoa()
        {
            string id5;
            Display.PhanBang(2);
            hienThi(100, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("XÓA THÔNG TIN LỚP HỌC", 40, 2);
            Console.ResetColor();

            #region Nhập thông tin
            do
            {
                Display.Write("NHẬP MÃ LỚP CẦN XÓA THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(37, 44);
                id5 = Console.ReadLine();
                if (lhBLL.MaLopHopLe(id5) == true || id5.Length == 0)
                {
                    Display.Write("MÃ LỚP KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (lhBLL.MaLopHopLe(id5) == true || id5.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            Console.ForegroundColor = ConsoleColor.Red;
            Display.Write("╔════════════════════════════════════════════════════════════════════════╗", 10, 7);
            Display.Write("║  CẢNH BÁO: XÓA DỮ LIỆU CỦA LỚP HỌC CÓ THỂ ẢNH HƯỞNG TỚI DỮ LIỆU SINH   ║", 10, 8);
            Display.Write("║  VIÊN, ĐIỂM THI, LỊCH HỌC,...                                          ║", 10, 9);
            Display.Write("║  NHẤN ESC ĐỂ DỪNG HOẶC NHẤN BẤT KÌ ĐỂ XÁC NHẬN XÓA                     ║", 10, 10);
            Display.Write("╚════════════════════════════════════════════════════════════════════════╝", 10, 11);
            Console.ResetColor();

            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {

                Menu();
            }

            #endregion

            lhBLL.Xoa(id5);
            Display.Write("XÓA THÔNG TIN THÀNH CÔNG", 7, 44);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 7, 46);
            Console.ReadLine();
        }
        #endregion

        #region Menu
        public void Menu()
        {
            Console.Clear();
            string check = "0";
            while (check == "0")
            {
                Display.PhanBang(1);
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
                int index1 = menu.ThaoTac(80, 20);
                int mode = (index1/3)+1;
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
                        hienThi(100,15);
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        timKiem(100,15);
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