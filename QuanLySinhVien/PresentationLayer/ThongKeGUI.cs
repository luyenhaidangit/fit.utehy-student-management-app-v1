using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.BusinessLayer;
using QuanLySinhVien.Entities;
using QuanLySinhVien.Utilities;
using QuanLySinhVien.PresentationLayer.Interface;
using QuanLySinhVien.PresentationLayer;
using System.Linq;


namespace QuanLySinhVien.PresentationLayer
{
    class ThongKeGUI
    {
        private LopHocBLL lhBLL = new LopHocBLL();
        private SinhVienBLL svBLL = new SinhVienBLL();
        private GiangVienBLL gvBLL = new GiangVienBLL();
        private MonHocBLL mhBLL = new MonHocBLL();
        private DiemSoBLL dsBLL = new DiemSoBLL();
        private LichHocBLL lichBLL = new LichHocBLL();

        #region Thống kê sinh viên theo lớp
        public void SinhVien_MaLop(string id)
        {
            SinhVienBLL svBLL = new SinhVienBLL();
            List<SinhVien> list = svBLL.ListSinhVien_MaLop(id);
            LopHocBLL lhBLL = new LopHocBLL();
            LopHoc lh = lhBLL.LopHoc_MaLop(id);
            Display.Write("MÃ LỚP        :", 50, 44, ConsoleColor.DarkYellow); 
            Display.Write("TÊN LỚP       :", 50, 46,ConsoleColor.DarkYellow);
            Display.Write("CHUYÊN NGÀNH  :", 130, 44,ConsoleColor.DarkYellow);
            Display.Write("SĨ SỐ         :", 130, 46,ConsoleColor.DarkYellow);
            Display.Write(lh.MaLop.ToUpper(), 68, 44, ConsoleColor.DarkGreen);
            Display.Write(lh.TenLop.ToUpper(), 68, 46, ConsoleColor.DarkGreen);
            Display.Write(lh.ChuyenNganh.ToUpper(), 145, 44, ConsoleColor.DarkGreen);
            Display.Write(list.Count.ToString(), 145, 46, ConsoleColor.DarkGreen);
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                Table table = new Table(120);
                table.PrintHeadLine(45, 10, 7);
                table.PrintTitle(45, 11, "STT", "MÃ SINH VIÊN", "HỌ TÊN", "GIỚI TÍNH", "ĐỊA CHỈ", "NGÀY SINH", "SĐT");
                table.PrintBetweenLine(45, 12, 7);
                int x = 45, y = 13;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    table.PrintRow(x, y,(i+1).ToString(), list[i].MaSinhVien, list[i].HoTen, list[i].GioiTinh, list[i].DiaChi, (list[i].NgaySinh).ToString("dd/MM/yyyy"), list[i].Sdt);
                    y++;
                }
                table.PrintLastLine(x, y, 7);

                #region Xử lý trang
                y = y + 1;
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(new string(' ', 108));
                    y++;
                }
                Console.SetCursorPosition(110, 35);
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

