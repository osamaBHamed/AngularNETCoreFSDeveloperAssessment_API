using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentMaqta_DataAccess.Domain
{
    public class RoleDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
