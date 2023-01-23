using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Model
{
    public class Schedule
    {
        #region Các thành phần dữ liệu
        private string idClass;
        private string idSubject;
        private string idTeacher;
        private int semester;
        #endregion

        #region Các thuộc tính
        public string IdClass { get => idClass; set => idClass = value; }
        public string IdSubject { get => idSubject; set => idSubject = value; }
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public int Semester { get => semester; set => semester = value; }
        public override string ToString()
        {
            return IdClass + "|" + IdSubject + "|" + IdTeacher + "|" + Semester;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public Schedule() { }
        //Phương thức thiết lập sao chép
        public Schedule(Schedule schedule)
        {
            this.IdClass = schedule.IdClass;
            this.IdSubject = schedule.IdSubject;
            this.IdTeacher = schedule.IdTeacher;
            this.Semester = schedule.Semester;
        }
        //Phương thức khởi tạo có tham số
        public Schedule(string idClass, string idSubject, string idTeacher,int semester)
        {
            this.IdClass = idClass;
            this.IdSubject = idSubject;
            this.IdTeacher = idTeacher;
            this.Semester = semester;
        }
        #endregion
    }
}
