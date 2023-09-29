﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.Data.Queries
{
    /// <summary>
    /// Класс для обновления статьи
    /// </summary>
    public class UpdateArticleQuery
    {
        public string NewContent { get; } = string.Empty;
        public string NewName { get; } = string.Empty;

        public UpdateArticleQuery(string newContent, string newName)
        {
            NewContent = newContent;
            NewName = newName;
        }
    }
}
