using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Article> allArticles { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
