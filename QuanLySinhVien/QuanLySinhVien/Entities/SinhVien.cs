using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Entities
{
    public class SinhVien
    {
        #region Các thành phần dữ liệu
        private string maSinhVien;
        private string hoTen;
        private string gioiTinh;
        private string diaChi;
        private DateTime ngaySinh;
        private string sdt;
        private string maLop;
        #endregion

        #region Các thuộc tính
        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string MaLop { get => maLop; set => maLop = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }

        public override string ToString()
        {
            return MaSinhVien + "|" + HoTen + "|" + GioiTinh + "|" + DiaChi + "|" + NgaySinh.ToString("dd/MM/yyyy") + "|" + Sdt + "|" + MaLop;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public SinhVien() { }
        //Phương thức thiết lập sao chép
        public SinhVien(SinhVien sv)
        {
            this.MaSinhVien = sv.MaSinhVien;
            this.HoTen = sv.HoTen;
            this.GioiTinh = sv.GioiTinh;
            this.DiaChi = sv.DiaChi;
            this.NgaySinh = sv.NgaySinh;
            this.Sdt = sv.Sdt;
            this.MaLop = sv.MaLop;
        }
        
        public SinhVien(string masv, string hoten, string gioitinh, string diachi, DateTime ngaysinh, string sdt, string malop)
        {
            this.MaSinhVien = masv;
            this.HoTen = hoten;
            this.GioiTinh = gioitinh;
            this.DiaChi = diachi;
            this.NgaySinh = ngaysinh;
            this.Sdt = sdt;
            this.MaLop = malop;
        }
        #endregion
    }
}
