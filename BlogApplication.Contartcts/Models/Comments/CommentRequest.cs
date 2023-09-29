using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Contracts.Models.Comments
{
    public class CommentRequest
    {
        public Guid Id { get; set; }
        public string CommentContext { get; set; }
    }
}
