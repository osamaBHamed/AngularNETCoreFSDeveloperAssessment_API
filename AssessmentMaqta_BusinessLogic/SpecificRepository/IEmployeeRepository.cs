using AssessmentMaqta_DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentMaqta_BusinessLogic.SpecificRepository
{
    public interface IEmployeeRepository
    {
        Task<int> Insert(EmployeeDTO employeeDTO);
        Task Update(EmployeeDTO employeeDTO);
        Task Delete(int Id);
        Task<EmployeeDTO> Load(int Id);
        Task<List<EmployeeDTO>> SearchCriteria(string name, int? dept_Id = null);
        Task<List<EmployeeDTO>> LoadAll();
    }
}
