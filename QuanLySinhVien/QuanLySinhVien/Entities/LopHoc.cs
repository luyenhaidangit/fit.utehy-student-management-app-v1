using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Entities
{
    public class LopHoc
    {
        #region Các thành phần dữ liệu
        private string maLop;
        private string tenLop;
        private string chuyenNganh;
        #endregion

        #region Các thuộc tính
        public string MaLop { get => maLop; set => maLop = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        public string ChuyenNganh { get => chuyenNganh; set => chuyenNganh = value; }
        public override string ToString()
        {
            return MaLop + "|" + TenLop + "|" + ChuyenNganh;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public LopHoc() { }
        //Phương thức thiết lập sao chép
        public LopHoc(LopHoc lop)
        {
            this.MaLop = lop.MaLop;
            this.TenLop = lop.TenLop;
            this.ChuyenNganh = lop.ChuyenNganh;
        }
        //Phương thức khởi tạo có tham số
        public LopHoc(string malop, string tenlop, string chuyennganh)
        {
            this.MaLop = malop;
            this.TenLop = tenlop;
            this.ChuyenNganh = chuyennganh;
        }

        #endregion
    }
}
