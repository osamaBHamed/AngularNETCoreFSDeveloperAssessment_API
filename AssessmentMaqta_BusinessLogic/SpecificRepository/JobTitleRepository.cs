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
    public class JobTitleRepository:IJobTitleRepository
    {
        private readonly IGeneric<JobTitle> generic;

        public JobTitleRepository(IGeneric<JobTitle> _generic)
        {
            generic = _generic;
        }
        public async Task<List<JobTitleDTO>> LoadAll()
        {
            var jobTitles = new List<JobTitleDTO>();
            var alljobTitles = await generic.LoadAll();
            if (alljobTitles?.Any() == true)
            {
                foreach (var jobTitle in alljobTitles)
                {
                    jobTitles.Add(new JobTitleDTO()
                    {
                        Id = jobTitle.Id,
                        Name = jobTitle.Name
                    });
                }
            }
            return jobTitles;
        }

        public async Task<JobTitleDTO> Load(int Id)
        {
            var jobTitle = await generic.Load(Id);
            if (jobTitle != null)
            {
                var jobTitleDetails = new JobTitleDTO()
                {
                    Id = jobTitle.Id,
                    Name = jobTitle.Name
                };
                return jobTitleDetails;
            }
            return null;
        }
    }
}
