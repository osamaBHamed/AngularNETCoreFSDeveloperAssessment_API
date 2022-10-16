using AssessmentMaqta_DataAccess.Domain;
using AssessmentMaqta_DataAccess.Entity;
using AssessmentMaqta_DataAccess.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentMaqta_BusinessLogic.SpecificRepository
{
    public class CountryRepository:ICountryRepository
    {
        private readonly IGeneric<Country> generic;

        public CountryRepository(IGeneric<Country> _generic)
        {
            generic = _generic;
        }
        public async Task<List<CountryDTO>> LoadAll()
        {
            var countries = new List<CountryDTO>();
            var allCountries= await generic.LoadAll();
            if (allCountries?.Any() == true)
            {
                foreach (var country in allCountries)
                {
                    countries.Add(new CountryDTO()
                    {
                        Id=country.Id,
                        Name=country.Name
                    });
                }
            }
            return countries;
        }

        public async Task<CountryDTO> Load(int Id)
        {
            var country = await generic.Load(Id);
            if (country != null)
            {
                var countryDetails = new CountryDTO()
                {
                    Id = country.Id,
                    Name = country.Name
                };
                return countryDetails;
            }
            return null;
        }
    }
}
