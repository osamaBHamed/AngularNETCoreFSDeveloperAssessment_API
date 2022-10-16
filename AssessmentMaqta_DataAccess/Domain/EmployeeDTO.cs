using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssessmentMaqta_DataAccess.Domain
{
   public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public string Email { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BDate { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public int Country_Id { get; set; }
        public int Department_Id { get; set; }
        public int JobTitle_Id { get; set; }

        public CountryDTO country { get; set; }
        public DepartmentDTO department { get; set; }
        public JobTitleDTO jobTitle { get; set; }
    }
}
