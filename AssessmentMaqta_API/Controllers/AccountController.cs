using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AssessmentMaqta_BusinessLogic.SpecificRepository;
using AssessmentMaqta_DataAccess.Domain;
using AssessmentMaqta_DataAccess.Application;
using AssessmentMaqta_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace AssessmentMaqta_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly IConfiguration configuration;

        public AccountController(IAccountRepository _accountRepository, IConfiguration _configuration)
        {
            accountRepository = _accountRepository;
            configuration = _configuration;
        }

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccount(SignUpDTO signUp)
        {
            try
            {
                IdentityResult result = await accountRepository.CreateAccount(signUp);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, null);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Faild to create user" });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(RoleDTO roleModel)
        {
            try
            {
                var result = await accountRepository.AddRole(roleModel);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, null);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Faild to add Role" });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<ApplicationUser> li = await accountRepository.getUsers();
                return StatusCode(StatusCodes.Status200OK, li);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
            
        }

        [HttpGet]
        [Route("UserRoles")]
        public async Task<IActionResult> UserRoles(string UserId)
        {
            try
            {
                List<UserRoles> liUserRoles = await accountRepository.getRoles(UserId);
                //return liUserRoles;
                return StatusCode(StatusCodes.Status200OK, liUserRoles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(List<UserRoles> liuserRole)
        {
            try
            {
                await accountRepository.UpdateUserRole(liuserRole);
                List<UserRoles> liUserRoles = await accountRepository.getRoles(liuserRole[0].UserId);
                return StatusCode(StatusCodes.Status200OK, null);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(SignInDTO signInModel)
        {
            try
            {
                var result = await accountRepository.SignIn(signInModel);
                if (result.Succeeded)
                {

                    var authClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, signInModel.Username),
                    new Claim("UniqueValue", Guid.NewGuid().ToString())
                };

                    var user = await accountRepository.getUser(signInModel.Username);

                    var roles = accountRepository.getUserRoles(user);

                    foreach (var item in roles)
                    {
                        authClaim.Add(new Claim(ClaimTypes.Role, item));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                                issuer: configuration["JWT:ValidIssuer"],
                                audience: configuration["JWT:ValidAudience"],
                                expires: DateTime.Now.AddDays(15),
                                claims: authClaim,
                                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                                );

                    return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }


    }
}
