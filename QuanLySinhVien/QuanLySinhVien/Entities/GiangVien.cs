using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Entities
{
    public class GiangVien
    {
        #region Các thành phần dữ liệu
        private string maGiangVien;
        private string hoTen;
        private string gioiTinh;
        private string diaChi;
        private DateTime ngaySinh;
        private string sdt;
        #endregion

        #region Các thuộc tính
        public string MaGiangVien { get => maGiangVien; set => maGiangVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }

        public override string ToString()
        {
            return MaGiangVien + "|" + HoTen + "|" + GioiTinh + "|" + DiaChi + "|" + NgaySinh.ToString("dd/MM/yyyy") + "|" + Sdt;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public GiangVien() { }
        //Phương thức thiết lập sao chép
        public GiangVien(GiangVien gv)
        {
            this.MaGiangVien = gv.MaGiangVien;
            this.HoTen = gv.HoTen;
            this.GioiTinh = gv.GioiTinh;
            this.DiaChi = gv.DiaChi;
            this.NgaySinh = gv.NgaySinh;
            this.Sdt = gv.Sdt;
        }
        //Phương thức khởi tạo có tham số
        public GiangVien(string magv, string hoten, string gioitinh, string diachi, DateTime ngaysinh, string dt)
        {
            this.MaGiangVien = magv;
            this.HoTen = hoten;
            this.GioiTinh = gioitinh;
            this.DiaChi = diachi;
            this.NgaySinh = ngaysinh;
            this.Sdt = dt;
        }
        #endregion
    }
}
