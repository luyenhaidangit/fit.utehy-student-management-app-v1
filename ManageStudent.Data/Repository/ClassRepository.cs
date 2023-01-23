using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManage.Data.Interface;
using StudentManage.Model;

namespace StudentManage.Data.Repository
{
    public class ClassRepository : IClassRepository
    {
        private string dataSource = "Class.txt";

        #region Add
        public bool Add(Class clas)
        {
            try
            {
                StreamWriter writer = File.AppendText(dataSource);
                writer.WriteLine(clas.ToString());
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
                List<Class> classes = GetAll();
                classes.RemoveAt(classes.FindIndex(x => x.Id == id));
                SaveChanges(classes);
                return true;
            }
            catch
            {
                return false;
            } 
        }
        #endregion

        #region Edit
        public bool Edit(string id, Class clas)
        {
            try
            {
                List<Class> classes = GetAll();
                classes[classes.FindIndex(x => x.Id == id)] = clas;
                SaveChanges(classes);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get All
        public List<Class> GetAll()
        {
            if (!File.Exists(dataSource))
            {
                File.Create(dataSource).Close();
            }
            List<Class> classes = new List<Class>();
            StreamReader reader = File.OpenText(dataSource);
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line != "")
                {
                    string[] properties = line.Split('|');
                    Class clas = new Class(properties[0], properties[1], properties[2]);
                    classes.Add(clas);
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return classes;
        }
        #endregion

        #region Save Changes
        public bool SaveChanges(List<Class> classes)
        {
            try
            {
                StreamWriter writer = File.CreateText(dataSource);
                for (int i = 0; i < classes.Count; ++i)
                {
                    writer.WriteLine(classes[i].ToString());
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
