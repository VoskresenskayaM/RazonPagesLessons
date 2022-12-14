using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazonPagesLessons.Models
{
   public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The name field cannot be null! Please, write the name")]
      
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please, enter a valid email(format: es@mail.com)")]
        public string Email { get; set; }

        public string PhotoPath { get; set; }

        public Dept? Department { get; set; }
    }
}
