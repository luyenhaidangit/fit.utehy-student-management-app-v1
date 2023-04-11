using System;
using QuanLySinhVien.PresentationLayer;
using System.IO;
using System.Text;
using QuanLySinhVien.Utilities;
using QuanLySinhVien.PresentationLayer.Interface;
using QuanLySinhVien.Entities;
using QuanLySinhVien.BusinessLayer;
using System.Collections.Generic;

namespace QuanLySinhVien
{

    class Program
    {
        #region Giao diện bắt đầu
        static public void GiaoDienBatDau()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Menu Chính";
            Console.CursorVisible = true; //con trỏ có thể chia sẻ

            Console.WriteLine();
            Console.WriteLine("\t\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                            TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN                                           ║");
            Console.WriteLine("\t\t║                                                    KHOA CÔNG NGHỆ THÔNG TIN                                                   ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                    ********   *********     *******   ********** *********   ********  **********       ***                   ║");
            Console.WriteLine("\t\t║                    ***    **  ***    ***   ***   ***       ***    ***       ***           ***          *****                  ║");
            Console.WriteLine("\t\t║                    ***    *** ***    ***  ***     ***      ***    ***       ***           ***            ***                  ║");
            Console.WriteLine("\t\t║                    *********  *********   ***     ***      ***    ********* ***           ***            ***                  ║");
            Console.WriteLine("\t\t║                    ***        ***    ***  ***     ***      ***    ***       ***           ***            ***                  ║");
            Console.WriteLine("\t\t║                    ***        ***     ***  ***   ***      ***     ***       ***           ***            ***                  ║");
            Console.WriteLine("\t\t║                    ***        ***      ***  *******   ******     *********   ********     ***          *******                ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                   ╔════════════════════════════════════════════════════════════════════════════════════════╗                  ║");
            Console.WriteLine("\t\t║                   ║   CHÀO MỪNG BẠN ĐẾN VỚI ỨNG DỤNG QUẢN LÝ SINH VIÊN KHOA CNTT TRƯỜNG ĐH SPKT HƯNG YÊN   ║                  ║");
            Console.WriteLine("\t\t║                   ╚════════════════════════════════════════════════════════════════════════════════════════╝                  ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                              Giáo Viên Hướng dẫn: Trịnh Thị Nhị                                               ║");
            Console.WriteLine("\t\t║                                              Sinh Viên thực hiện: Luyện Hải Đăng                                              ║");
            Console.WriteLine("\t\t║                                              Lớp                : 125201                                                      ║");
            Console.WriteLine("\t\t║                                              Mã sinh viên       : 12520063                                                    ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                        Hưng Yên 2021                                                          ║");
            Console.WriteLine("\t\t╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("\t\t                                              Nhấn ENTER để vào menu chính!!!                                                    ");
            Console.ReadKey();
        }
        #endregion

        static public int ChucNang()
        {
           
            Display.Write("▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌", 87, 8);
            Display.Write("▐       DANH MỤC      ▌", 87, 9);
            Display.Write("▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌ ", 87, 10);
            List<string> bang = new List<string>();
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        1.QUẢN LÝ LỚP HỌC            ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        2.QUẢN LÝ SINH VIÊN          ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        3.QUẢN LÝ GIÁO VIÊN          ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        4.QUẢN LÝ MÔN HỌC            ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        5.QUẢN LÝ LỊCH HỌC           ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        6.QUẢN LÝ ĐIỂM SỐ            ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        7.THỐNG KÊ                   ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        8.TIỆN ÍCH                   ║");
            bang.Add("╚═════════════════════════════════════╝");
            bang.Add("╔═════════════════════════════════════╗");
            bang.Add("║        9.ĐÓNG CHƯƠNG TRÌNH          ║");
            bang.Add("╚═════════════════════════════════════╝");
            Menu menu = new Menu(bang);
            int index = menu.ThaoTac(80,13);
            return (index / 3) + 1;
        }

        static void Main(string[] args)
        {
            

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetCursorPosition(Console.CursorTop, Console.CursorLeft);
            Console.SetWindowPosition(Console.CursorLeft, Console.CursorTop);
           
            Display.GiaoDienBatDau();
            Display.MenuQL();

            do
            {
                int check = 0;
                while (check == 0)
                {
                    Console.Clear();
                    Display.PhanBang(1);
                    int tm = ChucNang();
                    switch (tm)
                    {
                        case 1:
                            {
                                IQuanLyGUI<LopHoc> LopHoc = new LopHocGUI();
                                LopHoc.Menu();
                                break;
                            }
                        case 2:
                            {
                                IQuanLyGUI<SinhVien> SinhVien = new SinhVienGUI();
                                SinhVien.Menu();
                                break;
                            }
                        case 3:
                            {
                                IQuanLyGUI<GiangVien> GiangVien = new GiaoVienGUI();
                                GiangVien.Menu();
                                break;
                            }
                        case 4:
                            {
                                IQuanLyGUI<MonHoc> MonHoc = new MonHocGUI();
                                MonHoc.Menu();
                                break;
                            }
                        case 5:
                            {
                                LichHocGUI LichHoc = new LichHocGUI();
                                LichHoc.Menu();
                                break;
                            }
                        case 6:
                            {
                                
                                IQuanLyGUI<DiemSo> DiemSo = new DiemSoGUI();
                                DiemSo.Menu();
                                break;
                            }
                        case 7:
                            {
                                ThongKeGUI ThongKe = new ThongKeGUI();
                                ThongKe.Menu();
                                break;
                            }
                        case 8:
                            {
                                TienIchGUI TienIch = new TienIchGUI();
                                TienIch.Menu();
                                break;
                            }
                        case 9:
                            {
                                check = 1;
                                Console.Clear();
                                Decorate.ShowSimplePercentage();
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            } while (true);
        }
    }
}
