using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Interface;
using DAO;
using DAO.Interface;
using DTO;
using Common;

namespace BUS
{
    public class ClassBUS : IBUS<Class, Class>
    {

        public IDAO<Class, Class> clDAO = new ClassDAO();

        #region Thêm thông tin lớp học
        public void Add(Class Object)
        {
            Object.IdClass = Normalize.String(Object.IdClass);
            Object.NameClass = Normalize.String(Object.NameClass);
            Object.NameSpecialized = Normalize.String(Object.NameSpecialized);
            Object.NumberStudent = Object.NumberStudent;
            clDAO.Add(Object);
        }
        #endregion

        #region Xóa thông tin lớp học
        public void Delete(Class objectOld)
        {
            clDAO.Delete(objectOld);
        }
        #endregion

        #region Sửa thông tin lớp học
        public void Edit(Class objectOld, Class objectNew)
        {
            objectNew.IdClass = Normalize.String(objectNew.IdClass);
            objectNew.NameClass = Normalize.String(objectNew.NameClass);
            objectNew.NameSpecialized = Normalize.String(objectNew.NameSpecialized);
            objectNew.NumberStudent = objectNew.NumberStudent;
            clDAO.Edit(objectOld, objectNew);
        }
        #endregion

        #region Lấy danh sách lớp học
        public List<Class> GetData()
        {
            return clDAO.GetData();
        }
        #endregion

        #region Lưu thông tin lớp học
        public void Save(List<Class> listObject)
        {
            clDAO.Save(listObject);
        }
        #endregion

        #region Lấy danh sách mã lớp
        public List<string> GetListIDClass()
        {
            List<string> list = new List<string>();
            foreach (Class obj in GetData())
            {
                list.Add(obj.IdClass);
            }
            return list;
        }
        #endregion

        #region Kiểm tra tồn tại mã lớp
        public bool CheckIDClassExists(string id)
        {
            List<string> list = GetListIDClass();
            if (list.Contains(id) == false && id.Length != 0)
            {
                return true;
            }
            else return false;
        }
        #endregion

        #region Kiểm tra tên chuyên ngành hợp lệ
        public bool CheckValidNameSpecialized(string nameSpecialized)
        {
            List<string> list = new List<string>();
            list.Add("Công Nghệ Web");
            list.Add("Công Nghệ Di Động");
            list.Add("Kiểm Thử Phần Mềm");
            list.Add("Mạng Máy Tính");
            list.Add("Iot");
            list.Add("Đồ Họa");
            list.Add("Khoa Học Dữ Liệu");
            list.Add("Xử Lý Ngôn Ngữ");
            list.Add("Nhận Dạng Hình Ảnh");
            if (list.Contains(Normalize.String(nameSpecialized)) == true)
            {
                return true;
            }
            else return false;
        }
        #endregion
    }
}
