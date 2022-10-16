using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentMaqta_DataAccess.Domain
{
    public class UserRoles
    {
        public string RoleName { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public bool IsSelected { get; set; }
    }
}
