using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Contracts.Models.Tegs
{
    public class EditTegRequest
    {
        public Guid Id { get; set; }
        public string NewValue { get; set; }
    }
}
