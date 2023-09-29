﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Contracts.Models.Articles
{
    public class EditArticleRequest
    {
        public Guid Id { get; set; }
        public string NewArticleName { get; set; }
        public string NewArticleContext { get; set; }
    }
}
