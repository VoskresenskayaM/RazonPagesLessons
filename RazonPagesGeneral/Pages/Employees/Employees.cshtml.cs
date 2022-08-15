using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazonPagesLessons.Models;
using RazonPagesLessons.Servises;

namespace RazonPagesGeneral.Pages.Employees
{
    public class EmployeesModel : PageModel
    {

        private readonly IEmployeeRepository _db;
        public EmployeesModel (IEmployeeRepository  db)
        {
            _db = db;
        }

        public IEnumerable<Employee> Employees { get; set; }
       [BindProperty(SupportsGet =true)]
        public string SeachTerm { get; set; }
        public void OnGet()
        {
            Employees = _db.Search(SeachTerm);
        }
    }
}
