using StudentManage.Data.Interface;
using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private string dataSource = "Subject.txt";

        #region Add
        public bool Add(Subject subject)
        {
            try
            {
                StreamWriter writer = File.AppendText(dataSource);
                writer.WriteLine(subject.ToString());
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
                List<Subject> subjects = GetAll();
                subjects.RemoveAt(subjects.FindIndex(x => x.Id == id));
                SaveChanges(subjects);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
         
        #region Edit
        public bool Edit(string id, Subject clas)
        {
            try
            {
                List<Subject> subjects = GetAll();
                subjects[subjects.FindIndex(x => x.Id == id)] = clas;
                SaveChanges(subjects);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get All
        public List<Subject> GetAll()
        {
            if (!File.Exists(dataSource))
            {
                File.Create(dataSource).Close();
            }
            List<Subject> subjects = new List<Subject>();
            StreamReader reader = File.OpenText(dataSource);
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line != "")
                {
                    string[] properties = line.Split('|');
                    Subject subject = new Subject(properties[0], properties[1],int.Parse(properties[2]));
                    subjects.Add(subject);
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return subjects;
        }
        #endregion

        #region Save Changes
        public bool SaveChanges(List<Subject> subjects)
        {
            try
            {
                StreamWriter writer = File.CreateText(dataSource);
                for (int i = 0; i < subjects.Count; ++i)
                {
                    writer.WriteLine(subjects[i].ToString());
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
