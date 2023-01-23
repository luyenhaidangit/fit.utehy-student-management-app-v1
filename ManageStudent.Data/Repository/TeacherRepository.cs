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
    public class TeacherRepository : ITeacherRepository
    {
        private string dataSource = "Teacher.txt";

        #region Add
        public bool Add(Teacher teacher)
        {
            try
            {
                StreamWriter writer = File.AppendText(dataSource);
                writer.WriteLine(teacher.ToString());
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
                List<Teacher> teachers = GetAll();
                teachers.RemoveAt(teachers.FindIndex(x => x.Id == id));
                SaveChanges(teachers);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Edit
        public bool Edit(string id, Teacher teacher)
        {
            try
            {
                List<Teacher> teacheres = GetAll();
                teacheres[teacheres.FindIndex(x => x.Id == id)] = teacher;
                SaveChanges(teacheres);
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
        public List<Teacher> GetAll()
        {
            if (!File.Exists(dataSource))
            {
                File.Create(dataSource).Close();
            }
            List<Teacher> Teacheres = new List<Teacher>();
            StreamReader reader = File.OpenText(dataSource);
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line != "")
                {
                    string[] properties = line.Split('|');
                    DateTime birthday = DateTime.ParseExact(properties[4], "dd/MM/yyyy", vnCulInfo);
                    Teacher Teacher = new Teacher(properties[0], properties[1], properties[2], properties[3], birthday, properties[5]);
                    Teacheres.Add(Teacher);
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return Teacheres;
        }
        #endregion

        #region Save Changes
        public bool SaveChanges(List<Teacher> teachers)
        {
            try
            {
                StreamWriter writer = File.CreateText(dataSource);
                for (int i = 0; i < teachers.Count; ++i)
                {
                    writer.WriteLine(teachers[i].ToString());
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
