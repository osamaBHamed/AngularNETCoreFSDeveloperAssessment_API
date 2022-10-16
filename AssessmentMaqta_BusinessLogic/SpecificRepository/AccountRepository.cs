using AssessmentMaqta_DataAccess.Domain;
using AssessmentMaqta_DataAccess.Application;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssessmentMaqta_BusinessLogic.SpecificRepository
{
    public class AccountRepository:IAccountRepository
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public AccountRepository(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public async Task<IdentityResult> CreateAccount(SignUpDTO signUp)
        {
            var newUser = new ApplicationUser()
            {
                UserName = signUp.Username,
                Email = signUp.Email,
                Name = signUp.Name
            };
            var result = await userManager.CreateAsync(newUser, signUp.Password);
            return result;
        }

        public async Task<SignInResult> SignIn(SignInDTO signInModel)
        {
            var result = await signInManager.PasswordSignInAsync(signInModel.Username, signInModel.Password, false, false);
            return result;
        }

        public async Task<IdentityResult> AddRole(RoleDTO roleModel)
        {
            var newRole = new IdentityRole()
            {
                Name=roleModel.Name
            };

            var result = await roleManager.CreateAsync(newRole);
            return result;

        }

        public async Task<List<ApplicationUser>> getUsers()
        {
            return await userManager.Users.ToListAsync();
        }


        public async Task<List<UserRoles>> getRoles(string Userid)
        {
            
            List<IdentityRole> allRoles = roleManager.Roles.ToList();
            var liUserRoles = new List<UserRoles>();
            if (allRoles?.Any() == true)
            {
                foreach (var role in allRoles)
                {
                    liUserRoles.Add(new UserRoles()
                    {
                        RoleId = role.Id,
                        RoleName = role.Name,
                        UserId = Userid,
                        IsSelected = false
                    });
                }
            }
            if (liUserRoles?.Any() == true)
            {
                foreach (var uR in liUserRoles)
                {
                    var user = await userManager.FindByIdAsync(uR.UserId);
                    var Roles = await userManager.GetRolesAsync(user);
                    foreach (string r in Roles)
                    {
                        if (r == uR.RoleName)
                        {
                            uR.IsSelected = true;
                        }
                    }
                }
            }

            return liUserRoles;
        }


        public async Task UpdateUserRole(List<UserRoles> liUserRole)
        {
            foreach (UserRoles item in liUserRole)
            {
                var user = await userManager.FindByIdAsync(item.UserId);
                if (item.IsSelected == true)
                {
                    if (await userManager.IsInRoleAsync(user, item.RoleName) == false)
                    {
                        await userManager.AddToRoleAsync(user, item.RoleName);
                    }
                }
                else
                {
                    if (await userManager.IsInRoleAsync(user, item.RoleName) == true)
                    {
                        await userManager.RemoveFromRoleAsync(user, item.RoleName);
                    }
                }



            }
        }


        public List<string> getUserRoles(ApplicationUser obj)
        {
            List<string> li = userManager.GetRolesAsync(obj).Result.ToList();
            return li;
        }

        public async Task<ApplicationUser> getUser(string username)
        {
            var result = await userManager.FindByNameAsync(username);
            return result;
        }

    }
}
