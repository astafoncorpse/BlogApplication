using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Contracts.Models.Tegs
{
    public class GetTegResponse
    {
        public int TegAmount { get; set; }
        public TegViewModel[] TegView { get; set; }
    }
    public class TegViewModel
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
