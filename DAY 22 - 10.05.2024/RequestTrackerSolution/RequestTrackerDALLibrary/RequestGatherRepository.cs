﻿using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestGatherRepository : RequestRepository
    {
        public RequestGatherRepository(RequestTrackerContext context) : base(context)
        {
        }

        public async override Task<IList<Request>> GetAll()
        {
            return await _context.Requests.Include(r => r.RequestSolutions).ToListAsync();
        }
        public async override Task<Request> Get(int key)
        {
            var solution = _context.Requests.Include(r => r.RequestSolutions).SingleOrDefault(r => r.RequestNumber == key);
            return solution;
        }
    }
}
