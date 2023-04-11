using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Entities;
using System.IO;
using QuanLySinhVien.DataAccessLayer.Interface;

namespace QuanLySinhVien.DataAccessLayer
{
    class LichHocDAL : IQuanLyDAL<LichHoc>
    {
        #region Đường dẫn tệp
        private string FileData = "LichHoc.txt";
        #endregion

        #region Đọc dữ liệu
        public List<LichHoc> DocDuLieu()
        {
            if (!File.Exists(FileData))
                File.Create(FileData).Close();
            List<LichHoc> List = new List<LichHoc>();
            StreamReader Reader = File.OpenText(FileData);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    LichHoc lh = new LichHoc(a[0],a[1],a[2],int.Parse(a[3]));
                    List.Add(lh);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Thêm dữ liệu vào tệp
        public void Them(LichHoc lh)
        {
            StreamWriter Fwrite = File.AppendText(FileData);
            Fwrite.WriteLine(lh.ToString());
            Fwrite.Close();
        }
        #endregion

        #region Ghi lại toàn bộ dữ liệu
        public void Ghi(List<LichHoc> list)
        {
            StreamWriter Fwrite = File.CreateText(FileData);
            for (int i = 0; i < list.Count; ++i)
            {
                Fwrite.WriteLine(list[i].ToString());
            }
            Fwrite.Close();
        }
        #endregion

        #region Tìm vị trí bản ghi
        public int ViTri(string id, string mamon)
        {
            List<LichHoc> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaLopHoc == id && list[i].MaMonHoc == mamon)
                    return i;
            }
            return -1;
        }
        public int ViTri(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id, string mamon, LichHoc lh)
        {
            List<LichHoc> list = DocDuLieu();
            list[ViTri(id, mamon)] = lh;
            Ghi(list);
        }
        public void Sua(string id, LichHoc myObject)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id, string mamon)
        {
            List<LichHoc> list = DocDuLieu();
            list.RemoveAt(ViTri(id, mamon));
            Ghi(list);
        }
        public void Xoa(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
