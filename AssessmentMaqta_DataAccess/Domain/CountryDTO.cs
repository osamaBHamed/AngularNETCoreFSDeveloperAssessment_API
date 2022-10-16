using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssessmentMaqta_DataAccess.Domain
{
    public class CountryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The Name Field is Required")]
        public string Name { get; set; }
    }
}
