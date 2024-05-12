using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        protected readonly RequestTrackerContext _context;
        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<RequestSolution> Delete(int key)
        {
            var solution  = await Get(key);
            if (solution != null)
            {
                _context.RequestSolutions.Remove(solution);
                await _context.SaveChangesAsync();
            }
            return solution;
        }
        public virtual async Task<RequestSolution> Get(int key)
        {
            var solution = _context.RequestSolutions.SingleOrDefault(e => e.SolutionId == key);
            return solution;
        }

        public virtual async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var solution = await Get(entity.SolutionId);
            if (solution != null)
            {
                _context.Entry(solution).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                //_context.Entry<RequestSolution>(entity).State = EntityState.Modified;
                //await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
