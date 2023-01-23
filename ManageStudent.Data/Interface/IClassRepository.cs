using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManage.Model;

namespace StudentManage.Data.Interface
{
    public interface IClassRepository
    {
        List<Class> GetAll();

        bool Add(Class clas);

        bool Edit(string id, Class clas);

        bool Delete(string id);

        bool SaveChanges(List<Class> classes);
    }
}
