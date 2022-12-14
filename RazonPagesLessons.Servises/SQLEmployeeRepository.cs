using Microsoft.EntityFrameworkCore;
using RazonPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazonPagesLessons.Servises
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public Employee Add(Employee newEmployee)
        {
            /*  _context.Employees.Add(newEmployee);
              _context.SaveChanges();*/
            _context.Database.ExecuteSqlRaw("spAddNewEmploee {0}, {1}, {2}, {3}",
                newEmployee.Name,
                newEmployee.Email,
                newEmployee.PhotoPath,
               newEmployee.Department);


            return newEmployee;
        }

        public Employee Delete(int Id)
        {
            var employeeToDelete = _context.Employees.Find(Id);
            if(employeeToDelete!=null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }
            return employeeToDelete;
        }

        public IEnumerable<DeptHeadCount> EmploeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = _context.Employees;
            if (dept.HasValue)
                query = query.Where(x => x.Department == dept.Value);

            return query.GroupBy(x => x.Department)
                .Select(x => new DeptHeadCount()

                {
                    Department = x.Key.Value,
                    Count = x.Count()
                }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            /* return _context.Employees;*/
            return _context.Employees
                 .FromSqlRaw<Employee>("Select * from Employees")
                 .ToList();
        }

        public Employee GetEmployee(int id)
        {
            /*return _context.Employees.Find(id);*/
            return _context.Employees
              .FromSqlRaw<Employee>("CodFirstSpGetEmployeeByID {0}", id)
              .ToList()
              .FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string searchTeam)
        {
            if (string.IsNullOrWhiteSpace(searchTeam))
                return _context.Employees;
            return _context.Employees.Where(x => x.Name.ToLower().Contains(searchTeam.ToLower()) || x.Email.ToLower().Contains(searchTeam.ToLower()));
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = _context.Employees.Attach(updatedEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedEmployee;

        }
    }
}
