using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Entities;
using QuanLySinhVien.BusinessLayer;
using QuanLySinhVien.Utilities;
using QuanLySinhVien.PresentationLayer.Interface;


namespace QuanLySinhVien.PresentationLayer
{

    public class DiemSoGUI :IQuanLyGUI<DiemSo>
    {
        private DiemSoBLL dsBLL = new DiemSoBLL();

        #region Thêm điểm số
        public void KhungNhapThongTin()
        {
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 15);
            Display.Write("║  MÃ SINH VIÊN  :                                ║", 25, 16);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 17);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 18);
            Display.Write("║  MÃ MÔN HỌC    :                                ║", 25, 19);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 20);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 21);
            Display.Write("║  ĐIỂM QUÁ TRÌNH:                                ║", 25, 22);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 23);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 24);
            Display.Write("║  ĐIỂM KTHP     :                                ║", 25, 25);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 26);
            Display.Write("╔═════════════════════════════════════════════════╗", 25, 37);
            Display.Write("║                                                 ║", 25, 38);
            Display.Write("╚═════════════════════════════════════════════════╝", 25, 39);
        }

        public void Them()
        {
            int check = 1;
            int check1 = 0;
            int check2 = 1;

            #region Lựa chọn cách nhập
            Display.PhanBang(2);
            hienThi(100, 15);
            Display.Write("BẠN MUỐN NHẬP ĐIỂM SỐ THEO?", 30, 42);
            List<string> bang1 = new List<string>();
            bang1.Add("╔══════════╗");
            bang1.Add("║ CÁ NHÂN  ║");
            bang1.Add("╚══════════╝");
            bang1.Add("╔══════════╗");
            bang1.Add("║ LỚP HỌC  ║");
            bang1.Add("╚══════════╝");
            Menu menu1 = new Menu(bang1);
            int index1 = menu1.ThaoTac(30, 44, 20);
            check1 = (index1 / 3) + 1;
            #endregion

            #region Nhập cá nhân
            if (check1 == 1)
            {
                do
                {
                    Console.Clear();
                    DiemSo ds1 = NhapThem();
                    dsBLL.Them(ds1);
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
                    int index = menu.ThaoTac(30, 44, 20);
                    check = (index / 3) + 1;
                } while (check == 1);
            }
            #endregion

            #region Nhập lớp
            else
            {
                Console.Clear();
                Display.PhanBang(2);
                NhapThemList(NhapMaLop(),NhapMaMon());
            }
            #endregion
        }

        public DiemSo NhapThem()
        {
            Display.PhanBang(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÊM THÔNG TIN ĐIỂM SỐ", 40, 2);
            Console.ResetColor();
            KhungNhapThongTin();

            DiemSo ds = new DiemSo();
            //Mã sinh viên
            do
            {
                SinhVienGUI svGUI = new SinhVienGUI();
                svGUI.hienThi(100, 15);
                Console.SetCursorPosition(43, 16);
                ds.MaSinhVien = Console.ReadLine();
                if (dsBLL.MaSinhVienHopLe(ds.MaSinhVien) == false || ds.MaSinhVien.Length == 0)
                {
                    Display.Write("Mã sinh viên không tồn tại, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 16);
                }
            } while (dsBLL.MaSinhVienHopLe(ds.MaSinhVien) == false || ds.MaSinhVien.Length == 0);
            Display.Write(new string(' ', 38), 26, 38);
            //Mã môn học
            do
            {
                MonHocGUI mhGUI = new MonHocGUI();
                mhGUI.hienThi(100, 15);
                Console.SetCursorPosition(43, 19);
                ds.MaMonHoc = Console.ReadLine();
                if (dsBLL.MaSV_MHHopLe(ds.MaSinhVien, ds.MaMonHoc) == false || ds.MaMonHoc.Length == 0)
                {
                    Display.Write("Dữ liệu trùng lặp,nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 19);
                }
                if (dsBLL.MaMonHocHopLe(ds.MaMonHoc) == false)
                {
                    Display.Write("Mã môn học không tồn tại, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 19);
                }
                
            } while (dsBLL.MaSV_MHHopLe(ds.MaSinhVien, ds.MaMonHoc) == false || dsBLL.MaMonHocHopLe(ds.MaMonHoc) == false);
            Display.Write(new string(' ', 35), 26, 38);
            //Điểm quá trình
            bool check1 = true;
            do
            {
                try
                {
                    check1 = true;
                    Console.SetCursorPosition(43, 22);
                    ds.DiemQuaTrinh = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    check1 = false;
                    Display.Write("Dữ liệu không hợp lệ, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 22);
                }
                if (ds.DiemQuaTrinh < 0 || ds.DiemQuaTrinh > 10)
                {
                    Display.Write("Điểm chỉ từ 0 đến 10, nhập lại", 26, 38);
                    Display.Write(new string(' ', 30), 43, 22);
                }
            } while (ds.DiemQuaTrinh < 0 || ds.DiemQuaTrinh > 10||check1==false);
            Display.Write(new string(' ', 35), 26, 38);
            //Điểm KTHP
            if(ds.DiemQuaTrinh<5)
            {
                ds.DiemKTHP = 0;
                Display.Write("0", 43, 25);
            }
            else
            {
                bool check = true;
                do
                {

                    try
                    {
                        check = true;
                        Console.SetCursorPosition(43, 25);
                        ds.DiemKTHP = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        check = false;
                        Display.Write("Dữ liệu không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 25);
                    }
                    if (ds.DiemKTHP < 0 || ds.DiemKTHP > 10)
                    {
                        Display.Write("Điểm chỉ từ 0 đến 10, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 25);
                    }
                } while (ds.DiemKTHP < 0 || ds.DiemKTHP > 10 || check == false);
                Display.Write(new string(' ', 35), 26, 38);
            }
            
            Display.Write("Thêm thông tin thành công!", 26, 38);
            return ds;
        }

        public string NhapMaLop()
        {
            LopHocGUI lhGUI = new LopHocGUI();
            
            lhGUI.hienThi(100, 15);
            string id2;
            do
            {
                Display.Write("NHẬP MÃ LỚP CẦN ĐỔI THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(37, 44);
                id2 = Console.ReadLine();
                if (dsBLL.MaLopHopLe(id2) == false || id2.Length == 0)
                {
                    Display.Write("MÃ LỚP KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (dsBLL.MaLopHopLe(id2) == false || id2.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            return id2;
        }
        public string NhapMaMon()
        {
            MonHocGUI mhGUI = new MonHocGUI();

            mhGUI.hienThi(100, 15);
            string id3;
            do
            {
                Display.Write("NHẬP MÃ MÔN HỌC CẦN ĐỔI THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(41, 44);
                id3 = Console.ReadLine();
                if (dsBLL.MaMonHocHopLe(id3) == false)
                {
                    Display.Write("MÃ MÔN KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }

            } while (dsBLL.MaMonHocHopLe(id3) == false);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            return id3;
        }

        public void NhapThemList(string idlop,string idmon)
        {
            //string id2, id3;
            //LopHocBLL lhBLL = new LopHocBLL();
            //LopHocGUI lhGUI = new LopHocGUI();
            //lhGUI.hienThi(100, 15);


            //do
            //{
            //    Display.Write("NHẬP MÃ LỚP CẦN ĐỔI THÔNG TIN:", 7, 44);
            //    Console.SetCursorPosition(37, 44);
            //    id2 = Console.ReadLine();
            //    if (dsBLL.MaLopHopLe(id2) == false || id2.Length == 0)
            //    {
            //        Display.Write("MÃ LỚP KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
            //        Display.Write(new string(' ', 60), 37, 44);
            //    }
            //} while (dsBLL.MaLopHopLe(id2) == false || id2.Length == 0);
            //Display.Write(new string(' ', 60), 7, 44);
            //Display.Write(new string(' ', 60), 7, 46);
            //do
            //{
            //    Display.Write("NHẬP MÃ MÔN HỌC CẦN ĐỔI THÔNG TIN:", 7, 44);
            //    Console.SetCursorPosition(41, 44);
            //    id3 = Console.ReadLine();
            //    if (dsBLL.MaMonHocHopLe(id3) == false)
            //    {
            //        Display.Write("MÃ MÔN KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
            //        Display.Write(new string(' ', 60), 37, 44);
            //    }

            //} while (dsBLL.MaMonHocHopLe(id3) == false);
            //Display.Write(new string(' ', 60), 7, 44);
            //Display.Write(new string(' ', 60), 7, 46);

            KhungNhapThongTin();
            SinhVienBLL svBLL = new SinhVienBLL();
            List<SinhVien> list = svBLL.ListSinhVien_MaLop(idlop);
            for (int i = 0; i < list.Count; i++)
            {
                Display.Write(new string(' ', 50), 25, 13, ConsoleColor.DarkGreen);
                Display.Write("BẠN ĐANG NHẬP ĐIỂM CHO SINH VIÊN " + list[i].HoTen.ToUpper(), 25, 13, ConsoleColor.DarkGreen);

                if (dsBLL.BangDiemHoanThien_SinhVienMaMonHoc(list[i].MaSinhVien,idmon)==false)
                {
                    DiemSo ds = new DiemSo();

                    Display.Write(new string(' ', 30), 7, 42);
                    Display.Write(new string(' ', 30), 43, 16);
                    Display.Write(new string(' ', 30), 43, 19);
                    Display.Write(new string(' ', 30), 43, 22);
                    Display.Write(new string(' ', 30), 43, 25);
                    Display.Write(new string(' ', 35), 26, 38);
                   
                    Display.Write(list[i].MaSinhVien, 43, 16);
                    Display.Write(idmon, 43, 19);
                    ds.MaSinhVien = list[i].MaSinhVien;
                    ds.MaMonHoc = idmon;
                    bool check = true;
                    do
                    {
                        try
                        {
                            check = true;
                            Console.SetCursorPosition(43, 22);
                            ds.DiemQuaTrinh = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            check = false;
                            Display.Write("Dữ liệu không hợp lệ, nhập lại", 26, 38);
                            Display.Write(new string(' ', 30), 43, 22);
                        }
                        if (ds.DiemQuaTrinh < 0 || ds.DiemQuaTrinh > 10)
                        {
                            Display.Write("Điểm chỉ từ 0 đến 10, nhập lại", 26, 38);
                            Display.Write(new string(' ', 30), 43, 22);
                        }
                    } while (ds.DiemQuaTrinh < 0 || ds.DiemQuaTrinh > 10||check==false);
                    Display.Write(new string(' ', 35), 26, 38);
                    //Điểm KTHP
                    if(ds.DiemQuaTrinh<5)
                    {
                        ds.DiemKTHP = 0;
                        Display.Write("0", 43, 25);

                    }
                    else
                    {
                        bool check1 = true;
                        do
                        {
                            try
                            {
                                check1 = true;
                                Console.SetCursorPosition(43, 25);
                                ds.DiemKTHP = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                check1 = false;
                                Display.Write("Dữ liệu không hợp lệ, nhập lại", 26, 38);
                                Display.Write(new string(' ', 30), 43, 25);
                            }
                            if (ds.DiemKTHP < 0 || ds.DiemKTHP > 10 || check1 == false)
                            {
                                Display.Write("Điểm chỉ từ 0 đến 10, nhập lại", 26, 38);
                                Display.Write(new string(' ', 30), 43, 25);
                            }
                        } while (ds.DiemKTHP < 0 || ds.DiemKTHP > 10);
                        Display.Write(new string(' ', 35), 26, 38);
                    }
                    dsBLL.Them(ds);
                    Display.Write("Thêm thông tin thành công!", 26, 38);
                    Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 30, 45);
                    Console.ReadKey();

                }
                else
                {
                    Display.Write(new string(' ', 30), 43, 16);
                    Display.Write(new string(' ', 30), 43, 19);
                    Display.Write(new string(' ', 30), 43, 22);
                    Display.Write(new string(' ', 30), 43, 25);
                    Display.Write(new string(' ', 35), 26, 38);
                    DiemSo ds = dsBLL.DiemSo_MaSinhVien(list[i].MaSinhVien,idmon);

                    Display.Write(list[i].MaSinhVien, 43, 16);
                    Display.Write(idmon, 43, 19);
                    Display.Write(ds.DiemQuaTrinh.ToString(), 43, 22);
                    Display.Write(ds.DiemKTHP.ToString(), 43, 25);

                    Display.Write("Sinh viên đã có điểm môn học!", 26, 38);
                    Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 30, 45);
                    Console.ReadKey();
                }
                
            }
            
        }
        #endregion

        #region Hiển thị
        public void hienThi(int a,int b)
        {
            List<DiemSo> list = dsBLL.DocDuLieu();
            list.Reverse();
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("THÔNG TIN DANH SÁCH ĐIỂM SỐ", 140, 2);
            Console.ResetColor();
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 4);
                table.PrintTitle(a, b + 1, "MÃ SINH VIÊN", "MÃ MÔN HỌC", "ĐIỂM QUÁ TRÌNH", "ĐIỂM KTHP");
                table.PrintBetweenLine(a, b + 2, 4);
                int x = a, y = b + 3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    table.PrintRow(x, y, list[i].MaSinhVien, list[i].MaMonHoc, list[i].DiemQuaTrinh.ToString(), list[i].DiemKTHP.ToString());
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
            Display.Write("TÌM KIẾM THÔNG TIN ĐIỂM SỐ", 40, 2);
            Display.Write("THÔNG TIN DANH SÁCH CÁC ĐIỂM SỐ", 140, 2);
            Console.ResetColor();
            Display.Write("╔═════════════════════════════════════════════════════════════════════╗", 10, 15);
            Display.Write("║  NHẬP TỰ KHÓA TÌM KIẾM:                                             ║", 10, 16);
            Display.Write("╚═════════════════════════════════════════════════════════════════════╝", 10, 17);
            string id;
            Console.SetCursorPosition(35, 16);
            id = Console.ReadLine();
            List<DiemSo> list = dsBLL.timKiem(id);
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                #region Hiển thị bảng
                Table table = new Table(105);
                table.PrintHeadLine(a, b, 4);
                table.PrintTitle(a, b + 1, "MÃ SINH VIÊN", "MÃ MÔN HỌC", "ĐIỂM QUÁ TRÌNH", "ĐIỂM KTHP");
                table.PrintBetweenLine(a, b + 2, 4);
                int x = a, y = b + 3;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    if (Invalid.SoSanh(list[i].MaSinhVien, id) || Invalid.SoSanh(list[i].MaMonHoc, id) || Invalid.SoSanh(list[i].DiemQuaTrinh.ToString(), id) || Invalid.SoSanh(list[i].DiemKTHP.ToString(), id))
                    {
                        table.PrintRowColorID(x, y, id, list[i].MaSinhVien, list[i].MaMonHoc, list[i].DiemQuaTrinh.ToString(), list[i].DiemKTHP.ToString());
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
        public void Sua()
        {
            Display.PhanBang(2);
            hienThi(100, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("CẬP NHẬT THÔNG TIN ĐIỂM SỐ", 40, 2);
            Console.ResetColor();

            #region Nhập mã sửa
            string idsv, idmh;
            do
            {
                Display.Write("NHẬP MÃ SV CẦN ĐỔI THÔNG TIN :", 7, 44);
                Console.SetCursorPosition(37, 44);
                idsv = Console.ReadLine();
                if (dsBLL.MaSinhVienHopLe(idsv) == false || idsv.Length == 0)
                {
                    Display.Write("MÃ SINH VIÊN KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (dsBLL.MaSinhVienHopLe(idsv) == false || idsv.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            do
            {
                Display.Write("NHẬP MÃ MÔN HỌC CẦN ĐỔI THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(41, 44);
                idmh = Console.ReadLine();
                if (dsBLL.MaMonHocHopLe(idmh) == false)
                {
                    Display.Write("MÃ MÔN HỌC KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
                if (dsBLL.MaSV_MHHopLe(idsv, idmh) == true)
                {
                    Display.Write("DỮ LIỆU KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (dsBLL.MaSV_MHHopLe(idsv, idmh) == true || dsBLL.MaMonHocHopLe(idmh) == false);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            #endregion

            #region Chọn thuộc tính sửa
            List<string> sua = new List<string>();
            sua.Add("╔══════════════════╗");
            sua.Add("║  ĐIỂM QUÁ TRÌNH  ║");
            sua.Add("╚══════════════════╝");
            sua.Add("╔══════════════════╗");
            sua.Add("║     ĐIỂM KTHP    ║");
            sua.Add("╚══════════════════╝");
            Menu menusua = new Menu(sua);
            int index = menusua.ThaoTac(28, 7, 25);
            int luachon = (index / 3) + 1;
            #endregion

            KhungNhapThongTin();
            DiemSo ds = dsBLL.DocDuLieu()[dsBLL.ViTri(idsv, idmh)];
            DiemSo dsnew = new DiemSo();
            //Hiện lại info
            Display.Write(ds.MaSinhVien, 43, 16);
            Display.Write(ds.MaMonHoc, 43, 19);
            Display.Write(ds.DiemQuaTrinh.ToString(), 43, 22);
            Display.Write(ds.DiemKTHP.ToString(), 43, 25);
            if (luachon == 1)//Điểm quá trình
            {
                dsnew = ds;
                Display.Write(new string(' ', 30), 43, 22);
                do
                {
                    try
                    {
                        Console.SetCursorPosition(43, 22);
                        dsnew.DiemQuaTrinh = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Display.Write("Dữ liệu không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 22);
                    }
                    if (dsnew.DiemQuaTrinh < 0 || dsnew.DiemQuaTrinh > 10)
                    {
                        Display.Write("Điểm chỉ từ 0 đến 10, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 22);
                    }
                } while (dsnew.DiemQuaTrinh < 0 || dsnew.DiemQuaTrinh > 10);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            else//Điểm KTHP
            {
                dsnew = ds;
                Display.Write(new string(' ', 30), 43, 25);
                do
                {
                    try
                    {
                        Console.SetCursorPosition(43, 25);
                        dsnew.DiemKTHP = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Display.Write("Dữ liệu không hợp lệ, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 25);
                    }
                    if (dsnew.DiemKTHP < 0 || dsnew.DiemKTHP > 10)
                    {
                        Display.Write("Điểm chỉ từ 0 đến 10, nhập lại", 26, 38);
                        Display.Write(new string(' ', 30), 43, 25);
                    }
                } while (ds.DiemKTHP < 0 || ds.DiemKTHP > 10);
                Display.Write("Sửa thông tin thành công!", 26, 38);
            }
            dsBLL.Sua(idsv, idmh, dsnew);
            Display.Write("NHẤN PHÍM BẤT KÌ ĐỂ TIẾP TỤC", 7, 46);
            Console.ReadKey();
        }
        #endregion

        #region Xóa 
        public void Xoa()
        {
            string idsv, idmh;
            Display.PhanBang(2);
            hienThi(100, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.Write("XÓA THÔNG TIN ĐIỂM SỐ", 40, 2);
            Console.ResetColor();

            #region Nhập mã cần xóa
            do
            {
                Display.Write("NHẬP MÃ SV CẦN ĐỔI THÔNG TIN :", 7, 44);
                Console.SetCursorPosition(37, 44);
                idsv = Console.ReadLine();
                if (dsBLL.MaSinhVienHopLe(idsv) == false || idsv.Length == 0)
                {
                    Display.Write("MÃ SINH VIÊN KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (dsBLL.MaSinhVienHopLe(idsv) == false || idsv.Length == 0);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            do
            {
                Display.Write("NHẬP MÃ MÔN HỌC CẦN ĐỔI THÔNG TIN:", 7, 44);
                Console.SetCursorPosition(41, 44);
                idmh = Console.ReadLine();
                if (dsBLL.MaMonHocHopLe(idmh) == false)
                {
                    Display.Write("MÃ MÔN HỌC KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
                if (dsBLL.MaSV_MHHopLe(idsv, idmh) == true)
                {
                    Display.Write("DỮ LIỆU KHÔNG TỒN TẠI, NHẬP LẠI", 7, 46);
                    Display.Write(new string(' ', 60), 37, 44);
                }
            } while (dsBLL.MaSV_MHHopLe(idsv, idmh) == true || dsBLL.MaMonHocHopLe(idmh) == false);
            Display.Write(new string(' ', 60), 7, 44);
            Display.Write(new string(' ', 60), 7, 46);
            #endregion

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

            dsBLL.Xoa(idsv,idmh);
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
            Display.Write("▐   QUẢN LÝ ĐIỂM SỐ   ▌", 87, 11);
            Display.Write("▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌ ", 87, 12);
            List<string> bang = new List<string>();
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     1.Nhập Thông Tin Điểm Số        ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     2.Hiển Thị Thông Tin Điểm Số    ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     3.Tìm Kiếm Thông Tin Điểm Số    ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     4.Sửa Thông Tin Điểm Số         ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║     5.Xóa Thông Tin Điểm Số         ║");
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
                        Console.WriteLine("\t\tSai cú pháp!");
                        break;
                }
            }
        }
        #endregion
    }

}
