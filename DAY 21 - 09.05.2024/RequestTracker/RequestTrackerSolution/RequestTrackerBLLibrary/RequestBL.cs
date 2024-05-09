using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestBL : IRequestService
    {
        private readonly IRepository<int, Request> _repository;
        public RequestBL()
        {
            IRepository<int, Request> repo = new RequestRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<bool> Add(Request request)
        {
            var req = await _repository.Get(request.RequestNumber);
            if (req != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Request> Delete(int key)
        {
            var Delreq = await _repository.Delete(key);
            return Delreq;
        }

        public async Task<Request> GetById(int key)
        {
            var Getreq = await _repository.Get(key);
            return Getreq;
        }
    }
}
