using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestServices
    {
        public Task<Request> Add(Request request);
        public Task<Request> Update(Request item);
        public Task<Request> GetRequestByID(int key);
        public Task<Request> GetAllRequests(int key); // to get all request and solution 
    }
}
