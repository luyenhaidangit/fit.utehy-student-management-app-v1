using ManageStudent.Service.Interface;
using StudentManage.Data.Interface;
using StudentManage.Data.Repository;
using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Service.Service
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository = new TeacherRepository();

        public bool Add(Teacher teacher)
        {
            return _teacherRepository.Add(teacher);
        }

        public bool Delete(string id)
        {
            return _teacherRepository.Delete(id);
        }

        public bool Edit(string id, Teacher teacher)
        {
            return _teacherRepository.Edit(id, teacher);
        }

        public List<Teacher> GetAll()
        {
            return _teacherRepository.GetAll();
        }

        public bool SaveChanges(List<Teacher> teachers)
        {
            return _teacherRepository.SaveChanges(teachers);
        }
    }
}
