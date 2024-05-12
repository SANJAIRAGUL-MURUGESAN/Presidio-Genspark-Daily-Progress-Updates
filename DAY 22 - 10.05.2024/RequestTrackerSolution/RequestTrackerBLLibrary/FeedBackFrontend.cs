using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class FeedBackFrontend
    {
        IFeedbackServices feedbackBL;
        public FeedBackFrontend()
        {
            feedbackBL = new FeedBackBL();
        }
        public async Task AddFeedback()
        {
            //IFeedbackServices feedbackBL = new FeedBackBL();
            await Console.Out.WriteLineAsync("Please enter remarks");
            string message = Console.ReadLine();
            //await Console.Out.WriteLineAsync("Please enter rating");
            float rating = (float)9.7;
            await Console.Out.WriteLineAsync("Please enter Employee id");
            int eid = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter Solution id");
            int sid = Convert.ToInt32(Console.ReadLine());
            SolutionFeedback feedback = new SolutionFeedback() { Remarks = message, Rating = rating, FeedbackBy = eid, SolutionId = sid};
            var resultadded = feedbackBL.Add(feedback);
            if (resultadded != null)
            {
                await Console.Out.WriteLineAsync($"Request Added : {resultadded.Result}");
            }
            else
            {
                Console.Out.WriteLine("Request failed");
            }
        }
    }
}
