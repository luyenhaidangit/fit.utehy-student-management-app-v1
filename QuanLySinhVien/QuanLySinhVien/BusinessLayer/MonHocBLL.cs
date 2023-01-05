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
    public class MonHocBLL : IQuanLyBLL<MonHoc>
    {
        private IQuanLyDAL<MonHoc> mhDAL = new MonHocDAL();

        #region Đọc dữ liệu
        public List<MonHoc> DocDuLieu()
        {
            return mhDAL.DocDuLieu();
        }
        #endregion

        #region Thêm dữ liệu
        public void Them(MonHoc Object)
        {
            Object.TenMonHoc = Normalize.String(Object.TenMonHoc);
            mhDAL.Them(Object);
        }
        #endregion

        #region Tìm vị trí
        public int ViTri(string id)
        {
            return mhDAL.ViTri(id);
        }
        public List<MonHoc> timKiem(string id)
        {
            List<MonHoc> list = DocDuLieu();
            List<MonHoc> list1 = new List<MonHoc>();
            for (int i = 0; i < list.Count; i++)
            {
                if (Invalid.SoSanh(list[i].MaMonHoc, id) || Invalid.SoSanh(list[i].TenMonHoc, id) || Invalid.SoSanh(list[i].SoTC.ToString(), id))
                {
                    list1.Add(list[i]);
                }
            }
            return list1;
        }
        #endregion

        #region Ghi dữ liệu
        public void Ghi(List<MonHoc> ListObject)
        {
            mhDAL.Ghi(ListObject);
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id, MonHoc Object)
        {
            Object.TenMonHoc = Normalize.String(Object.TenMonHoc);
            mhDAL.Sua(id, Object);
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id)
        {
            DiemSoBLL dsBLL = new DiemSoBLL();
            LichHocBLL lhBLL = new LichHocBLL();
            lhBLL.Xoa(LichHoc => LichHoc.MaMonHoc == id);
            dsBLL.Xoa(DiemSo => DiemSo.MaMonHoc == id);
            mhDAL.Xoa(id);
        }
        public delegate bool kiemTra(MonHoc mh);
        #endregion

        #region Kiểm tra tính hợp lệ
        public List<string> LayDSMaMon()
        {
            List<string> list = new List<string>();
            foreach (MonHoc ttin in DocDuLieu())
            {
                list.Add(ttin.MaMonHoc);
            }
            return list;
        }

        public bool MaMonHopLe(string id)
        {
            List<string> list = LayDSMaMon();
            if (list.Contains(id) == false && id != "")
            {
                return true;
            }
            else return false;
        }

        public bool MaGiaoVienHopLe(string id)
        {
            GiangVienBLL gvBLL = new GiangVienBLL();
            List<string> list = gvBLL.LayDSMaGiangVien();
            if (list.Contains(id) == false && id != "")
            {
                return true;
            }
            else return false;

        }
        #endregion

        #region Thống kê, lấy thông tin
        public MonHoc MonHoc_MaMonHoc(string id)
        {
            MonHoc x = new MonHoc();
            List<MonHoc> list = DocDuLieu();
            foreach (MonHoc mh in list)
            {
                if (mh.MaMonHoc == id)
                {
                    x = mh;
                }
            }
            return x;
        }

        public string TenMonHoc_MaMonHoc(string id)
        {
            string ten = "";
            for (int i = 0; i < DocDuLieu().Count; i++)
            {
                if (DocDuLieu()[i].MaMonHoc == id)
                {
                    ten = DocDuLieu()[i].TenMonHoc; break;
                }
            }
            return ten;
        }

        public int SoTinChi_MaMonHoc(string id)
        {
            int tc = 0;
            for (int i = 0; i < DocDuLieu().Count; i++)
            {
                if (DocDuLieu()[i].MaMonHoc == id)
                {
                    tc = DocDuLieu()[i].SoTC; break;
                }
            }
            return tc;
        }

        public int TongSoTinChiKyHoc_LichHoc(string idlop,int ky)
        {
            int s = 0;
            LichHocBLL lichBLL = new LichHocBLL();
            List<string> lich = lichBLL.ListMaMonHoc_LichHoc(idlop, ky);
            for (int i = 0; i < lich.Count; i++)
            {
                s += SoTinChi_MaMonHoc(lich[i]);
            }
            return s;
        }
        #endregion
    }
}

