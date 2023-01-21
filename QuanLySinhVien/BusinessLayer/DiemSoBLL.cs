using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.DataAccessLayer;
using QuanLySinhVien.Entities;
using QuanLySinhVien.BusinessLayer.Interface;
using QuanLySinhVien.DataAccessLayer.Interface;
using System.Linq;
using QuanLySinhVien.Utilities;

namespace QuanLySinhVien.BusinessLayer
{
    public class DiemSoBLL : IQuanLyBLL<DiemSo>
    {
        //private IQuanLyDAL<DiemSo> dsDAL = new DiemSoDAL();
        private DiemSoDAL dsDAL = new DiemSoDAL();

        #region Đọc dữ liệu
        public List<DiemSo> DocDuLieu()
        {
            return dsDAL.DocDuLieu();
        }
        #endregion

        #region Ghi
        public void Ghi(List<DiemSo> ListObject)
        {
            dsDAL.Ghi(ListObject);
        }
        #endregion

        #region Sửa
        public void Sua(string id, DiemSo Object)
        {
            throw new NotImplementedException();
        }
        public void Sua(string id1,string id2, DiemSo Object)
        {
            dsDAL.Sua(id1,id2, Object);
        }
        #endregion
              
        #region Thêm
        public void Them(DiemSo Object)
        {
            dsDAL.Them(Object);
        }
        #endregion

        #region Vị trí
        public int ViTri(string id)
        {
            throw new NotImplementedException();
        }
        public int ViTri(string id1,string id2)
        {
            return dsDAL.ViTri(id1, id2);
        }
        public List<DiemSo> timKiem(string id)
        {
            List<DiemSo> list = DocDuLieu();
            List<DiemSo> list1 = new List<DiemSo>();
            for (int i = 0; i < list.Count; i++)
            {
                if (Invalid.SoSanh(list[i].MaSinhVien, id) || Invalid.SoSanh(list[i].MaMonHoc, id) || Invalid.SoSanh(list[i].DiemQuaTrinh.ToString(), id) || Invalid.SoSanh(list[i].DiemKTHP.ToString(), id))
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
        public void Xoa(string id1,string id2)
        {
            dsDAL.Xoa(id1,id2);
        }
        public delegate bool kiemTra(DiemSo ds);

        public void Xoa(kiemTra kiemTra)
        {
            List<DiemSo> list = DocDuLieu();
            MonHocBLL mhBLL = new MonHocBLL();
            list.RemoveAll(DiemSo => kiemTra(DiemSo) == true);
            Ghi(list);
        }
        #endregion

        #region Kiểm tra tính hợp lệ đầu vào
        public bool MaSinhVienHopLe(string id)
        {
            SinhVienBLL svBLL = new SinhVienBLL();
            List<string> list = svBLL.LayDSMaSinhVien();
            if (list.Contains(id) == true && id.Length != 0)
            {
                return true;
            }
            else return false;
        }

        public bool MaMonHocHopLe(string id)
        {
            MonHocBLL mhBLL = new MonHocBLL();
            List<string> list = mhBLL.LayDSMaMon();
            if (list.Contains(id) == true && id.Length !=0)
            {
                return true;
            }
            else return false;
        }

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

        public bool MaSV_MHHopLe(string id1, string id2)
        {
            List<DiemSo> list = DocDuLieu();
            bool check = true;
            foreach (DiemSo ttin in list)
            {
                if (ttin.MaSinhVien == id1 && ttin.MaMonHoc == id2)
                {
                    check = false;  break;
                }
            }
            return check;
        }
        #endregion

        #region Thống kê, lấy thông tin
        public double DiemTBHT_SinhVienKyHoc(string idsv, string idlop, int ky)
        {
            double tong = 0;
            LichHocBLL lichBLL = new LichHocBLL();
            MonHocBLL mhBLL = new MonHocBLL();
            List<string> lich = lichBLL.ListMaMonHoc_LichHoc(idlop, ky);
            for (int i = 0; i < lich.Count; i++)
            {
                tong += DiemTB_SinhVienMaMonHoc(idsv, lich[i]) * mhBLL.SoTinChi_MaMonHoc(lich[i]);
            }
            return Math.Round(tong / mhBLL.TongSoTinChiKyHoc_LichHoc(idlop, ky), 2);
        }

        public string XepLoai_DiemTB(double diemTB)
        {
            if (diemTB >= 9)
            {
                return "Xuất Sắc";
            }
            else if (diemTB >= 8)
            {
                return "Giỏi";
            }
            else if (diemTB >= 5)
            {
                return "Khá";
            }
            else return "Học Lại";
        }

        public List<DiemSo> ListDiemSo_SinhVien(string id)
        {
            List<DiemSo> list = DocDuLieu();
            List<DiemSo> list1 = new List<DiemSo>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaSinhVien == id)
                {
                    list1.Add(list[i]);
                }
            }
            return list1;
        }

