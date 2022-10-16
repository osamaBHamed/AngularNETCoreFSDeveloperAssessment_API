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
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly IGeneric<Department> generic;

        public DepartmentRepository(IGeneric<Department> _generic)
        {
            generic = _generic;
        }
        public async Task<List<DepartmentDTO>> LoadAll()
        {

            var departments = new List<DepartmentDTO>();
            var alldepartments = await generic.LoadAll();
            if (alldepartments?.Any() == true)
            {
                foreach (var department in alldepartments)
                {
                    departments.Add(new DepartmentDTO()
                    {
                        Id = department.Id,
                        Name = department.Name
                    });
                }
            }
            return departments;

        }

        public async Task<DepartmentDTO> Load(int Id)
        {
            var department = await generic.Load(Id);
            if (department != null)
            {
                var departmentDetails = new DepartmentDTO()
                {
                    Id = department.Id,
                    Name = department.Name
                };
                return departmentDetails;
            }
            return null;
        }
    }
}
