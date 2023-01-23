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
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _subjectRepository = new SubjectRepository();

        public bool Add(Subject subject)
        {
            return _subjectRepository.Add(subject);
        }

        public bool Delete(string id)
        {
            return _subjectRepository.Delete(id);
        }

        public bool Edit(string id, Subject subject)
        {
            return _subjectRepository.Edit(id, subject);
        }

        public List<Subject> GetAll()
        {
            return _subjectRepository.GetAll();
        }

        public bool SaveChanges(List<Subject> subjects)
        {
            return _subjectRepository.SaveChanges(subjects);
        }
    }
}