        public double DiemTB_SinhVienMaMonHoc(string idhs, string idmh)
        {
            double diem = 0;
            for (int i = 0; i < DocDuLieu().Count; i++)
            {
                if (DocDuLieu()[i].MaSinhVien == idhs && DocDuLieu()[i].MaMonHoc == idmh)
                {
                    diem = DocDuLieu()[i].DiemTB; break;
                }
            }
            return diem;
        }

        public List<string> DiemChiTiet_SinhVienMaMonHoc(string idhs, string idmh)
        {
            List<string> list = new List<string>();
            double diem = 0;
            for (int i = 0; i < DocDuLieu().Count; i++)
            {
              
                if (DocDuLieu()[i].MaSinhVien == idhs && DocDuLieu()[i].MaMonHoc == idmh)
                {
                    list.Add(DocDuLieu()[i].DiemQuaTrinh.ToString());
                    list.Add(DocDuLieu()[i].DiemKTHP.ToString());
                    list.Add(DocDuLieu()[i].DiemTB.ToString());
                    if (DocDuLieu()[i].DiemQuaTrinh < 5 || DocDuLieu()[i].DiemKTHP < 5)
                    {
                        list.Add("TL");
                    }
                    else list.Add("QM");
                }
            }
            return list;
        }

        public bool BangDiemHoanThien_SinhVienMaMonHoc(string idhs,string idmh)
        {
            List<DiemSo> list = DocDuLieu();
            bool check = false;
            for(int i=0;i<list.Count;i++)
            {
                if(list[i].MaSinhVien == idhs&& list[i].MaMonHoc==idmh)
                {
                    check = true;
                }    
            }
            return check;
        }

        public DiemSo DiemSo_MaSinhVien(string idhs, string idmh)
        {
            List<DiemSo> list = DocDuLieu();
            DiemSo ds = new DiemSo();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaSinhVien == idhs && list[i].MaMonHoc == idmh)
                {
                    ds = list[i];
                }
            }
            return ds;
        }

        public List<string> ListMaMonHoc_ChuaHoanThienLichHoc(string idlop, int ky)
        {
            LichHocBLL lhBLL = new LichHocBLL();
            SinhVienBLL svBLL = new SinhVienBLL();
            List<string> list = new List<string>();
            List<string> listlich = lhBLL.ListMaMonHoc_LichHoc(idlop, ky);
            List<string> listsv = svBLL.ListMaSinhVien_MaLop(idlop);
            for (int i = 0; i < listlich.Count; i++)
            {
                for (int k = 0; k < listsv.Count; k++)
                {
                    if (BangDiemHoanThien_SinhVienMaMonHoc(listsv[k], listlich[i]) == false)
                    {
                        if (list.Contains(listlich[i])) break;
                        else
                        {
                            list.Add(listlich[i]);
                        }
                    }
                }
            }
            return list;
        }
        #endregion
    }
}
