using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Entities;
using System.IO;
using QuanLySinhVien.DataAccessLayer.Interface;
namespace QuanLySinhVien.DataAccessLayer
{
    public class DiemSoDAL : IQuanLyDAL<DiemSo>
    {
        #region Đường dẫn tệp
        private string FileData = "DiemSo.txt";
        #endregion

        #region Đọc dữ liệu
        public List<DiemSo> DocDuLieu()
        {
            if (!File.Exists(FileData))
                File.Create(FileData).Close();
            List<DiemSo> List = new List<DiemSo>();
            StreamReader Reader = File.OpenText(FileData);
            string s = Reader.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('|');
                    DiemSo ds = new DiemSo(a[0], a[1], double.Parse(a[2]), double.Parse(a[3]));
                    List.Add(ds);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Thêm dữ liệu
        public void Them(DiemSo ds)
        {
            StreamWriter Fwrite = File.AppendText(FileData);
            Fwrite.WriteLine(ds.ToString());
            Fwrite.Close();
        }
        #endregion

        #region Ghi lại toàn bộ dữ liệu
        public void Ghi(List<DiemSo> list)
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
            throw new NotImplementedException();
        }
        public int ViTri(string id1,string id2)
        {
            List<DiemSo> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaSinhVien == id1 && list[i].MaMonHoc == id2)
                    return i;
            }
            return -1;
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id, DiemSo lh)
        {
            throw new NotImplementedException();
        }
        public void Sua(string id1,string id2, DiemSo ds)
        {
            List<DiemSo> list = DocDuLieu();
            list[ViTri(id1,id2)] = ds;
            Ghi(list);
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id)
        {
            throw new NotImplementedException();
        }
        public void Xoa(string id1,string id2)
        {
            List<DiemSo> list = DocDuLieu();
            list.RemoveAt(ViTri(id1,id2));
            Ghi(list);
        }
        #endregion
    }
}
