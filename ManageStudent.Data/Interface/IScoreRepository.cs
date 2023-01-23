using StudentManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data.Interface
{
    public interface IScoreRepository
    {
        List<Score> GetAll();

        bool Add(Score score);

        bool Edit(string idStudent, string idSubject, Score score);

        bool Delete(string idStudent, string idSubject);

        bool SaveChanges(List<Score> Scores);
    }
}
