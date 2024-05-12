using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerFEApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("Hello, World!");

            EmployeeFrontend Employeefrontend = new EmployeeFrontend();
            //await Employeefrontend.EmployeeRegister();

            // Function Call to get Employee's Request and Solution(Both for Admin and User)
            await Employeefrontend.GetEmployeeRequestSolutionByEmployeeID();

            // Function Call to add Feedback for a solution(By both User and Admin)
            await Employeefrontend.EmployeeAddFeedback();

            // Function Call to Update solution-(by both User and Admin) for a request
            await Employeefrontend.EmployeeUpdateSolution();


            // Admin

            // Function call to add Solution for a request(By Admin)
            await Employeefrontend.AddSolution();

            // Function Call to View All Employees Request and Solution by Admin
            await Employeefrontend.GetAllEmployeesRequestSolutionByAdmin();

            // Function Call to view Feedbacks for a solution by Admin
            await Employeefrontend.ViewFeedbackByAdmin();

            // Function Call to Update Request Status by Admin
            await Employeefrontend.UpdateRequestStatusByAdmin();

            RequestFrontend Requestfrontend = new RequestFrontend();
            //Requestfrontend.AddRequest();


            RequestSolutionFrontend solutionFrontend = new RequestSolutionFrontend();
            //solutionFrontend.AddSolution();

            FeedBackFrontend solutionFeedback = new FeedBackFrontend();
            //solutionFeedback.AddFeedback();



            //await Employeefrontend.GetAllEmployees();

            


            //Request request = new Request() { RequestMessage = "Desktop", RequestRaisedBy = 107, RequestClosedBy = 107 };
            //IRequestServices RequestBL = new RequestBL();
            //var result = RequestBL.Add(request);
            //Console.WriteLine(result.Result.RequestNumber);


            //Employee employee = new Employee() { Name = "ragul", Password = "sa", Role = "Admin" };
            //IEmployeeService employeeBL = new EmployeeBL();
            //var result = await employeeBL.GetAllEmployees();
            //foreach (Employee employee in result)
            //{
            //    Console.Out.WriteLine($"{employee.Name}{employee.RequestsRaised.Count}");
            //}
            //var result = employeeBL.Register(employee);
            //Console.WriteLine(result.Result.Name);

        }
    }
}
