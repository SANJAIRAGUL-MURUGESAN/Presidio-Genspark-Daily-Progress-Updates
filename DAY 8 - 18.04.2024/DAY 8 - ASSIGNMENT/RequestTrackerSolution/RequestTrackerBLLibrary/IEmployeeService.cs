﻿using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee ChangeEmployeeName(string employeeOldName, string employeeNewName);
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByName(string departmentName);
        List<Employee> GetEmployeeList();
    }
}
