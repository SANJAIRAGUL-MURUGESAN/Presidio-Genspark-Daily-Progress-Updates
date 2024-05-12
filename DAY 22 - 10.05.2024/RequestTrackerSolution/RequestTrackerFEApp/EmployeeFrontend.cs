using RequestTrackerBLLibrary;
using RequestTrackerBLLibrary.RequestExceptions;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEApp
{
    public class EmployeeFrontend
    {
        IEmployeeService employeeBL;

        IRequestServices requestBL;

        IFeedbackServices feedbackBL;

        IRequestSolutionServices requestSolutionBL;
        public EmployeeFrontend()
        {
            employeeBL = new EmployeeBL();
            requestBL = new RequestBL();
            feedbackBL = new FeedBackBL();
            requestSolutionBL = new RequestSolutionBL();
        }

        // Employee Registration with Role
        public async Task EmployeeRegister()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Name");
            string name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Please enter your Password");
            string password = Console.ReadLine() ?? "";
            await Console.Out.WriteLineAsync("Please enter your Role");
            string role = Console.ReadLine() ?? "";
            Employee employee = new Employee() { Name = name, Password = password, Role = role };
            var resultadded = employeeBL.Register(employee);
            if (resultadded != null)
            {
                await Console.Out.WriteLineAsync($"Register Success with Username: {resultadded.Result.Name}");
            }
            else
            {
                Console.Out.WriteLine("Registeration failed");
            }
        }

        //Employee Login
        public async Task EmployeeLogin()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            Employee employee = new Employee() { Password = password, Id = id };
            var result = await employeeBL.Login(employee);
            if (result)
            {
                await Console.Out.WriteLineAsync("Login Success");
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }

        // To Get Request and Solution using Employee ID
        public async Task GetEmployeeRequestSolutionByEmployeeID()
        {
            try
            {
                Console.WriteLine("Enter your Employee ID :");
                int EmployeeID = Convert.ToInt32(Console.ReadLine());
                var employee = await employeeBL.GetRequestSolutionsByEmployeeID(EmployeeID);
                if (employee != null)
                {
                    {
                        Console.WriteLine($"{employee.Name}");
                        foreach (Request request in employee.RequestsRaised)
                        {
                            Console.WriteLine("-----------------------------------------------------");
                            Console.Out.WriteLine($"Request Description : {request.RequestMessage}");
                            Console.Out.WriteLine($"Request status : {request.RequestStatus}");
                            Console.WriteLine("Here we go with your solutions by Admin Team:");
                            int RequestID = request.RequestNumber;
                            var requets = await requestBL.GetAllRequests(RequestID);
                            if (requets != null)
                            {
                                foreach (RequestSolution solution in requets.RequestSolutions)
                                {
                                    Console.WriteLine("-----------------------------------------------------");
                                    Console.WriteLine(solution.SolutionDescription);
                                    Console.WriteLine("-----------------------------------------------------");
                                }
                            }
                            Console.WriteLine("-----------------------------------------------------");
                        }
                    }
                }
            }
            catch (NoRequestFoundException Nrfe)
            {
                Console.WriteLine(Nrfe.Message);
            }
        }

        // To Add Feedback for a Solution
        public async Task EmployeeAddFeedback()
        {   
            await Console.Out.WriteLineAsync("Please enter remarks");
            string message = Console.ReadLine();
            //await Console.Out.WriteLineAsync("Please enter rating");
            float rating = (float)9.7;
            await Console.Out.WriteLineAsync("Please enter Employee id");
            int eid = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter Solution id");
            int sid = Convert.ToInt32(Console.ReadLine());
            SolutionFeedback feedback = new SolutionFeedback() { Remarks = message, Rating = rating, FeedbackBy = eid, SolutionId = sid };
            var resultadded = feedbackBL.Add(feedback);
            if (resultadded != null)
            {
                await Console.Out.WriteLineAsync($"Feedback Added : {resultadded.Result}");
            }
            else
            {
                Console.Out.WriteLine("Feedback Addition failed");
            }
        }

        // To update Solution for a Request (by Employee)

        public async Task EmployeeUpdateSolution()
        {
            try
            {
                Console.WriteLine("Enter your Employee ID :");
                int EmployeeID = Convert.ToInt32(Console.ReadLine());
                var employee = await employeeBL.GetRequestSolutionsByEmployeeID(EmployeeID);
                if (employee != null)
                {
                    {
                        Console.WriteLine($"{employee.Name}");
                        foreach (Request request in employee.RequestsRaised)
                        {
                            Console.WriteLine("-----------------------------------------------------");
                            Console.Out.WriteLine($"Request Description : {request.RequestMessage}");
                            Console.Out.WriteLine($"Request status : {request.RequestStatus}");
                            Console.WriteLine("Here we go with your solutions by Admin Team:");
                            int RequestID = request.RequestNumber;
                            var requets = await requestBL.GetAllRequests(RequestID);
                            if (requets != null)
                            {
                                foreach (RequestSolution solution in requets.RequestSolutions)
                                {
                                    Console.WriteLine("-----------------------------------------------------");
                                    Console.WriteLine(solution.SolutionDescription);
                                    Console.WriteLine("Need to Respond to the Solution?(Yes/No)");
                                    string Userinput = Console.ReadLine();
                                    if (Userinput == "Yes")
                                    {
                                        Console.WriteLine("Enter your comment for the solution:");
                                        string CommentMessage = Console.ReadLine();
                                        solution.RequestRaiserComment = CommentMessage;
                                        Console.WriteLine("Whether your solution is Solved? (Yes/No)");
                                        string Issolved = Console.ReadLine();
                                        if (Issolved == "Yes")
                                        {
                                            solution.IsSolved = true;
                                        }
                                        else
                                        {
                                            solution.IsSolved = false;
                                        }
                                        var updatedsolution = await requestSolutionBL.Update(solution);
                                        Console.WriteLine("Solution for your request Updated!");
                                    }
                                    Console.WriteLine("-----------------------------------------------------");
                                }
                            }
                            Console.WriteLine("-----------------------------------------------------");
                        }
                    }
                }
            }
            catch (NoRequestSolutionFoundException Nrsf)
            {
                Console.WriteLine(Nrsf.Message);
            }
        }

        // Admin

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
            var resultadded = await requestSolutionBL.Add(solution);
            if (resultadded != null)
            {
                await Console.Out.WriteLineAsync($"Request Added : {resultadded.SolutionId}");
            }
            else
            {
                Console.Out.WriteLine("Request adding failed!");
            }
        }
        public async Task GetAllEmployeesRequestSolutionByAdmin()
        {
            try
            {
                var result = await employeeBL.GetAllEmployees();
                foreach (Employee employee in result)
                {
                    Console.Out.WriteLine($"Employee Name : {employee.Name}");
                    if (employee.RequestsRaised.Count == 0)
                    {
                        Console.WriteLine($"There is no request raised by {employee.Name}");
                    }
                    else
                    {
                        foreach (Request request in employee.RequestsRaised)
                        {
                            Console.WriteLine("-----------------------------------------------------");
                            Console.Out.WriteLine($"Request Description : {request.RequestMessage}");
                            Console.Out.WriteLine($"Request status : {request.RequestStatus}");
                            Console.WriteLine("-----------------------------------------------------");
                            Console.WriteLine("Here we go with your solutions by Admin Team:");
                            int RequestID = request.RequestNumber;
                            var requets = await requestBL.GetAllRequests(RequestID);
                            if (requets != null)
                            {
                                foreach (RequestSolution solution in requets.RequestSolutions)
                                {
                                    Console.WriteLine("-----------------------------------------------------");
                                    Console.WriteLine(solution.SolutionDescription);
                                    Console.WriteLine("-----------------------------------------------------");
                                }
                            }
                        }
                    }

                }
            }
            catch (NoRequestFoundException Nrfe)
            {
                Console.Write(Nrfe.Message);
            }
            catch(NoEmployeeFoundException Nefe)
            {
                Console.Write(Nefe.Message);
            }
        }

        // To view feedback for their solutions
        public async Task ViewFeedbackByAdmin()
        {
            Console.WriteLine("Please Enter your Employee ID:");
            int Id = Convert.ToInt32(Console.ReadLine());
            var IResult = await requestSolutionBL.GetAllSolutions();
            foreach (RequestSolution solution in IResult)
            {
                if(solution.SolvedBy == Id)
                {
                    var resultsolutions = await requestSolutionBL.GetSolutionsWithFeedback(solution.SolutionId);
                    if (resultsolutions != null)
                    {
                        var result = await requestBL.GetRequestByID(resultsolutions.RequestId);
                        Console.WriteLine("Request Message that you had provided solution: ");
                        Console.WriteLine($"{result.RequestMessage}");
                        Console.WriteLine("Your Solution Message :");
                        Console.WriteLine($"{resultsolutions.SolutionDescription}");
                        Console.WriteLine("Feedback Provided by Employee Name :");
                        var employeeresult = await employeeBL.GetEmployeeByID(result.RequestRaisedBy);
                        Console.WriteLine($"{employeeresult.Name}");
                        Console.WriteLine("Feedbacks for your solution:");
                        if(resultsolutions.Feedbacks.Count > 0)
                        {
                            foreach (SolutionFeedback feedback in resultsolutions.Feedbacks)
                            {
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine($"{feedback.Remarks}");
                                Console.WriteLine($"{feedback.Rating}");
                                Console.WriteLine("------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("You have no Feedbacks for this Solution till yet!");
                            Console.WriteLine("------------------------------------------------");
                        }
                        
                    }
                }
            }
            
        }

        // To update the status of a Request

        public async Task UpdateRequestStatusByAdmin()
        {
            Console.WriteLine("Please Enter your Employee ID:");
            int Id = Convert.ToInt32(Console.ReadLine());
            var IResult = await requestSolutionBL.GetAllSolutions();
            foreach (RequestSolution solution in IResult)
            {
                if (solution.SolvedBy == Id)
                {
                    var resultsolutions = await requestSolutionBL.GetSolutionsWithFeedback(solution.SolutionId);
                    if (resultsolutions != null)
                    {
                        var result = await requestBL.GetRequestByID(resultsolutions.RequestId);
                        Console.WriteLine("Request Message that you had provided solution: ");
                        Console.WriteLine($"{result.RequestMessage}");
                        Console.WriteLine("Your Solution Message :");
                        Console.WriteLine($"{resultsolutions.SolutionDescription}");
                        Console.WriteLine("Request Provided Employee Name :");
                        var employeeresult = await employeeBL.GetEmployeeByID(result.RequestRaisedBy);
                        Console.WriteLine($"{employeeresult.Name}");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("Request Raiser Comment for your solution:");
                        Console.WriteLine($"{resultsolutions.RequestRaiserComment}");
                        Console.WriteLine("Request Raiser Comment and Feedbacks for your solution:");
                        if (resultsolutions.Feedbacks.Count > 0)
                        {
   
                            foreach (SolutionFeedback feedback in resultsolutions.Feedbacks)
                            { 
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine($"{feedback.Remarks}");
                                Console.WriteLine($"{feedback.Rating}");
                                Console.WriteLine("------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("You have no Feedbacks for this Solution till yet!");
                            Console.WriteLine("------------------------------------------------");
                        }

                        Console.WriteLine("Need to Update this Request as CLosed?(Yes/No)");
                        string Userinput = Console.ReadLine();
                        if (Userinput == "Yes")
                        {
                            result.ClosedDate = DateTime.Now;
                            result.RequestStatus = "Cosed";
                            result.RequestClosedBy = Id;
                            var Updatedresult = await requestBL.Update(result);
                            if(Updatedresult != null)
                            {
                                Console.WriteLine("Resquest Updated Successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Error in Updating Request!");
                            }
                        }

                    }
                    
                }
            }
        }


    }
}
