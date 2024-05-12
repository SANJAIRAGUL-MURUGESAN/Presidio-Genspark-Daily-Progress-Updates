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
    public class RequestSolutionBL : IRequestSolutionServices
    {
        private readonly IRepository<int, RequestSolution> _repository;
        private readonly IRepository<int, RequestSolution> _repository2;

        public RequestSolutionBL()
        {
            IRepository<int, RequestSolution> repo = new RequestSolutionRepository(new RequestTrackerContext());
            _repository = repo;
            IRepository<int, RequestSolution> repo2 = new RequestSolutionRequestRepository(new RequestTrackerContext());
            _repository2 = repo2;
        }
        public async Task<RequestSolution> Add(RequestSolution solution)
        {
            var result = await _repository.Add(solution);
            return result ;
        }

        public async Task<RequestSolution> Update(RequestSolution solution)
        {
            var result = await _repository.Update(solution);
            return result;
        }

        public async Task<RequestSolution> GetSolutionsWithFeedback(int key)
        {
            var result = await _repository2.Get(key);
            if(result != null)
            {
                return result;
            }
            throw new NoRequestSolutionFoundException();
        }

        public async Task<RequestSolution> GetSolution(int key)
        {
            var result = await _repository.Get(key);
            if (result != null)
            {
                return result;
            }
            throw new NoRequestSolutionFoundException();
        }

        public async Task<IList<RequestSolution>> GetAllSolutions()
        {
            var result = await _repository.GetAll();
            if (result != null)
            {
                return result;
            }
            throw new NoRequestSolutionFoundException();
        }
    }
}
