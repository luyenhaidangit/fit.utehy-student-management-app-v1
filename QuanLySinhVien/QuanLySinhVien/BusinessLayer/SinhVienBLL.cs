using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.DataAccessLayer;
using QuanLySinhVien.Entities;
using QuanLySinhVien.BusinessLayer.Interface;
using QuanLySinhVien.DataAccessLayer.Interface;
using QuanLySinhVien.Utilities;
using System.Linq;


namespace QuanLySinhVien.BusinessLayer
{
    public class SinhVienBLL : IQuanLyBLL<SinhVien>
    {
        private IQuanLyDAL<SinhVien> svDAL = new SinhVienDAL();

        #region Đọc dữ liệu
        public List<SinhVien> DocDuLieu()
        {
            return svDAL.DocDuLieu();
        }
        #endregion

        #region Ghi dữ liệu
        public void Ghi(List<SinhVien> ListObject)
        {
            svDAL.Ghi(ListObject);
        }
        #endregion

        #region Thêm dữ liệu
        public void Them(SinhVien Object)
        {
            Object.MaSinhVien = Normalize.String(Object.MaSinhVien);
            Object.HoTen = Normalize.String(Object.HoTen);
            Object.GioiTinh = Normalize.String(Object.GioiTinh);
            Object.DiaChi = Normalize.String(Object.DiaChi);
            //Object.NgaySinh = Normalize.String(Object.NgaySinh);
            Object.Sdt = Normalize.String(Object.Sdt);
            Object.MaLop = Normalize.String(Object.MaLop);
            svDAL.Them(Object);
        }
        #endregion

        #region Tìm vị trí
        public int ViTri(string id)
        {
            return svDAL.ViTri(id);
        }
        public List<SinhVien> timKiem(string id)
        {
            List<SinhVien> list = DocDuLieu();
            List<SinhVien> list1 = new List<SinhVien>();
            for (int i = 0; i < list.Count; i++)
            {
                string s = list[i].NgaySinh.ToString(); 
                if (Invalid.SoSanh(list[i].MaSinhVien, id) || Invalid.SoSanh(list[i].HoTen, id) || Invalid.SoSanh(list[i].GioiTinh, id) || Invalid.SoSanh(list[i].DiaChi, id) || Invalid.SoSanh(list[i].NgaySinh.ToString("dd/MM/yyyy"), id) || Invalid.SoSanh(list[i].Sdt, id) || Invalid.SoSanh(list[i].MaLop, id))
                {
                    list1.Add(list[i]);
                }
            }
            return list1;
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id, SinhVien Object)
        {
            Object.MaSinhVien = Normalize.String(Object.MaSinhVien);
            Object.HoTen = Normalize.String(Object.HoTen);
            Object.GioiTinh = Normalize.String(Object.GioiTinh);
            Object.DiaChi = Normalize.String(Object.DiaChi);
            //Object.NgaySinh = Normalize.String(Object.NgaySinh);
            Object.Sdt = Normalize.String(Object.Sdt);
            Object.MaLop = Normalize.String(Object.MaLop);
            svDAL.Sua(id, Object);
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id)
        {
            DiemSoBLL dsBLL = new DiemSoBLL();
            dsBLL.Xoa(DiemSo => DiemSo.MaSinhVien == id);
            svDAL.Xoa(id);
        }

        public delegate bool kiemTra(SinhVien sv);

        public void Xoa(kiemTra kiemTra)
        {
            List<SinhVien> list = DocDuLieu();
            List<SinhVien> list1 = new List<SinhVien>();
            DiemSoBLL dsBLL = new DiemSoBLL();
            
            for (int i = 0; i < list.Count; i++)
            {
                if(kiemTra(list[i]))
                {
                    dsBLL.Xoa(DiemSo => DiemSo.MaSinhVien == list[i].MaSinhVien);
                }    
            }
            list.RemoveAll(SinhVien => kiemTra(SinhVien) == true);

            Ghi(list);
        }
        #endregion

        #region Kiểm tra tính hợp lệ đầu vào
        public List<string> LayDSMaSinhVien()
        {
            List<string> list = new List<string>();
            foreach (SinhVien ttin in DocDuLieu())
            {
                list.Add(ttin.MaSinhVien);
            }
            return list;
        }

        public bool MaSinhVienHopLe(string id)
        {
            List<string> list = LayDSMaSinhVien();
            if (list.Contains(id) == false && id != "")
            {
                return true;
            }
            else return false;
        }

        public bool SDTHopLe(string sdt)
        {
            if (sdt != "" && sdt.Length == 10 && Invalid.chiChuaSo(sdt) == true)
            {
                return true;
            }
            else return false;
        }

        public bool MaLopHopLe(string malop)
        {
            LopHocBLL lhBLL = new LopHocBLL();
            List<string> list = lhBLL.layDSMaLop();
            if (list.Contains(malop) == false && malop != "")
            {
                return true;
            }
            else return false;
        }
        #endregion

        #region Thống kê, lấy thông tin
        public List<SinhVien> ListSinhVien_MaLop(string idlop)
        {
            List<SinhVien> listnew = new List<SinhVien>();
            List<SinhVien> list = DocDuLieu();
            for(int i=0;i<list.Count;i++)
            {
                if(list[i].MaLop==idlop)
                {
                    listnew.Add(list[i]);
                }
            }
            return listnew;
        }

        public List<SinhVien> ListSinhVien_ChuyenNganh(string tencn)
        {
            LopHocBLL lhBLL = new LopHocBLL();
            List<SinhVien> listnew = new List<SinhVien>();
            List<SinhVien> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (lhBLL.ListMaLop_ChuyenNganh(tencn).Contains(list[i].MaLop))
                {
                    listnew.Add(list[i]);
                }
            }
            return listnew;
        }

        public List<SinhVien> ListSinhVien_DiaChi(string diachi)
        {
            List<SinhVien> listnew = new List<SinhVien>();
            List<SinhVien> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].DiaChi.ToLower() == diachi.ToLower())
                {
                    listnew.Add(list[i]);
                }
            }
            return listnew;
        }

        public SinhVien SinhVien_MaSinhVien(string id)
        {
            List<SinhVien> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaSinhVien == id)
                {
                    return list[i];
                }
            }
            return null;
        }

        public string HoTen_MaSinhVien(string id)
        {
            string ten = "";
            for (int i = 0; i < DocDuLieu().Count; i++)
            {
                if (DocDuLieu()[i].MaSinhVien == id)
                {
                    ten = DocDuLieu()[i].HoTen; break;
                }
            }
            return ten;
        }

        public List<string> ListMaSinhVien_MaLop(string idlop)
        {
            List<string> listnew = new List<string>();
            List<SinhVien> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaLop == idlop)
                {
                    listnew.Add(list[i].MaSinhVien);
                }
            }
            return listnew;
        }
        #endregion
    }
}
