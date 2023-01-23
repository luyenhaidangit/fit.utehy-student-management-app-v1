using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Service.Interface
{
    public interface ISubjectService
    {
        List<Subject> GetAll();

        bool Add(Subject subject);

        bool Edit(string id, Subject subject);

        bool Delete(string id);

        bool SaveChanges(List<Subject> subjects);
    }
}
