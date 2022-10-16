using AssessmentMaqta_API.Models;
using AssessmentMaqta_BusinessLogic.SpecificRepository;
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
    
    public class JobTitleController : ControllerBase
    {
        private readonly IJobTitleRepository jobTitleRepository;

        public JobTitleController(IJobTitleRepository _jobTitleRepository)
        {
            jobTitleRepository = _jobTitleRepository;
        }

        [HttpGet]
        [Route("LoadAll")]
        public async Task<IActionResult> LoadAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await jobTitleRepository.LoadAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }
    }
}
