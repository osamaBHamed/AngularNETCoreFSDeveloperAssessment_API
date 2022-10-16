using AssessmentMaqta_DataAccess.Context;
using AssessmentMaqta_DataAccess.Domain;
using AssessmentMaqta_DataAccess.Entity;
using AssessmentMaqta_DataAccess.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentMaqta_BusinessLogic.SpecificRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IGeneric<Employee> generic;
        private readonly AssessmentContext context;
        private readonly ICountryRepository countryRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IJobTitleRepository jobTitleRepository;

        public EmployeeRepository(IGeneric<Employee> _generic, AssessmentContext _context,
            ICountryRepository _countryRepository,
            IDepartmentRepository _departmentRepository,
            IJobTitleRepository _jobTitleRepository
            )
        {
            generic = _generic;
            context = _context;
            countryRepository = _countryRepository;
            departmentRepository = _departmentRepository;
            jobTitleRepository = _jobTitleRepository;
        }

        public async Task<int> Insert(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee()
            {
                FName = employeeDTO.FName,
                LName = employeeDTO.LName,
                BDate = employeeDTO.BDate,
                Email = employeeDTO.Email,
                Gender = employeeDTO.Gender,
                PhoneNo = employeeDTO.PhoneNo,
                HireDate = employeeDTO.HireDate,
                Salary = employeeDTO.Salary,
                Status = employeeDTO.Status,
                Country_Id = employeeDTO.Country_Id,
                Department_Id = employeeDTO.Department_Id,
                JobTitle_Id = employeeDTO.JobTitle_Id
            };
            return await generic.Insert(newEmployee);
        }

        public async Task Update(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee()
            {
                Id = employeeDTO.Id,
                FName = employeeDTO.FName,
                LName = employeeDTO.LName,
                BDate = employeeDTO.BDate,
                Email = employeeDTO.Email,
                Gender = employeeDTO.Gender,
                PhoneNo = employeeDTO.PhoneNo,
                HireDate = employeeDTO.HireDate,
                Salary = employeeDTO.Salary,
                Status = employeeDTO.Status,
                Country_Id = employeeDTO.Country_Id,
                Department_Id = employeeDTO.Department_Id,
                JobTitle_Id = employeeDTO.JobTitle_Id

            };
            await generic.Update(newEmployee);
        }

        public async Task Delete(int Id)
        {
            await generic.delete(Id);
        }

        public async Task<EmployeeDTO> Load(int Id)
        {
            var employee = await generic.Load(Id);
            if (employee != null)
            {
                var employeeDetails = new EmployeeDTO()
                {
                    Id = employee.Id,
                    FName = employee.FName,
                    LName = employee.LName,
                    BDate = employee.BDate,
                    Email = employee.Email,
                    Gender = employee.Gender,
                    PhoneNo = employee.PhoneNo,
                    HireDate = employee.HireDate,
                    Salary = employee.Salary,
                    Status = employee.Status,
                    Country_Id = employee.Country_Id,
                    Department_Id = employee.Department_Id,
                    JobTitle_Id = employee.JobTitle_Id
                };
                return employeeDetails;
            }
            return null;
        }

        public async Task<List<EmployeeDTO>> SearchCriteria(string name, int? dept_Id=null)
        {
            var employees = new List<EmployeeDTO>();
            var allemployes = await context.employees.Where(e =>
              (string.IsNullOrEmpty(name) || e.FName.Contains(name) || e.LName.Contains(name))
              && (!dept_Id.HasValue || e.Department_Id == dept_Id.Value)
             ).ToListAsync();

            if (allemployes?.Any() == true)
            {
                foreach (var employee in allemployes)
                {
                    employees.Add(new EmployeeDTO()
                    {
                        Id = employee.Id,
                        FName = employee.FName,
                        LName = employee.LName,
                        BDate = employee.BDate,
                        Email = employee.Email,
                        Gender = employee.Gender,
                        PhoneNo = employee.PhoneNo,
                        HireDate = employee.HireDate,
                        Salary = employee.Salary,
                        Status = employee.Status,
                        Country_Id = employee.Country_Id,
                        Department_Id = employee.Department_Id,
                        JobTitle_Id = employee.JobTitle_Id,
                        country=await countryRepository.Load(employee.Country_Id),
                        department=await departmentRepository.Load(employee.Department_Id),
                        jobTitle= await jobTitleRepository.Load(employee.JobTitle_Id)

                    });
                }
            }

            return employees;
        }

        public async Task<List<EmployeeDTO>> LoadAll()
        {
            var employees = new List<EmployeeDTO>();
            var allemployees = await generic.LoadAll();
            if (allemployees?.Any() == true)
            {
                foreach (var employee in allemployees)
                {
                    employees.Add(new EmployeeDTO()
                    {
                        Id = employee.Id,
                        FName = employee.FName,
                        LName = employee.LName,
                        BDate = employee.BDate,
                        Email = employee.Email,
                        Gender = employee.Gender,
                        PhoneNo = employee.PhoneNo,
                        HireDate = employee.HireDate,
                        Salary = employee.Salary,
                        Status = employee.Status,
                        Country_Id = employee.Country_Id,
                        Department_Id = employee.Department_Id,
                        JobTitle_Id = employee.JobTitle_Id,
                        country = await countryRepository.Load(employee.Country_Id),
                        department = await departmentRepository.Load(employee.Department_Id),
                        jobTitle = await jobTitleRepository.Load(employee.JobTitle_Id)
                    });
                }
            }
            return employees;
        }
    }
}
