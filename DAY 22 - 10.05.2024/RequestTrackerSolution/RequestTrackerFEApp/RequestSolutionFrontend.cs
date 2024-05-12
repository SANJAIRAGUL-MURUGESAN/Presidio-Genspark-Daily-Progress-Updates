using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEApp
{
    public class RequestSolutionFrontend
    {
        IRequestSolutionServices requestsolutionBL;
        public RequestSolutionFrontend()
        {
            requestsolutionBL = new RequestSolutionBL();
        }

        public async Task AddSolution()
        {
            //IRequestSolutionServices requestsolutionBL = new RequestSolutionBL();
            await Console.Out.WriteLineAsync("Please enter solution message");
            string message = Console.ReadLine();
            await Console.Out.WriteLineAsync("Please enter request id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter Employee id");
            int eid = Convert.ToInt32(Console.ReadLine());
            RequestSolution solution = new RequestSolution() { SolutionDescription = message, RequestId = id, SolvedBy = eid };
            var resultadded = requestsolutionBL.Add(solution);
            if (resultadded != null)
            {
                await Console.Out.WriteLineAsync($"Request Added : {resultadded.Result.SolutionId}");
            }
            else
            {
                Console.Out.WriteLine("REquest failed");
            }
        }
    }
}
