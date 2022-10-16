
using AssessmentMaqta_DataAccess.Application;
using AssessmentMaqta_DataAccess.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentMaqta_BusinessLogic.SpecificRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateAccount(SignUpDTO signUp);

        Task<SignInResult> SignIn(SignInDTO signInModel);

        Task<IdentityResult> AddRole(RoleDTO roleModel);

        Task<List<ApplicationUser>> getUsers();

        Task<List<UserRoles>> getRoles(string UserId);

        Task UpdateUserRole(List<UserRoles> liUserRole);

        

        List<string> getUserRoles(ApplicationUser obj);

        Task<ApplicationUser> getUser(string username);
    }
}
