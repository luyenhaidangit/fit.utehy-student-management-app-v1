using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data.Interface
{
    public interface IScheduleRepository
    {
        List<Schedule> GetAll();

        bool Add(Schedule schedule);

        bool Edit(string idClass,string idSubject, Schedule schedule);

        bool Delete(string idClass,string idSubject);

        bool SaveChanges(List<Schedule> schedules);
    }
}
