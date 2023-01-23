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
    public class ScoreRepository : IScoreRepository
    {
        private string dataSource = "Score.txt";

        public bool Add(Score score)
        {
            try
            {
                StreamWriter writer = File.AppendText(dataSource);
                writer.WriteLine(score.ToString());
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string idStudent, string idSubject)
        {
            try
            {
                List<Score> scores = GetAll();
                scores.RemoveAt(scores.FindIndex(x => x.IdStudent == idStudent && x.IdSubject == idSubject));
                SaveChanges(scores);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(string idStudent, string idSubject, Score score)
        {
            try
            {
                List<Score> scores = GetAll();
                scores[scores.FindIndex(x => x.IdStudent == idStudent && x.IdSubject == idSubject)] = score;
                SaveChanges(scores);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Score> GetAll()
        {
            if (!File.Exists(dataSource))
            {
                File.Create(dataSource).Close();
            }
            List<Score> scores = new List<Score>();
            StreamReader reader = File.OpenText(dataSource);
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line != "")
                {
                    string[] properties = line.Split('|');
                    Score score = new Score(properties[0], properties[1], double.Parse(properties[2]), double.Parse(properties[3]));
                    scores.Add(score);
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return scores;
        }

        public bool SaveChanges(List<Score> scores)
        {
            try
            {
                StreamWriter writer = File.CreateText(dataSource);
                for (int i = 0; i < scores.Count; ++i)
                {
                    writer.WriteLine(scores[i].ToString());
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
