using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class ArticleListViewModel
    {
        public IEnumerable<Article> allArticle { get; set; }
        public string articleCategory;
        public List<string> articleTags;
    }
}
