using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class FeedBackBL : IFeedbackServices
    {
        private readonly IRepository<int, SolutionFeedback> _repository;
        public FeedBackBL()
        {
            IRepository<int, SolutionFeedback> repo = new SolutionFeedbackRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<SolutionFeedback> Add(SolutionFeedback feedback)
        {
            var result = await _repository.Add(feedback);
            return result;
        }

        public Task<SolutionFeedback> Update(SolutionFeedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}
