using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Contracts.Models.Uesrs
{
    public class EditUserRequest
    {
        public Guid Id { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public string NewEmail { get; set; }
        public string NewPassword { get; set; }
        public string NewLogin { get; set; }
    }
}
