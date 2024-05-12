using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRequestRepository : RequestSolutionRepository
    {
        public RequestSolutionRequestRepository(RequestTrackerContext context) : base(context)
        {
        }
        public async override Task<RequestSolution> Get(int key)
        {
            var employee = _context.RequestSolutions.Include(e => e.Feedbacks).SingleOrDefault(e => e.SolutionId == key);
            return employee;
        }
    }
}
