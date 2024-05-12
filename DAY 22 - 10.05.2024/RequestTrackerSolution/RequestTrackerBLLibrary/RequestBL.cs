using RequestTrackerBLLibrary.RequestExceptions;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestServices
    {
        private readonly IRepository<int, Request> _repository;
        private readonly IRepository<int, Request> _repository2;
        public RequestBL()
        {
            IRepository<int, Request> repo = new RequestRepository(new RequestTrackerContext());
            _repository = repo;
            IRepository<int, Request> repo2 = new RequestGatherRepository(new RequestTrackerContext());
            _repository2 = repo2;
        }
        public async Task<Request> Add(Request request)
        {
            var result = await _repository.Add(request);
            return result;
        }
         public async Task<Request> GetRequestByID(int key)
        {
            var result = await _repository.Get(key);
            if (result != null)
            {
                return result;
            }
            throw new NoRequestFoundException();
        }
        public async Task<Request> Update(Request item)
        {
            var result = await _repository.Get(item.RequestNumber);
            if (result != null)
            {
                return await _repository.Update(result);
            }
            throw new NoRequestFoundException();
        }

        public async Task<Request> GetAllRequests(int key)
        {
            var result = await _repository2.Get(key);
            if(result != null)
            {
                return result;
            }
            throw new NoRequestFoundException();
        }
    }
}
