using AssessmentMaqta_DataAccess.Domain;
using AssessmentMaqta_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentMaqta_BusinessLogic.SpecificRepository
{
    public interface IJobTitleRepository
    {
       Task<List<JobTitleDTO>> LoadAll();
        Task<JobTitleDTO> Load(int Id);
    }
}
