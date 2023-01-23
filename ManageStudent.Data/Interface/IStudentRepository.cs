using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data.Interface
{
    public interface IStudentRepository
    {
        List<Student> GetAll();

        bool Add(Student student);

        bool Edit(string id, Student student);

        bool Delete(string id);

        bool SaveChanges(List<Student> students);
    }
}
