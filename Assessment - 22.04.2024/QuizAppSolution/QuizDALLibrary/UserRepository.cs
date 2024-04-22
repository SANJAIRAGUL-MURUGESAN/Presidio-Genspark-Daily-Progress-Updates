using QuizAppModelLibrary;

namespace QuizDALLibrary
{
    public class UserRepository : IRepository<int, Users>
    {

        readonly Dictionary<int, Users> _Users;
        public UserRepository()
        {
            _Users = new Dictionary<int, Users>();
        }
        int GenerateId()
        {
            if (_Users.Count == 0)
                return 1;
            int id = _Users.Keys.Max();
            return ++id;
        }
        public Users Add(Users item)
        {
            if (_Users.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _Users.Add(item.Id, item);
            return item;
            throw new NotImplementedException();
        }

        public Users Delete(int key)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAll()
        {
            if (_Users.Count == 0)
                return null;
            return _Users.Values.ToList();
            throw new NotImplementedException();
        }

        public Users GetById(int key)
        {
            throw new NotImplementedException();
        }

        public Users Update(Users item)
        {
            throw new NotImplementedException();
        }
    }
}
