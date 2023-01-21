using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.DataAccessLayer;
using QuanLySinhVien.Entities;
using QuanLySinhVien.BusinessLayer.Interface;
using QuanLySinhVien.DataAccessLayer.Interface;
using QuanLySinhVien.Utilities;

namespace QuanLySinhVien.BusinessLayer
{
    public class GiangVienBLL:IQuanLyBLL<GiangVien>
    {
        private IQuanLyDAL<GiangVien> gvDAL = new GiangVienDAL();

        #region Đọc dữ liệu
        public List<GiangVien> DocDuLieu()
        {
            return gvDAL.DocDuLieu();        
        }
        #endregion

        #region Thêm dữ liệu
        public void Them(GiangVien Object)
        {
            Object.MaGiangVien = Normalize.String(Object.MaGiangVien);
            Object.HoTen = Normalize.String(Object.HoTen);
            Object.GioiTinh = Normalize.String(Object.GioiTinh);
            Object.DiaChi = Normalize.String(Object.DiaChi);
            //Object.NgaySinh = Normalize.String(Object.NgaySinh);
            Object.Sdt = Normalize.String(Object.Sdt);
            gvDAL.Them(Object);
        }
        #endregion

        #region Ghi dữ liệu
        public void Ghi(List<GiangVien> ListObject)
        {
            gvDAL.Ghi(ListObject);
        }
        #endregion

        #region Tìm vị trí
        public int ViTri(string id)
        {
            return gvDAL.ViTri(id);
        }
        public List<GiangVien> timKiem(string id)
        {
            List<GiangVien> list = DocDuLieu();
            List<GiangVien> list1 = new List<GiangVien>();
            for (int i = 0; i < list.Count; i++)
            {
                if (Invalid.SoSanh(list[i].MaGiangVien, id) || Invalid.SoSanh(list[i].HoTen, id) || Invalid.SoSanh(list[i].GioiTinh, id) || Invalid.SoSanh(list[i].DiaChi, id) || Invalid.SoSanh(list[i].NgaySinh.ToString("dd/MM/yyyy"), id) || Invalid.SoSanh(list[i].Sdt, id))
                {
                    list1.Add(list[i]);
                }
            }
            return list1;
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id, GiangVien Object)
        {
            Object.MaGiangVien = Normalize.String(Object.MaGiangVien);
            Object.HoTen = Normalize.String(Object.HoTen);
            Object.GioiTinh = Normalize.String(Object.GioiTinh);
            Object.DiaChi = Normalize.String(Object.DiaChi);
            //Object.NgaySinh = Normalize.String(Object.NgaySinh);
            Object.Sdt = Normalize.String(Object.Sdt);
            gvDAL.Sua(id,Object);
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id)
        {
            gvDAL.Xoa(id);
        }
        #endregion

        #region Kiểm tra tính hợp lệ đầu vào
        public List<string> LayDSMaGiangVien()
        {
            List<string> list = new List<string>();
            foreach (GiangVien ttin in DocDuLieu())
            {
                list.Add(ttin.MaGiangVien);
            }
            return list;
        }

        public bool MaGiangVienHopLe(string id)
        {
            List<string> list = LayDSMaGiangVien();
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
        #endregion

        #region Thống kê, lấy thông tin
        public List<GiangVien> ListGiangVien_DiaChi(string diachi)
        {
            List<GiangVien> listnew = new List<GiangVien>();
            List<GiangVien> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].DiaChi.ToLower() == diachi.ToLower())
                {
                    listnew.Add(list[i]);
                }
            }
            return listnew;
        }
        #endregion
    }
}
