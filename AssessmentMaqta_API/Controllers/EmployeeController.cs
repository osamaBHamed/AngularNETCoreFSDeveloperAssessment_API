using AssessmentMaqta_API.Models;
using AssessmentMaqta_BusinessLogic.SpecificRepository;
using AssessmentMaqta_DataAccess.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentMaqta_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        [HttpGet]
        [Route("Load")]
        public async Task<IActionResult> Load(int Id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await employeeRepository.Load(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }

        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(EmployeeDTO employeeDTO)
        {
            try
            {
                int Id = await employeeRepository.Insert(employeeDTO);
                if (Id != 0)
                {
                    return StatusCode(StatusCodes.Status200OK, null);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Faild to add Employee" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(EmployeeDTO employeeDTO)
        {
            try
            {
                await employeeRepository.Update(employeeDTO);
                return StatusCode(StatusCodes.Status200OK, null);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await employeeRepository.Delete(Id);
                return StatusCode(StatusCodes.Status200OK, null);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }

        }

        [HttpGet]
        [Route("SearchCriteria")]
        public async Task<IActionResult> SearchCriteria(string name, int? dept_Id = null)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await employeeRepository.SearchCriteria(name, dept_Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("LoadAll")]
        public async Task<IActionResult> LoadAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await employeeRepository.LoadAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
    }
}
