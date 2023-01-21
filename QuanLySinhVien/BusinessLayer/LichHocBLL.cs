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
    class LichHocBLL : IQuanLyBLL<LichHoc>
    {
        private LichHocDAL lhDAL = new LichHocDAL();

        #region Đọc dữ liệu
        public List<LichHoc> DocDuLieu()
        {
            return lhDAL.DocDuLieu();
        }
        #endregion

        #region Ghi
        public void Ghi(List<LichHoc> ListObject)
        {
            lhDAL.Ghi(ListObject);
        }
        #endregion

        #region Sửa
        public void Sua(string id, LichHoc Object)
        {
            throw new NotImplementedException();
        }
        public void Sua(string id, string mamon, LichHoc Object)
        {
            lhDAL.Sua(id, mamon, Object);
        }
        #endregion

        #region Thêm
        public void Them(LichHoc Object)
        {

            lhDAL.Them(Object);
        }
        #endregion

        #region Vị trí
        public int ViTri(string id)
        {
            throw new NotImplementedException();
        }
        public int ViTri(string id,  string mamon)
        {
            return lhDAL.ViTri(id, mamon);
        }
        public List<LichHoc> timKiem(string id)
        {
            List<LichHoc> list = DocDuLieu();
            List<LichHoc> list1 = new List<LichHoc>();
            for (int i = 0; i < list.Count; i++)
            {
                if (Invalid.SoSanh(list[i].MaLopHoc, id) || Invalid.SoSanh(list[i].MaMonHoc, id) || Invalid.SoSanh(list[i].MaGiaoVien, id) || Invalid.SoSanh(list[i].HocKy.ToString(), id))
                {
                    list1.Add(list[i]);
                }
            }
            return list1;
        }
        #endregion

        #region Xóa
        public void Xoa(string id)
        {
            throw new NotImplementedException();
        }
        public void Xoa(string id, string mamon)
        {
            lhDAL.Xoa(id, mamon);
        }
        public delegate bool kiemTra(LichHoc lh);

        public void Xoa(kiemTra kiemTra)
        {
            List<LichHoc> list = DocDuLieu();
            MonHocBLL mhBLL = new MonHocBLL();
            list.RemoveAll(LichHoc => kiemTra(LichHoc) == true);
            Ghi(list);
        }
        #endregion

        #region Kiểm tra tính hợp lệ
        public bool MaLopHopLe(string malop)
        {
            LopHocBLL lhBLL = new LopHocBLL();
            List<string> list = lhBLL.layDSMaLop();
            if (list.Contains(malop) == true && malop.Length != 0)
            {
                return true;
            }
            else return false;

        }
        public bool MaGiaoVienHopLe(string magv)
        {
            GiangVienBLL gvBLL = new GiangVienBLL();
            List<string> list = gvBLL.LayDSMaGiangVien();
            if (list.Contains(magv) == false && magv != "")
            {
                return true;
            }
            else return false;
        }
        public bool MaMonHocHopLe(string id)
        {
            MonHocBLL mhBLL = new MonHocBLL();
            List<string> list = mhBLL.LayDSMaMon();
            if (list.Contains(id) == true && id.Length != 0)
            {
                return true;
            }
            else return false;

        }

        public bool MaHopLe(string id1, string id2)
        {
            List<LichHoc> list = DocDuLieu();
            bool check = false;
            foreach (LichHoc ttin in list)
            {
                if (ttin.MaLopHoc == id1 && ttin.MaMonHoc == id2)
                {
                    check = true; break;
                }
            }
            return check;
        }
        #endregion

        #region Thống kê, lấy thông tin
        public List<string> ListMaMonHoc_LichHoc(string idlop, int ky)
        {
            List<string> liststr = new List<string>();
            List<LichHoc> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaLopHoc == idlop && list[i].HocKy == ky)
                {
                    liststr.Add(list[i].MaMonHoc);
                }
            }
            return liststr;
        }

        public List<string> ListTenMonHoc_LichHoc(string idlop, int ky)
        {
            MonHocBLL mhBLL = new MonHocBLL();
            List<string> liststr = ListMaMonHoc_LichHoc(idlop, ky);
            List<string> list = new List<string>();
            for (int i = 0; i < liststr.Count; i++)
            {
                list.Add(mhBLL.TenMonHoc_MaMonHoc(liststr[i]).ToUpper());
            }
            return list;
        }
        #endregion
    }
}
