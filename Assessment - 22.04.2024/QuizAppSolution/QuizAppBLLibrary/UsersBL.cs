using QuizAppModelLibrary;
using QuizDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppBLLibrary
{
    public class UsersBL : IUserService
    {
        readonly IRepository<int, Users> _userRepository;
        public UsersBL()
        {
            _userRepository = new UserRepository();
        }
        public Users AddUser(Users user)
        {
            var result = _userRepository.Add(user);
            if (result != null)
            {
                return result;
            }
            throw new NotImplementedException();
        }

        public int CheckUser(string name, string password)
        {
            List<Users> list = _userRepository.GetAll();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name == name)
                    {
                        if (list[i].Password == password)
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
            return 0 ;
        }

        
    }
}
