using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Entities;
using System.IO;
using QuanLySinhVien.DataAccessLayer.Interface;

namespace QuanLySinhVien.DataAccessLayer
{
    class MonHocDAL : IQuanLyDAL<MonHoc>
    {
        #region Đường dẫn tệp
        private string FileData = "MonHoc.txt";
        #endregion

        #region Đọc dữ liệu
        public List<MonHoc> DocDuLieu()
        {
            if (!File.Exists(FileData))
                File.Create(FileData).Close();
            List<MonHoc> List = new List<MonHoc>();
            StreamReader Reader = File.OpenText(FileData);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    MonHoc mh = new MonHoc(a[0], a[1], int.Parse(a[2]));
                    List.Add(mh);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Thêm dữ liệu
        public void Them(MonHoc mh)
        {
            StreamWriter Fwrite = File.AppendText(FileData);
            Fwrite.WriteLine(mh.ToString());
            Fwrite.Close();
        }
        #endregion

        #region Ghi lại toàn bộ dữ liệu
        public void Ghi(List<MonHoc> list)
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
        public int ViTri(string id)
        {
            List<MonHoc> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaMonHoc == id)
                    return i;
            }
            return -1;
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id, MonHoc mh)
        {
            List<MonHoc> list = DocDuLieu();
            list[ViTri(id)] = mh;
            Ghi(list);
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id)
        {
            List<MonHoc> list = DocDuLieu();
            list.RemoveAt(ViTri(id));
            Ghi(list);
        }
        #endregion

    }
}
