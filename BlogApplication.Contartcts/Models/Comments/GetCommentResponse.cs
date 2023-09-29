﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Contracts.Models.Comments
{
    public class GetCommentResponse
    {
        public int CommentAmount { get; set; }
        public CommentViewModel[] commentView { get; set; }
    }
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
