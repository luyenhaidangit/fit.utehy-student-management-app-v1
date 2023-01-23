using StudentManage.Data.Interface;
using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private string dataSource = "Schedule.txt";

        public bool Add(Schedule schedule)
        {
            try
            {
                StreamWriter writer = File.AppendText(dataSource);
                writer.WriteLine(schedule.ToString());
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string idClass, string idSubject)
        {
            try
            {
                List<Schedule> schedules = GetAll();
                schedules.RemoveAt(schedules.FindIndex(x => x.IdClass == idClass && x.IdSubject == idSubject));
                SaveChanges(schedules);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(string idClass, string idSubject, Schedule schedule)
        {
            try
            {
                List<Schedule> schedules = GetAll();
                schedules[schedules.FindIndex(x => x.IdClass == idClass && x.IdSubject == idSubject)] = schedule;
                SaveChanges(schedules);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Schedule> GetAll()
        {
            if (!File.Exists(dataSource))
            {
                File.Create(dataSource).Close();
            }
            List<Schedule> schedules = new List<Schedule>();
            StreamReader reader = File.OpenText(dataSource);
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line != "")
                {
                    string[] properties = line.Split('|');
                    Schedule schedule = new Schedule(properties[0], properties[1], properties[2],int.Parse(properties[3]));
                    schedules.Add(schedule);
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return schedules;
        }

        public bool SaveChanges(List<Schedule> schedules)
        {
            try
            {
                StreamWriter writer = File.CreateText(dataSource);
                for (int i = 0; i < schedules.Count; ++i)
                {
                    writer.WriteLine(schedules[i].ToString());
                }
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
