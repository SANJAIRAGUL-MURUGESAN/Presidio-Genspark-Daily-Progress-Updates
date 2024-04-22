using QuizAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDALLibrary
{
    public class QuizRepository : IRepository<int, Quiz>
    {
        readonly Dictionary<int, Quiz> _Quizs;

        public QuizRepository()
        {
            _Quizs = new Dictionary<int, Quiz>();
        }
        int GenerateId()
        {
            if (_Quizs.Count == 0)
                return 1;
            int id = _Quizs.Keys.Max();
            return ++id;
        }
        public Quiz Add(Quiz item)
        {
            item.Id = GenerateId();
            _Quizs.Add(item.Id, item);
            return item;
            throw new NotImplementedException();
        }
        public List<Quiz> GetAll()
        {
            if (_Quizs.Count == 0)
                return null;
            return _Quizs.Values.ToList();
            throw new NotImplementedException();
        }

        public Quiz GetById(int key)
        {
            if (_Quizs.ContainsKey(key))
            {
                var result = _Quizs[key];
                return result;
            }
            else
            {
                return null;
            }
            //return _Quizs[key] ?? null;
        }

        public Quiz Update(Quiz item)
        {
            if (_Quizs.ContainsKey(item.Id))
            {
                _Quizs[item.Id] = item;
                return item;
            }
            throw new NotImplementedException();
        }

        public Quiz Delete(int key)
        {
            if (_Quizs.ContainsKey(key))
            {
                var quiz = _Quizs[key];
                _Quizs.Remove(key);
                return quiz;
            }
            return null;
            throw new NotImplementedException();
        }
    }
}
