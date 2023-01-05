using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Entities;

namespace QuanLySinhVien.BusinessLayer.Interface
{
    public interface IQuanLyBLL<T>
    {
        List<T> DocDuLieu();

        void Them(T Object);

        void Sua(string id, T Object);

        void Xoa(string id);

        void Ghi(List<T> ListObject);

        int ViTri(string id);
    }
}
