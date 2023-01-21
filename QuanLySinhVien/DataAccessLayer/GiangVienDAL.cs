using System.Collections.Generic;
using QuanLySinhVien.Entities;
using System.IO;
using QuanLySinhVien.DataAccessLayer.Interface;
using System;
using System.Globalization;

namespace QuanLySinhVien.DataAccessLayer
{
    class GiangVienDAL : IQuanLyDAL<GiangVien>
    {
        #region Đường dẫn tệp
        private string FileData = "GiangVien.txt";
        #endregion

        #region Đọc dữ liệu từ tệp
        CultureInfo VietNam = new CultureInfo("vi-VN");
        public List<GiangVien> DocDuLieu()
        {
            if (!File.Exists(FileData))
                File.Create(FileData).Close();
            List<GiangVien> List = new List<GiangVien>();
            StreamReader Reader = File.OpenText(FileData);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    //DateTime time = .Parse(a[4], "dd/MM/yyyy", VietNam);

                    GiangVien gv = new GiangVien(a[0], a[1], a[2], a[3], DateTime.ParseExact(a[4],"dd/MM/yyyy",VietNam),a[5]);
                    List.Add(gv);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Thêm dữ liệu
        public void Them(GiangVien sv)
        {
            StreamWriter Fwrite = File.AppendText(FileData);
            Fwrite.WriteLine(sv.ToString());
            Fwrite.Close();
        }
        #endregion

        #region Ghi lại toàn bộ dữ liệu
        public void Ghi(List<GiangVien> list)
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
            List<GiangVien> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaGiangVien == id)
                    return i;
            }
            return -1;
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id, GiangVien gv)
        {
            List<GiangVien> list = DocDuLieu();
            list[ViTri(id)] = gv;
            Ghi(list);
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id)
        {
            List<GiangVien> list = DocDuLieu();
            list.RemoveAt(ViTri(id));
            Ghi(list);
        }
        #endregion
    }
}