        #region Thống kê sinh viên theo chuyên ngành
        public void SinhVien_ChuyenNganh(string chuyennganh)
        {
            SinhVienBLL svBLL = new SinhVienBLL();
            List<SinhVien> list = svBLL.ListSinhVien_ChuyenNganh(chuyennganh);
            double slsv = svBLL.DocDuLieu().Count;
            Display.Write("CHUYÊN NGÀNH  :", 50, 44, ConsoleColor.DarkYellow);
            Display.Write("SỐ LỚP        :", 50, 46, ConsoleColor.DarkYellow);
            Display.Write("SỐ SINH VIÊN  :", 130, 44, ConsoleColor.DarkYellow);
            Display.Write("TỶ LỆ KHOA    :", 130, 46, ConsoleColor.DarkYellow);
            Display.Write(chuyennganh, 68, 44, ConsoleColor.DarkGreen);
            Display.Write(lhBLL.ListMaLop_ChuyenNganh(chuyennganh).Count.ToString(), 68, 46, ConsoleColor.DarkGreen);
            Display.Write(list.Count.ToString(), 145, 44, ConsoleColor.DarkGreen);
            Display.Write(Normalize.Number((list.Count/slsv)*100).ToString()+"%", 145, 46, ConsoleColor.DarkGreen);
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                Table table = new Table(120);
                table.PrintHeadLine(45, 10, 8);
                table.PrintTitle(45, 11, "STT", "MÃ SINH VIÊN", "HỌ TÊN", "GIỚI TÍNH", "ĐỊA CHỈ", "NGÀY SINH", "SĐT","MÃ LỚP");
                table.PrintBetweenLine(45, 12, 8);
                int x = 45, y = 13;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    table.PrintRow(x, y, (i + 1).ToString(), list[i].MaSinhVien, list[i].HoTen, list[i].GioiTinh, list[i].DiaChi, (list[i].NgaySinh).ToString("dd/MM/yyyy"), list[i].Sdt,list[i].MaLop);
                    y++;
                }
                table.PrintLastLine(x, y, 8);

