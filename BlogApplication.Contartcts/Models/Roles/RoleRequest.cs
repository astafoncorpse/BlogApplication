using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Contracts.Models.Roles
{
    public class RoleReqest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
