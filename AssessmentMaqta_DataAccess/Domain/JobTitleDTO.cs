using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssessmentMaqta_DataAccess.Domain
{
   public class JobTitleDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
