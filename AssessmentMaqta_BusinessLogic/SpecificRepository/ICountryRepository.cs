using AssessmentMaqta_DataAccess.Domain;
using AssessmentMaqta_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentMaqta_BusinessLogic.SpecificRepository
{
    public interface ICountryRepository
    {
        Task<List<CountryDTO>> LoadAll();
        Task<CountryDTO> Load(int Id);
    }
}
