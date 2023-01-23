 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManage.Model;

namespace StudentManage.Data.Interface
{
    public interface ITeacherRepository
    {
        List<Teacher> GetAll();

        bool Add(Teacher teacher);

        bool Edit(string id, Teacher teacher);

        bool Delete(string id);

        bool SaveChanges(List<Teacher> teachers);
    }
}
