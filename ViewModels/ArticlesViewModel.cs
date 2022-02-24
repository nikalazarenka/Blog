using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class ArticlesViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
