using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Entities
{
    public class LichHoc
    {
        #region Thành phần dữ liệu
        private string maLopHoc;
        private string maMonHoc;
        private string maGiaoVien;
        private int hocKy;
        #endregion

        #region Phương thức
        public LichHoc() { }

        public LichHoc(string maLopHoc, string maMonHoc,string maGiaoVien,int hocKy)
        {
            this.MaLopHoc = maLopHoc;
            this.MaGiaoVien = maGiaoVien;
            this.HocKy = hocKy;
            this.MaMonHoc = maMonHoc;
        }
        #endregion

        #region Thuộc tính
        public string MaLopHoc { get => maLopHoc; set => maLopHoc = value; }
        public int HocKy { get => hocKy; set => hocKy = value; }
        public string MaMonHoc { get => maMonHoc; set => maMonHoc = value; }
        public string MaGiaoVien { get => maGiaoVien; set => maGiaoVien = value; }

        public override string ToString()
        {
            return MaLopHoc + "|" + MaMonHoc + "|" + MaGiaoVien + "|" + HocKy.ToString();
        }
        #endregion
    }
}
