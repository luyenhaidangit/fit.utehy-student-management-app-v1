using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.BusinessLayer;
using QuanLySinhVien.Entities;
using QuanLySinhVien.Utilities;
using QuanLySinhVien.PresentationLayer.Interface;
using QuanLySinhVien.PresentationLayer;
using System.Linq;
using System.IO;
using System.Threading;


namespace QuanLySinhVien.PresentationLayer
{
    class TienIchGUI
    {
        private LopHocBLL lhBLL = new LopHocBLL();
        private SinhVienBLL svBLL = new SinhVienBLL();
        private GiangVienBLL gvBLL = new GiangVienBLL();
        private MonHocBLL mhBLL = new MonHocBLL();
        private DiemSoBLL dsBLL = new DiemSoBLL();
        private LichHocBLL lichBLL = new LichHocBLL();


        #region Menu quản lý thống kê
        public int ChucNang()
        {
            Display.Write("▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌", 87, 10);
            Display.Write("▐       TIỆN ÍCH      ▌", 87, 11);
            Display.Write("▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌ ", 87, 12);
            List<string> bang = new List<string>();
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        1.Sao Lưu Dữ Liệu            ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        2.Khôi Phục Dữ Liệu          ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        3.Trở Lại Trang Trước        ║");
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
                        saoLuuDuLieu();
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 20, 1);
                        Display.Write("║                                                       ║", 20, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 20, 3);
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 120, 1);
                        Display.Write("║                                                       ║", 120, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 120, 3);
                        for (int i = 0; i <= 100; i++)
                        {
                            Display.Write($"Loading: {i}%   ", 22, 2);
                            Thread.Sleep(50);
                        }
                        Display.Write("Sao lưu dữ liệu thành công!",22,2);
                        Decorate.TrangTri();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Display.PhanBang(1);
                        khoiPhucDuLieu();
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 20, 1);
                        Display.Write("║                                                       ║", 20, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 20, 3);
                        Display.Write("╔═══════════════════════════════════════════════════════╗", 120, 1);
                        Display.Write("║                                                       ║", 120, 2);
                        Display.Write("╚═══════════════════════════════════════════════════════╝", 120, 3);
                        for (int i = 0; i <= 100; i++)
                        {
                            Display.Write($"Loading: {i}%   ", 22, 2);
                            Thread.Sleep(50);
                        }
                        Display.Write("Khôi phục dữ liệu thành công!", 22, 2);
                        Decorate.TrangTri();
                        Console.ReadLine();
                        Console.Clear();

                        break;
                    case "3":
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

        #region Lớp học
        private string FileData1 = "LopHocSaoLuu.txt";

        public void GhiLopHoc(List<LopHoc> list)
        {
            StreamWriter Fwrite = File.CreateText(FileData1);
            for (int i = 0; i < list.Count; ++i)
            {
                Fwrite.WriteLine(list[i].ToString());
            }
            Fwrite.Close();
        }
        public List<LopHoc> DocDuLieuLopHoc()
        {
            if (!File.Exists(FileData1))
                File.Create(FileData1).Close();
            List<LopHoc> List = new List<LopHoc>();
            StreamReader Reader = File.OpenText(FileData1);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    LopHoc lh = new LopHoc(a[0], a[1], a[2]);
                    List.Add(lh);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Sinh Viên
        private string FileData2 = "SinhVienSaoLuu.txt";

        public void GhiSinhVien(List<SinhVien> list)
        {
            StreamWriter Fwrite = File.CreateText(FileData2);
            for (int i = 0; i < list.Count; ++i)
            {
                Fwrite.WriteLine(list[i].ToString());
            }
            Fwrite.Close();
        }
        public List<SinhVien> DocDuLieuSinhVien()
        {
            if (!File.Exists(FileData2))
                File.Create(FileData2).Close();
            List<SinhVien> List = new List<SinhVien>();
            StreamReader Reader = File.OpenText(FileData2);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    DateTime time = DateTime.Parse(a[4]);
                    SinhVien sv = new SinhVien(a[0], a[1], a[2], a[3], time, a[5], a[6]);
                    List.Add(sv);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Giáo viên
        private string FileData3 = "GiangVienSaoLuu.txt";

        public void GhiGiangVien(List<GiangVien> list)
        {
            StreamWriter Fwrite = File.CreateText(FileData3);
            for (int i = 0; i < list.Count; ++i)
            {
                Fwrite.WriteLine(list[i].ToString());
            }
            Fwrite.Close();
        }

        public List<GiangVien> DocDuLieuGiangVien()
        {
            if (!File.Exists(FileData3))
                File.Create(FileData3).Close();
            List<GiangVien> List = new List<GiangVien>();
            StreamReader Reader = File.OpenText(FileData3);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    DateTime time = DateTime.Parse(a[4]);
                    GiangVien gv = new GiangVien(a[0], a[1], a[2], a[3], time, a[5]);
                    List.Add(gv);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Môn học
        private string FileData4 = "MonHocSaoLuu.txt";

        public void GhiMonHoc(List<MonHoc> list)
        {
            StreamWriter Fwrite = File.CreateText("MonHocSaoLuu.txt");
            for (int i = 0; i < list.Count; ++i)
            {
                Fwrite.WriteLine(list[i].ToString());
            }
            Fwrite.Close();
        }

        public List<MonHoc> DocDuLieuMonHoc()
        {
            if (!File.Exists(FileData4))
                File.Create(FileData4).Close();
            List<MonHoc> List = new List<MonHoc>();
            StreamReader Reader = File.OpenText(FileData4);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    MonHoc mh = new MonHoc(a[0], a[1], int.Parse(a[2]));
                    List.Add(mh);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Lịch học
        private string FileData5 = "LichHocSaoLuu.txt";

        public void GhiLichHoc(List<LichHoc> list)
        {
            StreamWriter Fwrite = File.CreateText(FileData5);
            for (int i = 0; i < list.Count; ++i)
            {
                Fwrite.WriteLine(list[i].ToString());
            }
            Fwrite.Close();
        }

        public List<LichHoc> DocDuLieuLichHoc()
        {
            if (!File.Exists(FileData5))
                File.Create(FileData5).Close();
            List<LichHoc> List = new List<LichHoc>();
            StreamReader Reader = File.OpenText(FileData5);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    LichHoc lh = new LichHoc(a[0], a[1], a[2], int.Parse(a[3]));
                    List.Add(lh);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Điểm số
        private string FileData6 = "DiemSoSaoLuu.txt";

        public void GhiDiemSo(List<DiemSo> list)
        {
            StreamWriter Fwrite = File.CreateText(FileData6);
            for (int i = 0; i < list.Count; ++i)
            {
                Fwrite.WriteLine(list[i].ToString());
            }
            Fwrite.Close();
        }

        public List<DiemSo> DocDuLieuDiemSo()
        {
            if (!File.Exists(FileData6))
                File.Create(FileData6).Close();
            List<DiemSo> List = new List<DiemSo>();
            StreamReader Reader = File.OpenText(FileData6);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    DiemSo ds = new DiemSo(a[0], a[1], double.Parse(a[2]), double.Parse(a[3]));
                    List.Add(ds);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        public void khoiPhucDuLieu()
        {

            lhBLL.Ghi(DocDuLieuLopHoc());
            svBLL.Ghi(DocDuLieuSinhVien());
            gvBLL.Ghi(DocDuLieuGiangVien());
            mhBLL.Ghi(DocDuLieuMonHoc());
            lichBLL.Ghi(DocDuLieuLichHoc());
            dsBLL.Ghi(DocDuLieuDiemSo());
        }

        public void saoLuuDuLieu()
        {
            
            GhiLopHoc(lhBLL.DocDuLieu());
            GhiSinhVien(svBLL.DocDuLieu());
            GhiGiangVien(gvBLL.DocDuLieu());
            GhiMonHoc(mhBLL.DocDuLieu());
            GhiLichHoc(lichBLL.DocDuLieu());
            GhiDiemSo(dsBLL.DocDuLieu());
        }
    }
}
