using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Entities
{
    public class MonHoc
    {
        #region Các thành phần dữ liệu
        private string maMonHoc;
        private string tenMonHoc;
        private int soTC;
        #endregion

        #region Các thuộc tính
        public string MaMonHoc { get => maMonHoc; set => maMonHoc = value; }
        public string TenMonHoc { get => tenMonHoc; set => tenMonHoc = value; }
        public int SoTC { get => soTC; set => soTC = value; }
        public override string ToString()
        {
            return MaMonHoc + "|" + TenMonHoc + "|" + SoTC;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public MonHoc() { }
        //Phương thức thiết lập sao chép
        public MonHoc(MonHoc mh)
        {
            this.MaMonHoc = mh.MaMonHoc;
            this.TenMonHoc = mh.TenMonHoc;
            this.SoTC = mh.SoTC;
        }
        //Phương thức khởi tạo có tham số
        public MonHoc(string mamh, string tenmh, int sotc)
        {
            this.MaMonHoc = mamh;
            this.TenMonHoc = tenmh;
            this.SoTC = sotc;
        }
        #endregion
    }
}
