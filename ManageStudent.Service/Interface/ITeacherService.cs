using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Service.Interface
{
    public interface ITeacherService
    {
        List<Teacher> GetAll();

        bool Add(Teacher teacher);

        bool Edit(string id, Teacher teacher);

        bool Delete(string id);

        bool SaveChanges(List<Teacher> teachers);
    }
}