                #region Xử lý trang
                y = y + 1;
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(new string(' ', 108));
                    y++;
                }
                Console.SetCursorPosition(110, 35);
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

        #region Thống kê sinh viên theo địa chỉ
        public void NhanSu_DiaChi(string diachi)
        {
            SinhVienBLL svBLL = new SinhVienBLL();
            List<SinhVien> list = svBLL.ListSinhVien_DiaChi(diachi);
            GiangVienBLL gvBLL = new GiangVienBLL();
            List<GiangVien> list1 = gvBLL.ListGiangVien_DiaChi(diachi);
            int songuoi = svBLL.LayDSMaSinhVien().Count + gvBLL.LayDSMaGiangVien().Count;
            double vungdich = (list.Count + list1.Count);
            string tyle = ((vungdich / songuoi) * 100).ToString() + "%";
            Display.Write("VÙNG DỊCH                    :", 10, 44, ConsoleColor.DarkYellow);
            Display.Write("SỐ LƯỢNG NHÂN SỰ KHOA        :", 10, 46, ConsoleColor.DarkYellow);
            Display.Write("SỐ SINH VIÊN TỪ VÙNG DỊCH    :", 60, 44, ConsoleColor.DarkYellow);
            Display.Write("SỐ GIÁO VIÊN TỪ VÙNG DỊCH    :", 60, 46, ConsoleColor.DarkYellow);
            Display.Write("TỶ LỆ NHÂN SỰ TẠI VÙNG DỊCH  :", 105, 44, ConsoleColor.DarkYellow);
            Display.Write("KẾT LUẬN                     :", 105, 46, ConsoleColor.DarkYellow);
            Display.Write(diachi, 40, 44, ConsoleColor.DarkGreen);
            Display.Write(songuoi.ToString(), 40, 46, ConsoleColor.DarkGreen);
            Display.Write(svBLL.ListSinhVien_DiaChi(diachi).Count.ToString(), 90, 44, ConsoleColor.DarkGreen);
            Display.Write(gvBLL.ListGiangVien_DiaChi(diachi).Count.ToString(), 90, 46, ConsoleColor.DarkGreen);
            Display.Write(tyle, 135, 44, ConsoleColor.DarkGreen);
            string ketluan;
            if (vungdich / songuoi < 0.6)
            {
                ketluan = "AN TOÀN, SINH VIÊN ĐƯỢC HỌC TRỰC TIẾP TẠI TRƯỜNG";
                Display.Write(ketluan, 135, 46, ConsoleColor.DarkGreen);
            }
            else ketluan = "NGUY HIỂM, NÊN CHO SINH VIÊN HỌC ONLINE TẠI NHÀ"; Display.Write(ketluan, 135, 46, ConsoleColor.DarkRed);
            int curpage = 1;
            int curpage1 = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            int totalpage1 = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                Display.Write("BẢNG SINH VIÊN", 95, 8,ConsoleColor.DarkBlue);
                Table table = new Table(120);
                table.PrintHeadLine(45, 10, 8);
                table.PrintTitle(45, 11, "STT", "MÃ SINH VIÊN", "HỌ TÊN", "GIỚI TÍNH", "ĐỊA CHỈ", "NGÀY SINH", "SĐT","MÃ LỚP");
                table.PrintBetweenLine(45, 12, 8);
                int j = 45, k = 13;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                int dau1 = (curpage - 1) * 10;
                int cuoi1 = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    table.PrintRow(j, k, (i + 1).ToString(), list[i].MaSinhVien, list[i].HoTen, list[i].GioiTinh, list[i].DiaChi, (list[i].NgaySinh).ToString("dd/MM/yyyy"), list[i].Sdt,list[i].MaLop);
                    k++;
                }
                table.PrintLastLine(j, k, 8);

                #region Xử lý trang
                k = k + 1;
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(j, k);
                    Console.WriteLine(new string(' ', 108));
                    k++;
                }
                Console.SetCursorPosition(110, 35);
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
            int x = 45, y = 13;
            do
            {
                Display.Write("BẢNG GIÁO VIÊN", 95, 8, ConsoleColor.DarkBlue);
                Table table = new Table(120);
                table.PrintHeadLine(45, 10, 7);
                table.PrintTitle(45, 11, "STT", "MÃ GIÁO VIÊN", "HỌ TÊN", "GIỚI TÍNH", "ĐỊA CHỈ", "NGÀY SINH", "SĐT LIÊN HỆ");
                table.PrintBetweenLine(45, 12, 7);
                int m = 45, n = 13;
                int dau1 = (curpage1 - 1) * 10;
                int cuoi1 = curpage1 * 10 < list1.Count ? curpage1 * 10 : list1.Count;
                for (int i = dau1; i < cuoi1; i++)
                {
                    table.PrintRow(m, n, (i + 1).ToString(), list1[i].MaGiangVien, list1[i].HoTen, list1[i].GioiTinh, list1[i].DiaChi, list1[i].NgaySinh.ToString(), list1[i].Sdt);
                    n++;
                }
                table.PrintLastLine(m, n, 7);

                #region Xử lý trang
                n = n + 1;
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(m, n);
                    Console.WriteLine(new string(' ', 108));
                    n++;
                }
                Console.SetCursorPosition(110, 35);
                Console.Write("Nhấn  ◄/► để di chuyển giữa các trang:{0}     |Nhấn ENTER để tiếp tục!", curpage1 + "/" + totalpage1);
                kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.RightArrow)
                {
                    if (curpage1 < totalpage1) curpage1 = curpage1 + 1;
                    else curpage = 1;
                }
                else if (kt.Key == ConsoleKey.LeftArrow)
                {
                    if (curpage1 > 1) curpage1 = curpage1 - 1;
                    else curpage1 = totalpage1;
                }
                #endregion
            } while (kt.Key == ConsoleKey.RightArrow || kt.Key == ConsoleKey.LeftArrow);
        }
        #endregion

        #region Thống kê bảng điểm sinh viên theo mã sinh viên
        public void DiemSo_MaSinhVien(string id)
        {
            int tc = 0, tctl = 0;
            double diem = 0;
            List<DiemSo> list = dsBLL.ListDiemSo_SinhVien(id);
            SinhVien sv = svBLL.SinhVien_MaSinhVien(id);
            int curpage = 1;
            int totalpage = list.Count % 10 == 0 ? list.Count / 10 : list.Count / 10 + 1;
            ConsoleKeyInfo kt;
            do
            {
                Table table = new Table(150);
                table.PrintHeadLine(25, 10, 7);
                table.PrintTitle(25, 11, "STT", "MÃ MÔN HỌC", "TÊN MÔN HỌC", "ĐIỂM QUÁ TRÌNH", "ĐIỂM KTHP", "ĐIỂM TBHT", "ĐÁNH GIÁ");
                table.PrintBetweenLine(25, 12, 7);
                int x = 25, y = 13;
                int dau = (curpage - 1) * 10;
                int cuoi = curpage * 10 < list.Count ? curpage * 10 : list.Count;
                for (int i = dau; i < cuoi; i++)
                {
                    if(list[i].XepLoai=="Thi Lại")
                    {
                        table.PrintRowColor(x, y, (i + 1).ToString(), list[i].MaMonHoc, mhBLL.MonHoc_MaMonHoc(list[i].MaMonHoc).TenMonHoc, list[i].DiemQuaTrinh.ToString(), list[i].DiemKTHP.ToString(), list[i].DiemTB.ToString(), list[i].XepLoai);
                        tctl += mhBLL.MonHoc_MaMonHoc(list[i].MaMonHoc).SoTC;
                    }
                    else
                    {
                        table.PrintRow(x, y, (i + 1).ToString(), list[i].MaMonHoc, mhBLL.MonHoc_MaMonHoc(list[i].MaMonHoc).TenMonHoc, list[i].DiemQuaTrinh.ToString(), list[i].DiemKTHP.ToString(), list[i].DiemTB.ToString(), list[i].XepLoai);
                    }
                    tc += mhBLL.MonHoc_MaMonHoc(list[i].MaMonHoc).SoTC;
                    diem += mhBLL.MonHoc_MaMonHoc(list[i].MaMonHoc).SoTC * list[i].DiemTB;
                    y++;
                }
                table.PrintLastLine(x, y, 7);
                Display.Write("MÃ SINH VIÊN    :", 3, 44, ConsoleColor.DarkYellow);
                Display.Write("HỌ TÊN          :", 3, 46, ConsoleColor.DarkYellow);
                Display.Write("SỐ TC ĐÃ ĐẠT    :", 50, 44, ConsoleColor.DarkYellow);
                Display.Write("SỐ TC CHƯA ĐẠT  :", 50, 46, ConsoleColor.DarkYellow);
                Display.Write("TỔNG TC ĐÃ HỌC  :", 90, 44, ConsoleColor.DarkYellow);
                Display.Write("TỶ LỆ ĐẠT MÔN   :", 90, 46, ConsoleColor.DarkYellow);
                Display.Write("ĐIỂM TBCHT      :", 130, 44, ConsoleColor.DarkYellow);
                Display.Write("XẾP LOẠI        :", 130, 46, ConsoleColor.DarkYellow);
                Display.Write(sv.MaSinhVien.ToUpper(), 20, 44, ConsoleColor.DarkGreen);
                Display.Write(sv.HoTen.ToUpper(), 20, 46, ConsoleColor.DarkGreen);
                Display.Write((tc - tctl).ToString(), 67, 44, ConsoleColor.DarkGreen);
                Display.Write(tctl.ToString(), 67, 46, ConsoleColor.DarkGreen);
                Display.Write(tc.ToString(), 107, 44, ConsoleColor.DarkGreen);
                double u = (1 - (double)tctl / tc);
                Display.Write((u*100).ToString() + "%", 107, 46, ConsoleColor.DarkGreen);
                Display.Write(((double)diem / tc).ToString(), 147, 44, ConsoleColor.DarkGreen);
                Display.Write(dsBLL.XepLoai_DiemTB(diem / tc), 147, 46, ConsoleColor.DarkGreen);
                #region Xử lý trang
                y = y + 1;
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(new string(' ', 108));
                    y++;
                }
                Console.SetCursorPosition(110, 35);
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

        #region Xuất bảng điểm theo lớp
        public List<string> TitLe(string id, int ky)
        {
            List<string> list = new List<string>();
            list.Add("MÃ SINH VIÊN");
            list.Add("HỌ TÊN");
            list.AddRange(lichBLL.ListTenMonHoc_LichHoc(id, ky));
            list.Add("ĐIỂM TBHT KỲ");
            list.Add("XẾP LOẠI");
            return list;
        }
        
        public List<string> Row(string idsv,string idlop, int ky)
        {
            List<string> lich = lichBLL.ListMaMonHoc_LichHoc(idlop, ky);
            List<string> list = new List<string>();
            list.Add(idsv);
            list.Add(svBLL.HoTen_MaSinhVien(idsv));
            for (int i = 0; i < lich.Count; i++)//4x
            {
                list.AddRange(dsBLL.DiemChiTiet_SinhVienMaMonHoc(idsv, lich[i]));
            }
            list.Add(dsBLL.DiemTBHT_SinhVienKyHoc(idsv,idlop,ky).ToString());
            list.Add(dsBLL.XepLoai_DiemTB(dsBLL.DiemTBHT_SinhVienKyHoc(idsv, idlop, ky)));
            return list;
        }

        public void BangDiem_LopHoc(string idlop, int ky)
        {
            List<SinhVien> listsv = svBLL.ListSinhVien_MaLop(idlop);
            Table table = new Table(190);//180
            string[] title = TitLe(idlop, ky).ToArray();
            table.PrintHeadLine(10, 9,title.Length);
            table.PrintTitle(10,10,title);
            table.PrintBetweenLine(10, 11,title.Length);
            List<List<string>> y = new List<List<string>>();
            for(int i=0;i<listsv.Count;i++)
            {
                y.Add(Row(listsv[i].MaSinhVien, idlop, ky));
            }

            for (int i = 0; i < y.Count; i++)
            {
                for (int j = i + 1; j < y.Count; j++)
                {
                    double h = double.Parse(y[i][y[i].Count - 2]);
                    double o = double.Parse(y[j][y[j].Count - 2]);
                    if (h < o)
                    {
                        List<string> tg = new List<string>();
                        tg = y[i];
                        y[i] = y[j];
                        y[j] = tg;
                    }
                }
            }
            Display.WriteBG("     HỌC BỔNG     ", 167, 6, ConsoleColor.DarkYellow);
            double hocBong = Normalize.Number(listsv.Count * 0.5);
            int xs = 0, gioi = 0, kha = 0, luuban = 0;
            int a = 10; int b = 12;
            double tong = 0;
            for (int i = 0; i < y.Count; i++)
            {
                if (i < hocBong)
                {
                    double h = double.Parse(y[i][y[i].Count - 2]);
                    if (y[i].Contains("TL") != true && h>=7)
                    {
                        table.PrintRowSpecial(a, b, ConsoleColor.DarkYellow, y[i].ToArray());
                    }
                    else
                    {
                        table.PrintRowSpecial(a, b, ConsoleColor.Gray, y[i].ToArray());
                        hocBong++;
                    }
                }
                else
                {
                    table.PrintRowSpecial(a, b, ConsoleColor.Gray, y[i].ToArray());
                }


                tong = tong + double.Parse(y[i][y[i].Count-2]);
                if (y[i][y[i].Count - 1] == "Xuất Sắc") xs++;
                else if (y[i][y[i].Count - 1] == "Giỏi") gioi++;
                else if (y[i][y[i].Count - 1] == "Khá") kha++;
                else if (y[i][y[i].Count - 1] == "Học Lại") luuban++;
                b++;
            }
            table.PrintLastLine(a, b, title.Length);
            Display.Write("LỚP               :", 3, 44, ConsoleColor.DarkYellow);
            Display.Write("HỌC KỲ            :", 3, 46, ConsoleColor.DarkYellow);
            Display.Write("SỐ SV XUẤT SẮC    :", 50, 44, ConsoleColor.DarkYellow);
            Display.Write("SỐ SV GIỎI        :", 50, 46, ConsoleColor.DarkYellow);
            Display.Write("SỐ SV KHÁ         :", 90, 44, ConsoleColor.DarkYellow);
            Display.Write("SỐ SV HỌC LẠI     :", 90, 46, ConsoleColor.DarkYellow);
            Display.Write("ĐIỂM TBCHT        :", 130, 44, ConsoleColor.DarkYellow);
           
           
            double tlxs = Normalize.Number((double)xs / y.Count) * 100;
            double tlg = Normalize.Number((double)gioi / y.Count) * 100;
            double tlk = Normalize.Number((double)kha / y.Count) * 100;
            double tllb = Normalize.Number((double)luuban / y.Count) * 100;
            Display.Write(idlop, 22, 44, ConsoleColor.DarkGreen);
            Display.Write(ky.ToString(), 22, 46, ConsoleColor.DarkGreen);
            Display.Write(xs.ToString()+"("+(tlxs).ToString()+"%)", 69, 44, ConsoleColor.DarkGreen);
            Display.Write(gioi.ToString()+ "(" + (tlg).ToString() + "%)", 69, 46, ConsoleColor.DarkGreen);
            Display.Write(kha.ToString()+ "(" + (tlk).ToString() + "%)", 109, 44, ConsoleColor.DarkGreen);
            Display.Write(luuban.ToString()+ "(" + (tllb).ToString() + "%)", 109, 46, ConsoleColor.DarkGreen);

            
            Display.Write((tong/y.Count).ToString(), 149, 44, ConsoleColor.DarkGreen);
           
        }

        #endregion

        #region Menu quản lý thống kê
        public int ChucNang()
        {
            Display.Write("▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌", 87, 10);
            Display.Write("▐       THỐNG KÊ      ▌", 87, 11);
            Display.Write("▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌ ", 87, 12);
            List<string> bang = new List<string>();
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║   1.Thống Kê SV Theo Lớp            ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║   2.Thống Kê SV Theo Chuyên Ngành   ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║   3.Thống Kê Tình Hình Dịch Tại Khoa║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║   4.Xuất Bảng Điểm Theo Mã SV       ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║   5.Xuất Bảng Điểm Theo Mã Lớp      ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║   6.Trở Lại Trang Trước             ║");
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
                        Display.PhanBang(1);
                        string id1;
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 20, 1);
                        Display.Write("║  NHẬP MÃ LỚP:                                         ║", 20, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 20, 3);
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 120, 1);
                        Display.Write("║                                                       ║", 120, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 120, 3);
                        do
                        {
                            Console.SetCursorPosition(35, 2);
                            id1 = Console.ReadLine();
                            if (lhBLL.MaLopHopLe(id1) == true)
                            {
                                Display.Write("MÃ LỚP KHÔNG TỒN TẠI, NHẬP LẠI!", 121, 2);
                                Display.Write(new string(' ', 30), 35, 2);
                            }
                        } while (lhBLL.MaLopHopLe(id1) == true);
                        Display.Write(new string(' ', 35), 121, 2);
                        SinhVien_MaLop(id1);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Display.PhanBang(1);
                        string id2;
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 20, 1);
                        Display.Write("║   NHẬP CHUYÊN NGÀNH:                                  ║", 20, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 20, 3);
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 120, 1);
                        Display.Write("║                                                       ║", 120, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 120, 3);
                        do
                        {
                            Console.SetCursorPosition(42, 2);
                            id2 = Console.ReadLine();
                            if (lhBLL.ChuyenNganhHopLe(id2) == false)
                            {
                                Display.Write("CHUYÊN NGÀNH KHÔNG TỒN TẠI, NHẬP LẠI!", 121, 2);
                                Display.Write(new string(' ', 30), 42, 2);
                            }
                        } while (lhBLL.ChuyenNganhHopLe(id2) == false);
                        Display.Write(new string(' ', 40), 121, 2);
                        SinhVien_ChuyenNganh(id2);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Display.PhanBang(1);
                        string id3;
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 20, 1);
                        Display.Write("║   NHẬP ĐỊA CHỈ     :                                  ║", 20, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 20, 3);
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 120, 1);
                        Display.Write("║                                                       ║", 120, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 120, 3);
                        do
                        {
                            Console.SetCursorPosition(42, 2);
                            id3 = Console.ReadLine();
                            if (id3.Length == 0 || id3.Length > 30)
                            {
                                Display.Write("CHUYÊN NGÀNH KHÔNG TỒN TẠI, NHẬP LẠI!", 121, 2);
                                Display.Write(new string(' ', 30), 42, 2);
                            }
                        } while (id3.Length == 0 || id3.Length > 30);
                        Display.Write(new string(' ', 40), 121, 2);
                        NhanSu_DiaChi(id3);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        Display.PhanBang(1);
                        string id4;
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 20, 1);
                        Display.Write("║   NHẬP MÃ SINH VIÊN:                                  ║", 20, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 20, 3);
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 120, 1);
                        Display.Write("║                                                       ║", 120, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 120, 3);
                        do
                        {
                            Console.SetCursorPosition(42, 2);
                            id4 = Console.ReadLine();
                            if (svBLL.MaSinhVienHopLe(id4) == true)
                            {
                                Display.Write("MÃ SINH VIÊN KHÔNG TỒN TẠI, NHẬP LẠI!", 121, 2);
                                Display.Write(new string(' ', 30), 42, 2);
                            }
                        } while (svBLL.MaSinhVienHopLe(id4) == true);
                        Display.Write(new string(' ', 40), 121, 2);
                        DiemSo_MaSinhVien(id4);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        Display.PhanBang(1);
                        string id5;
                        int id6;
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 20, 1);
                        Display.Write("║   NHẬP MÃ MÃ LỚP   :                                  ║", 20, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 20, 3);
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 120, 1);
                        Display.Write("║                                                       ║", 120, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 120, 3);
                        do
                        {
                            Console.SetCursorPosition(42, 2);
                            id5 = Console.ReadLine();
                            if (lhBLL.MaLopHopLe(id5) == true)
                            {
                                Display.Write("MÃ LỚP KHÔNG TỒN TẠI, NHẬP LẠI!", 121, 2);
                                Display.Write(new string(' ', 30), 42, 2);
                            }
                        } while (lhBLL.MaLopHopLe(id5) == true);
                        Display.Write(new string(' ', 40), 21, 2);
                        Display.Write(new string(' ', 40), 121, 2);
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 20, 1);
                        Display.Write("║   NHẬP KỲ HỌC      :                                  ║", 20, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 20, 3);
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 120, 1);
                        Display.Write("║                                                       ║", 120, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 120, 3);
                        do
                        {
                            Console.SetCursorPosition(42, 2);
                            id6 = int.Parse(Console.ReadLine());
                            if (id6 < 1 || id6 > 8)
                            {
                                Display.Write("KỲ HỌC KHÔNG HỢP LỆ, NHẬP LẠI!", 121, 2);
                                Display.Write(new string(' ', 30), 42, 2);
                            }
                        } while (id6 < 1 || id6 > 8);


                        bool check1 = true;
                        List<SinhVien> listsv = svBLL.ListSinhVien_MaLop(id5);
                        List<string> listlich = lichBLL.ListMaMonHoc_LichHoc(id5, id6);
                        for (int i = 0; i < listsv.Count; i++)
                        {
                            for (int j = 0; j < listlich.Count; j++)
                            {
                                if (dsBLL.BangDiemHoanThien_SinhVienMaMonHoc(listsv[i].MaSinhVien, listlich[j]) == false)
                                {
                                    check1 = false;
                                }
                            }
                        }
                        if (check1 == true)
                        {
                            Display.Write(new string(' ', 40), 121, 2);
                            BangDiem_LopHoc(id5, id6);
                            Console.ReadKey();
                        }
                        else
                        {
                            Display.Write("VUI LÒNG HOÀN THIỆN BẢNG ĐIỂM ĐỂ TIẾP TỤC!", 121, 2);
                            Console.ReadLine();
                            List<string> list = dsBLL.ListMaMonHoc_ChuaHoanThienLichHoc(id5, id6);
                            for (int i = 0; i < list.Count; i++)
                            {
                                DiemSoGUI dsGUI = new DiemSoGUI();
                                dsGUI.NhapThemList(id5, list[i]);
                            }
                            Console.Clear();
                            Display.PhanBang(1);
                            BangDiem_LopHoc(id5, id6);
                            Console.ReadKey();
                        }
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
