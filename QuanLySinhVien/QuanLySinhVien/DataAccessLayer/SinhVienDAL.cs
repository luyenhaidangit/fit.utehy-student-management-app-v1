using System.Collections.Generic;
using QuanLySinhVien.Entities;
using System.IO;
using QuanLySinhVien.DataAccessLayer.Interface;
using System;
using System.Globalization;


namespace QuanLySinhVien.DataAccessLayer
{
    class SinhVienDAL : IQuanLyDAL<SinhVien>
    {
        
        #region Đường dẫn tệp
        private string FileData = "SinhVien.txt";
        #endregion

        #region Đọc dữ liệu
        CultureInfo VietNam = new CultureInfo("vi-VN");
        public List<SinhVien> DocDuLieu()
        {
            if (!File.Exists(FileData))
                File.Create(FileData).Close();
            List<SinhVien> List = new List<SinhVien>();
            StreamReader Reader = File.OpenText(FileData);
            string s = Reader.ReadLine();
            
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    DateTime time = DateTime.ParseExact(a[4],"dd/MM/yyyy",VietNam);
                    SinhVien sv = new SinhVien(a[0],a[1],a[2],a[3],time,a[5],a[6]);
                    List.Add(sv);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Thêm dữ liệu
        public void Them(SinhVien sv)
        {
            StreamWriter Fwrite = File.AppendText(FileData);
            Fwrite.WriteLine(sv.ToString());
            Fwrite.Close();
        }
        #endregion

        #region Ghi lại toàn bộ dữ liệu
        public void Ghi(List<SinhVien> list)
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
            List<SinhVien> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaSinhVien == id)
                    return i;
            }
            return -1;
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id, SinhVien sv)
        {
            List<SinhVien> list = DocDuLieu();
            list[ViTri(id)] = sv;
            Ghi(list);
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id)
        {
            List<SinhVien> list = DocDuLieu();
            list.RemoveAt(ViTri(id));
            Ghi(list);
        }
        #endregion
    }
}
