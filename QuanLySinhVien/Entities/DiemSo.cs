using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Entities
{
    public class DiemSo
    {
        #region Các thành phần dữ liệu
        private string maSinhVien;
        private string maMonHoc;
        private double diemQuaTrinh;
        private double diemKTHP;
        #endregion

        #region Các thuộc tính
        public string MaMonHoc { get => maMonHoc; set => maMonHoc = value; }
        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public double DiemQuaTrinh { get => diemQuaTrinh; set => diemQuaTrinh = value; }
        public double DiemKTHP { get => diemKTHP; set => diemKTHP = value; }
        public double DiemTB { get => (diemQuaTrinh + diemKTHP) / 2; }
        public string XepLoai
        {
            get 
            {
                if (diemQuaTrinh < 5 || diemKTHP < 5)
                {
                    return "Thi Lại";
                }
                else return "Qua Môn";
            }
        }
        
        public override string ToString()
        {
            return MaSinhVien + "|" + MaMonHoc + "|" + DiemQuaTrinh + "|" + DiemKTHP;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public DiemSo() { }
        //Phương thức thiết lập sao chép
        public DiemSo(DiemSo ds)
        {
            this.MaMonHoc = ds.MaMonHoc;
            this.MaSinhVien = ds.MaSinhVien;
            this.DiemQuaTrinh = ds.DiemQuaTrinh;
            this.DiemKTHP = ds.DiemKTHP;
        }
        //Phương thức khởi tạo có tham số
        public DiemSo(string masv, string mamh, double diemqt, double diemkthp)
        {
            this.MaSinhVien = masv;
            this.MaMonHoc = mamh;
            this.DiemQuaTrinh = diemqt;
            this.DiemKTHP = diemkthp;
        }
        #endregion
    }
}
