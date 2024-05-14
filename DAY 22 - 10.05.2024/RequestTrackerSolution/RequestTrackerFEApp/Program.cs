using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerFEApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            EmployeeFrontend Employeefrontend = new EmployeeFrontend();
            Console.WriteLine("1. Register ");
            Console.WriteLine("2. Login");
            Console.WriteLine("Enter Your Option:");

            int UserInput = Convert.ToInt32(Console.ReadLine());
            string UserType = string.Empty;
            switch (UserInput)
            {
                case 1:
                    await Employeefrontend.EmployeeRegister();
                    break;
                case 2:
                    UserType = await Employeefrontend.EmployeeLogin();
                    break;
            }

            Console.WriteLine($"{UserType}");

            if(UserType == "User")
            {
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. Get All Request and Solution");
                Console.WriteLine("3. Add Feedback for a Solution");
                Console.WriteLine("4. Update Solution");
                bool value = true;
                while (value)
                {
                    Console.WriteLine("Enter your Choice:");
                    int UserChoice = Convert.ToInt32(Console.ReadLine());
                    switch (UserChoice)
                    {
                        case 1:
                            await Employeefrontend.AddRequest();
                            break;
                        case 2:
                            await Employeefrontend.GetEmployeeRequestSolutionByEmployeeID();
                            break;
                        case 3:
                            await Employeefrontend.EmployeeAddFeedback();
                            break;
                        case 4:
                            await Employeefrontend.EmployeeUpdateSolution();
                            break;
                        default:
                            value = false;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. Get All Request and Solution of Admin");
                Console.WriteLine("3. Add Feedback for a Solution of Admin");
                Console.WriteLine("4. Update Solution of Admin");
                Console.WriteLine("5. Get All Request and Solution");
                Console.WriteLine("6. To View Feedbacks of your solution");
                Console.WriteLine("7. Add solution for a Request");
                Console.WriteLine("8. Update Request status by Admin");
                bool value = true;
                while (value)
                {
                    Console.WriteLine("Enter your Choice:");
                    int UserChoice = Convert.ToInt32(Console.ReadLine());
                    switch (UserChoice)
                    {
                        case 1:
                            await Employeefrontend.AddRequest();
                            break;
                        case 2:
                            await Employeefrontend.GetEmployeeRequestSolutionByEmployeeID();
                            break;
                        case 3:
                            await Employeefrontend.EmployeeAddFeedback();
                            break;
                        case 4:
                            await Employeefrontend.EmployeeUpdateSolution();
                            break;
                        case 5:
                            await Employeefrontend.GetAllEmployeesRequestSolutionByAdmin();
                            break;
                        case 6:
                            await Employeefrontend.ViewFeedbackByAdmin();
                            break;
                        case 7:
                            await Employeefrontend.AddSolution();
                            break;
                        case 8:
                            await Employeefrontend.UpdateRequestStatusByAdmin();
                            break;
                        default:
                            value = false;
                            break;
                    }
                }
            }

            
            //await Employeefrontend.EmployeeRegister();

            // Function Call to get Employee's Request and Solution(Both for Admin and User)
            //await Employeefrontend.GetEmployeeRequestSolutionByEmployeeID();

            // Function Call to add Feedback for a solution(By both User and Admin)
            //await Employeefrontend.EmployeeAddFeedback();

            // Function Call to Update solution-(by both User and Admin) for a request
            //await Employeefrontend.EmployeeUpdateSolution();


            // Admin

            // Function call to add Solution for a request(By Admin)
            //await Employeefrontend.AddSolution();

            // Function Call to View All Employees Request and Solution by Admin
            //await Employeefrontend.GetAllEmployeesRequestSolutionByAdmin();

            // Function Call to view Feedbacks for a solution by Admin
            //await Employeefrontend.ViewFeedbackByAdmin();

            // Function Call to Update Request Status by Admin
            //await Employeefrontend.UpdateRequestStatusByAdmin();

            //RequestFrontend Requestfrontend = new RequestFrontend();
            //Requestfrontend.AddRequest();


            //RequestSolutionFrontend solutionFrontend = new RequestSolutionFrontend();
            //solutionFrontend.AddSolution();

            //FeedBackFrontend solutionFeedback = new FeedBackFrontend();
            //solutionFeedback.AddFeedback();



            //await Employeefrontend.GetAllEmployees();

        }
    }
}
