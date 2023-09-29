using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Contracts.Models.Articles
{
    public class GetArticlesResponse
    {
        public int ArticleAmont { get; set; }
        public ArticleViewModel[] articleViews { get; set; }

    }

    public class ArticleViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
