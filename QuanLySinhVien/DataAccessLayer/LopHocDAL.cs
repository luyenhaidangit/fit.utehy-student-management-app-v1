using System.Collections.Generic;
using QuanLySinhVien.Entities;
using System.IO;
using QuanLySinhVien.DataAccessLayer.Interface;

namespace QuanLySinhVien.DataAccessLayer
{
    class LopHocDAL : IQuanLyDAL<LopHoc>
    {
        #region Đường dẫn tệp
        private string FileData = "LopHoc.txt";
        #endregion
         
        #region Đọc dữ liệu
        public List<LopHoc> DocDuLieu()
        {
            if (!File.Exists(FileData))
                File.Create(FileData).Close();
            List<LopHoc> List = new List<LopHoc>();
            StreamReader Reader = File.OpenText(FileData);
            string s = Reader.ReadLine();
            while(s!=null)
            {
                if(s!="")
                {
                    string[] a = s.Split('|');
                    LopHoc lh = new LopHoc(a[0], a[1], a[2]);
                    List.Add(lh);
                }
                s = Reader.ReadLine();
            }
            Reader.Close();
            return List;
        }
        #endregion

        #region Thêm dữ liệu vào tệp
        public void Them(LopHoc lh)
        {
            StreamWriter Fwrite = File.AppendText(FileData);
            Fwrite.WriteLine(lh.MaLop + "|" + lh.TenLop + "|" + lh.ChuyenNganh);
            Fwrite.Close();
        }
        #endregion

        #region Ghi lại toàn bộ dữ liệu
        public void Ghi(List<LopHoc> list)
        {
            StreamWriter Fwrite = File.CreateText(FileData);
            for(int i =0;i < list.Count;++i)
            {
                Fwrite.WriteLine(list[i].ToString());
            }
            Fwrite.Close();
        }
        #endregion

        #region Tìm vị trí bản ghi
        public int ViTri(string id)
        {
            List<LopHoc> list = DocDuLieu();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaLop == id)
                    return i;
            }
            return -1;
        }
        #endregion

        #region Sửa dữ liệu
        public void Sua(string id,LopHoc lh)
        {
            List <LopHoc> list = DocDuLieu();
            list[ViTri(id)] = lh;
            Ghi(list);
        }
        #endregion

        #region Xóa dữ liệu
        public void Xoa(string id)
        {
            List<LopHoc> list = DocDuLieu();
            list.RemoveAt(ViTri(id));
            Ghi(list);
        }
        #endregion
    }
}
