using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssessmentMaqta_DataAccess.Entity
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Employee> liEmployee { get; set; }
    }
}
