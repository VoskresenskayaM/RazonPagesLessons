using Microsoft.AspNetCore.Mvc;
using RazonPagesLessons.Models;
using RazonPagesLessons.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazonPagesGeneral.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IViewComponentResult Invoke(Dept? department = null)
        {
            var result = _employeeRepository.EmploeeCountByDept(department);
            return View(result);
        }


     
    }
}
