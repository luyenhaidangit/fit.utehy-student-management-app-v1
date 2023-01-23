using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Service.Interface
{
    public interface IClassService
    {
        List<Class> GetAll();

        bool Add(Class clas);

        bool Edit(string id, Class clas);

        bool Delete(string id);

        bool SaveChanges(List<Class> classes);
    }
}
