using StudentManage.Data.Interface;
using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private string dataSource = "Student.txt";

        #region Add
        public bool Add(Student student)
        {
            try
            {
                StreamWriter writer = File.AppendText(dataSource);
                writer.WriteLine(student.ToString());
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Delete
        public bool Delete(string id)
        {
            try
            {
                List<Student> studentes = GetAll();
                studentes.RemoveAt(studentes.FindIndex(x => x.Id == id));
                SaveChanges(studentes);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Edit
        public bool Edit(string id, Student student)
        {
            try
            {
                List<Student> studentes = GetAll();
                studentes[studentes.FindIndex(x => x.Id == id)] = student;
                SaveChanges(studentes);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get All
        CultureInfo vnCulInfo = new CultureInfo("vi-VN");
        public List<Student> GetAll()
        {
            if (!File.Exists(dataSource))
            {
                File.Create(dataSource).Close();
            }
            List<Student> studentes = new List<Student>();
            StreamReader reader = File.OpenText(dataSource);
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line != "")
                {
                    string[] properties = line.Split('|');
                    DateTime birthday = DateTime.ParseExact(properties[4], "dd/MM/yyyy", vnCulInfo);
                    Student student = new Student(properties[0], properties[1], properties[2], properties[3], birthday, properties[5], properties[6]);
                    studentes.Add(student);
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return studentes;
        }
        #endregion

        #region Save Changes
        public bool SaveChanges(List<Student> students)
        {
            try
            {
                StreamWriter writer = File.CreateText(dataSource);
                for (int i = 0; i < students.Count; ++i)
                {
                    writer.WriteLine(students[i].ToString());
                }
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
