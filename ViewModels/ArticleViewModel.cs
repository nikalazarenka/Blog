using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class ArticleViewModel
    {
        public Article Article { get; set; }
        public Category Category { get; set; }
        public Date Date { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
