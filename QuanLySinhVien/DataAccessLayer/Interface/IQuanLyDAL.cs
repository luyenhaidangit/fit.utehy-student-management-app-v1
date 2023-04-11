using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Entities;

namespace QuanLySinhVien.DataAccessLayer.Interface
{
    public interface IQuanLyDAL<T>
    {
        List<T> DocDuLieu();

        void Them(T myObject);

        void Sua(string id,T myObject);

        void Xoa(string id);

        void Ghi(List<T> myListObject);

        int ViTri(string id);
    }
}
