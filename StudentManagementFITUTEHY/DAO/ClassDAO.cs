using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAO.Interface;
using DTO;

namespace DAO
{
    public class ClassDAO : IDAO<Class, Class>
    {
        string fileData = "Class.txt";

        #region Lấy danh sách lớp học
        public List<Class> GetData()
        {
            if (!File.Exists(fileData))
            {
                File.Create(fileData).Close();
            }
            List<Class> classList = new List<Class>();
            StreamReader streamReader = File.OpenText(fileData);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                if (line.Trim() != "")
                {
                    string[] classArr = line.Split('|');
                    Class cl = new Class(classArr[0], classArr[1], classArr[2], int.Parse(classArr[3]));
                    classList.Add(cl);
                }
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            return classList;
        }
        #endregion

        #region Thêm thông tin lớp học
        public void Add(Class Object)
        {
            StreamWriter streamWriter = File.AppendText(fileData);
            streamWriter.WriteLine(Object.ToString());
            streamWriter.Close();
        }
        #endregion

        #region Xóa thông tin lớp học
        public void Delete(Class ObjectOld)
        {
            List<Class> listClass = GetData();
            int index = -1;
            for (int i = 0; i < listClass.Count; i++)
            {
                if (listClass[i].IdClass == ObjectOld.IdClass)
                {
                    index = i;
                    break;
                }
            }
            listClass.RemoveAt(index);
            Save(listClass);
        }
        #endregion

        #region Sửa thông tin lớp học
        public void Edit(Class ObjectOld, Class ObjectNew)
        {
            List<Class> listClass = GetData();
            int index = -1;
            for (int i = 0; i < listClass.Count; i++)
            {
                if (listClass[i].IdClass == ObjectOld.IdClass)
                {
                    index = i;
                    break;
                }
            }
            listClass[index] = ObjectNew;
            Save(listClass);
        }
        #endregion

        #region Lưu thông tin lớp học
        public void Save(List<Class> listObject)
        {
            StreamWriter streamWriter = File.CreateText(fileData);
            for (int i = 0; i < listObject.Count; ++i)
            {
                streamWriter.WriteLine(listObject[i].ToString());
            }
            streamWriter.Close();
        }
        #endregion
    }
}
