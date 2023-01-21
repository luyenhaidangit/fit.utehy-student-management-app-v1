using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.DataAccessLayer;
using QuanLySinhVien.Entities;
using QuanLySinhVien.BusinessLayer.Interface;
using QuanLySinhVien.DataAccessLayer.Interface;
using QuanLySinhVien.BusinessLayer;
using QuanLySinhVien.Utilities;

namespace QuanLySinhVien.BusinessLayer
{
    public class LopHocBLL : IQuanLyBLL<LopHoc>
    {
        private IQuanLyDAL<LopHoc> lhDAL = new LopHocDAL();

        #region Đọc dữ liệu
        public List<LopHoc> DocDuLieu()
        {
            return lhDAL.DocDuLieu();
        }
        #endregion

        #region Ghi toàn bộ dữ liệu
        public void Ghi(List<LopHoc> ListObject)
        {
            lhDAL.Ghi(ListObject);
        }
        #endregion

        #region Thêm dữ liệu
        public void Them(LopHoc Object)
        {
            Object.MaLop = Normalize.String(Object.MaLop);
            Object.TenLop = Normalize.String(Object.TenLop).ToUpper();
            Object.ChuyenNganh = Normalize.String(Object.ChuyenNganh);
            lhDAL.Them(Object);
        }
        #endregion

        #region Tìm vị trí
        public int ViTri(string id)
        {
            return lhDAL.ViTri(id);
        }
        public List<LopHoc> timKiem(string id)
        {
            List<LopHoc> list = DocDuLieu();
            List<LopHoc> list1 = new List<LopHoc>();
            for (int i = 0; i < list.Count; i++)
            {
                if (Invalid.SoSanh(list[i].MaLop, id) || Invalid.SoSanh(list[i].TenLop, id) || Invalid.SoSanh(list[i].ChuyenNganh, id))
                {
                    list1.Add(list[i]);
                }
            }
            return list1;
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id, LopHoc Object)
        {
            Object.MaLop = Normalize.String(Object.MaLop);
            Object.TenLop = Normalize.String(Object.TenLop).ToUpper();
            Object.ChuyenNganh = Normalize.String(Object.ChuyenNganh);
            lhDAL.Sua(id, Object);
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id)
        {
            SinhVienBLL svBLL = new SinhVienBLL();
            LichHocBLL lhBLL = new LichHocBLL();
            svBLL.Xoa(SinhVien => SinhVien.MaLop == id);
            lhBLL.Xoa(LichHoc => LichHoc.MaLopHoc == id);
            lhDAL.Xoa(id);
        }
        #endregion

        #region Kiểm tra tính hợp lệ
        public List<string> layDSMaLop()
        {
            List<string> list = new List<string>();
            foreach (LopHoc ttin in DocDuLieu())
            {
                list.Add(ttin.MaLop);
            }
            return list;
        }

        public bool MaLopHopLe(string id)
        {
            List<string> list = layDSMaLop();
            if (list.Contains(id) == false && id.Length != 0)
            {
                return true;
            }
            else return false;
        }

        public bool ChuyenNganhHopLe(string tennganh)
        {
            List<string> list = new List<string>();
            list.Add("Công Nghệ Web");
            list.Add("Công Nghệ Di Động");
            list.Add("Kiểm Thử Phần Mềm");
            list.Add("Mạng Máy Tính");
            list.Add("Iot");
            list.Add("Đồ Họa");
            list.Add("Khoa Học Dữ Liệu");
            list.Add("Xử Lý Ngôn Ngữ");
            list.Add("Nhận Dạng Hình Ảnh");
            if (list.Contains(Normalize.String(tennganh)) == true)
            {
                return true;
            }
            else return false;
        }
        #endregion

        #region Xử lý tính toán
        public LopHoc LopHoc_MaLop(string idlop)
        {
            List<LopHoc> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaLop == idlop)
                {
                    return list[i];
                }
            }
            return null;
        }

        public List<string> ListMaLop_ChuyenNganh(string tencn)
        {
            List<LopHoc> list = DocDuLieu();
            List<string> list1 = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ChuyenNganh.ToLower() == tencn.ToLower())
                {
                    list1.Add(list[i].MaLop);
                }
            }
            return list1;
        }
        #endregion
    }
}
