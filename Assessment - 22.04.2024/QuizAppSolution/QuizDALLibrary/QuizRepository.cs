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

        public Quiz Get(int key)
        {
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
            return _Quizs[key] ?? null;
        }
    }
}
