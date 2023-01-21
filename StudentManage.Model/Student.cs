using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Model
{
    public class Student
    {
        #region Các thành phần dữ liệu
        private string id;
        private string name;
        private string sex;
        private string andress;
        private DateTime birthday;
        private string numberphone;
        private string idClass;
        #endregion

        #region Các thuộc tính
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Andress { get => andress; set => andress = value; }
        public string Numberphone { get => numberphone; set => numberphone = value; }
        public string IdClass { get => idClass; set => idClass = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public override string ToString()
        {
            return Id + "|" + Name + "|" + Sex + "|" + Andress + "|" + Birthday.ToString("dd/MM/yyyy") + "|" + Numberphone + "|" + IdClass;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public Student() { }
        //Phương thức thiết lập sao chép
        public Student(Student student)
        {
            this.Id = student.Id;
            this.Name = student.Name;
            this.Sex = student.Sex;
            this.Andress = student.Andress;
            this.Numberphone = student.Numberphone;
            this.IdClass = student.IdClass;
            this.Birthday = student.Birthday;
        }
        //Phương thức khởi tạo có tham số
        public Student(string id, string name, string sex, string andress, DateTime birthday, string numberphone, string idClass)
        {
            this.Id = id;
            this.Name = name;
            this.Sex = sex;
            this.Andress = andress;
            this.Numberphone = numberphone;
            this.IdClass = idClass;
            this.Birthday = birthday;
        }
        #endregion
    }
}
