using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class ArticleListViewModel
    {
        public IEnumerable<Article> allArticle { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }

        public List<string> articleTags;
    }
}
