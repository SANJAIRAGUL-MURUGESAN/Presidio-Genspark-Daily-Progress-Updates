﻿using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IFeedbackServices
    {
        public Task<SolutionFeedback> Add(SolutionFeedback feedback);
        public Task<SolutionFeedback> Update(SolutionFeedback feedback);
    }
}
