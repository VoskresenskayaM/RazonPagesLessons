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
    public class DetalsModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public DetalsModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public  Employee Employee  { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();

        }
    }
}
