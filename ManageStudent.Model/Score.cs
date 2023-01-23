using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManage.Model
{
    public class Score
    {
        #region Các thành phần dữ liệu
        private string idStudent;
        private string idSubject;
        private double firstScore;
        private double secondScore;
        #endregion

        #region Các thuộc tính
        public string IdSubject { get => idSubject; set => idSubject = value; }
        public string IdStudent { get => idStudent; set => idStudent = value; }
        public double FirstScore { get => firstScore; set => firstScore = value; }
        public double SecondScore { get => secondScore; set => secondScore = value; }
        public double GPA { get => (firstScore + secondScore) / 2; }
        public string Classification
        {
            get 
            {
                if (firstScore < 5 || secondScore < 5)
                {
                    return "Thi Lại";
                }
                else return "Qua Môn";
            }
        }
        
        public override string ToString()
        {
            return IdStudent + "|" + IdSubject + "|" + FirstScore + "|" + SecondScore;
        }
        #endregion

        #region Các thương thức  
        //Phương thức khởi tạo không tham số
        public Score() { }
        //Phương thức thiết lập sao chép
        public Score(Score score)
        {
            this.idSubject = score.idSubject;
            this.idStudent = score.idStudent;
            this.firstScore = score.firstScore;
            this.secondScore = score.secondScore;
        }
        //Phương thức khởi tạo có tham số
        public Score(string idStudent, string idSubject, double firstScore, double secondScore)
        {
            this.idStudent = idStudent;
            this.idSubject = idSubject;
            this.firstScore = firstScore;
            this.secondScore = secondScore;
        }
        #endregion
    }
}
