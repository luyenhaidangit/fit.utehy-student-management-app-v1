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
    public class ScoreService : IScoreService
    {
        private IScoreRepository _scoreRepository = new ScoreRepository();

        public bool Add(Score score)
        {
            return _scoreRepository.Add(score);
        }

        public bool Delete(string idStudent, string idSubject)
        {
            return _scoreRepository.Delete(idStudent, idSubject);   
        }

        public bool Edit(string idStudent, string idSubject, Score score)
        {
            return _scoreRepository.Edit(idStudent, idSubject, score);
        }

        public List<Score> GetAll()
        {
            return _scoreRepository.GetAll();
        }

        public bool SaveChanges(List<Score> scores)
        {
            return _scoreRepository.SaveChanges(scores);
        }
    }
}
