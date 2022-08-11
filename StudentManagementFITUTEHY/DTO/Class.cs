using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Class
    {
        #region Thành phần dữ liệu
        private string idClass;
        private string nameClass;
        private string nameSpecialized;
        private int numberStudent;
        #endregion

        #region Phương thức khởi tạo
        public Class() { }

        public Class(string idClass, string nameClass, string nameSpecialized, int numberStudent)
        {
            this.IdClass = idClass;
            this.NameClass = nameClass;
            this.NameSpecialized = nameSpecialized;
            this.NumberStudent = numberStudent;
        }
        #endregion

        #region Khai báo thuộc tính
        public string IdClass { get => idClass; set => idClass = value; }
        public string NameClass { get => nameClass; set => nameClass = value; }
        public string NameSpecialized { get => nameSpecialized; set => nameSpecialized = value; }
        public int NumberStudent { get => numberStudent; set => numberStudent = value; }
        public override string ToString()
        {
            return IdClass + "|" + NameClass + "|" + NameSpecialized + "|" + NumberStudent.ToString();
        }
        #endregion
    }
}
