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
    public class ScheduleService : IScheduleService
    {
        private IScheduleRepository _scheduleRepository = new ScheduleRepository();

        public bool Add(Schedule schedule)
        {
            return _scheduleRepository.Add(schedule);
        }

        public bool Delete(string idClass, string idSubject)
        {
            return _scheduleRepository.Delete(idClass, idSubject);
        }

        public bool Edit(string idClass, string idSubject, Schedule schedule)
        {
            return _scheduleRepository.Edit(idClass, idSubject, schedule);
        }

        public List<Schedule> GetAll()
        {
            return _scheduleRepository.GetAll();
        }

        public bool SaveChanges(List<Schedule> schedules)
        {
            return _scheduleRepository.SaveChanges(schedules);
        }
    }
}
