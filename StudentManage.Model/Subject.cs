using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Entities
{
    public class Subject
    {
        #region Các thành phần dữ liệu
        private string id;
        private string name;
        private int numberCredit;
        #endregion

        #region Các thuộc tính
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int NumberCredit { get => numberCredit; set => numberCredit = value; }
        public override string ToString()
        {
            return Id + "|" + Name + "|" + NumberCredit;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public Subject() { }
        //Phương thức thiết lập sao chép
        public Subject(Subject subject)
        {
            this.Id = subject.Id;
            this.Name = subject.Name;
            this.NumberCredit = subject.NumberCredit;
        }
        //Phương thức khởi tạo có tham số
        public Subject(string id, string name, int numberCredit)
        {
            this.Id = id;
            this.Name = name;
            this.NumberCredit = numberCredit;
        }
        #endregion
    }
}
