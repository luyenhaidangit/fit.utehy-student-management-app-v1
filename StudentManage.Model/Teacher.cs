using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Entities
{
    public class Teacher
    {
        #region Các thành phần dữ liệu
        private string id;
        private string name;
        private string sex;
        private string andress;
        private DateTime birthday;
        private string numberphone;
        #endregion

        #region Các thuộc tính
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Andress { get => andress; set => andress = value; }
        public string Numberphone { get => numberphone; set => numberphone = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }

        public override string ToString()
        {
            return Id + "|" + Name + "|" + Sex + "|" + Andress + "|" + Birthday.ToString("dd/MM/yyyy") + "|" + Numberphone;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public Teacher() { }
        //Phương thức thiết lập sao chép
        public Teacher(Teacher teacher)
        {
            this.Id = teacher.Id;
            this.Name = teacher.Name;
            this.Sex = teacher.Sex;
            this.Andress = teacher.Andress;
            this.Numberphone = teacher.Numberphone;
            this.Birthday = teacher.Birthday;
        }
        //Phương thức khởi tạo có tham số
        public Teacher(string id, string name, string sex, string andress, DateTime birthday, string numberphone)
        {
            this.Id = id;
            this.Name = name;
            this.Sex = sex;
            this.Andress = andress;
            this.Numberphone = numberphone;
            this.Birthday = birthday;
        }
        #endregion
    }
}
