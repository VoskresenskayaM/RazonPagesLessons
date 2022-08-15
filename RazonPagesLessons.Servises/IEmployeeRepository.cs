using RazonPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazonPagesLessons.Servises
{
   public  interface IEmployeeRepository
    {
        IEnumerable<Employee> Search(string searchTeam);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee updatedEmployee);

        Employee Add(Employee newEmployee);
        Employee Delete(int Id);
        IEnumerable<DeptHeadCount> EmploeeCountByDept(Dept? dept);



    }
}
