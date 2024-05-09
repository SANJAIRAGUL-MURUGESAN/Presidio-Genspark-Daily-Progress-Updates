using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestService
    {
        public Task<bool> Add(Request request);
        public Task<Request> Delete(int key);
        public Task<Request> GetById(int key);
    }
}
