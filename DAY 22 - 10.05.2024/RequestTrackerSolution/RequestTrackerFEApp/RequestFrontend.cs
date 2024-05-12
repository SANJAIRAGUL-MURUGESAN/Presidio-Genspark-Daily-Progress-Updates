using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEApp
{
    public class RequestFrontend
    {
        IRequestServices RequestBL;
        public RequestFrontend()
        {
            RequestBL = new RequestBL();
        }
        public async Task AddRequest()
        {
            await Console.Out.WriteLineAsync("Please enter request message");
            string message = Console.ReadLine();
            await Console.Out.WriteLineAsync("Please enter your id");
            int id = Convert.ToInt32(Console.ReadLine());
            Request request = new Request() {RequestMessage = message, RequestRaisedBy = id, RequestClosedBy = id};
            var resultadded = RequestBL.Add(request);
            if (resultadded != null)
            {
                await Console.Out.WriteLineAsync($"Request Added : {resultadded.Result.RequestNumber}");
            }
            else
            {
                Console.Out.WriteLine("REquest failed");
            }
        }
    }
}
