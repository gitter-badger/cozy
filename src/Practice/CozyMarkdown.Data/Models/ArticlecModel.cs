﻿using System;

namespace CozyMarkdown.Data.Models {

    public class ArticlecModel : IEntityModel {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
