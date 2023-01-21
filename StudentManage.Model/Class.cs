using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Model
{
    public class Class
    {
        #region Các thành phần dữ liệu
        private string id;
        private string name;
        private string specialized;
        #endregion

        #region Các thuộc tính
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Specialized { get => specialized; set => specialized = value; }
        public override string ToString()
        {
            return Id + "|" + Name + "|" + Specialized;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public Class() { }
        //Phương thức thiết lập sao chép
        public Class(Class clas)
        {
            this.Id = clas.Id;
            this.Name = clas.Name;
            this.Specialized = clas.Specialized;
        }
        //Phương thức khởi tạo có tham số
        public Class(string id, string name, string specialized)
        {
            this.Id = id;
            this.Name = name;
            this.Specialized = specialized;
        }
        #endregion
    }
}
