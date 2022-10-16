using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssessmentMaqta_DataAccess.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FName { get; set; }

        [Required]
        [StringLength(50)]
        public string LName { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNo { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BDate { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        [ForeignKey("country")]
        public int Country_Id { get; set; }
        [ForeignKey("department")]
        public int Department_Id { get; set; }
        [ForeignKey("jobTitle")]
        public int JobTitle_Id { get; set; }
        public Department department { get; set; }
        public Country country { get; set; }
        public JobTitle jobTitle { get; set; }
    }
}
