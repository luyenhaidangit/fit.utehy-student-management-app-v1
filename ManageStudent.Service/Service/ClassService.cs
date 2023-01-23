using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManage.Data.Interface;
using StudentManage.Data.Repository;
using StudentManage.Model;
using StudentManage.Service.Interface;

namespace StudentManage.Service
{
    public class ClassService : IClassService
    {
        private IClassRepository _classRepository = new ClassRepository();

        public bool Add(Class clas)
        {
            return _classRepository.Add(clas);
        }

        public bool Delete(string id)
        {
            return _classRepository.Delete(id);
        }

        public bool Edit(string id, Class clas)
        {
            return _classRepository.Edit(id, clas);
        }

        public List<Class> GetAll()
        {
            return _classRepository.GetAll();
        }

        public bool SaveChanges(List<Class> classes)
        {
            return _classRepository.SaveChanges(classes);
        }
    }
}
