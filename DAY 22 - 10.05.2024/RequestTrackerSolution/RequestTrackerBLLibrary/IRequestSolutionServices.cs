using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestSolutionServices
    {
        public Task<RequestSolution> Add(RequestSolution solution);
        public Task<RequestSolution> Update(RequestSolution solution);
        public Task<RequestSolution> GetSolutionsWithFeedback(int key);
        public Task<RequestSolution> GetSolution(int key);
        public Task<IList<RequestSolution>> GetAllSolutions();
    }
}
