using ManageStudent.Service.Interface;
using StudentManage.Data.Interface;
using StudentManage.Data.Repository;
using StudentManage.Model;
using StudentManage.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Service.Service
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository = new StudentRepository();

        public bool Add(Student student)
        {
            return _studentRepository.Add(student);
        }

        public bool Delete(string id)
        {
            return _studentRepository.Delete(id);
        }

        public bool Edit(string id, Student student)
        {
            return _studentRepository.Edit(id, student);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public bool SaveChanges(List<Student> students)
        {
            return _studentRepository.SaveChanges(students);
        }
    }
}
