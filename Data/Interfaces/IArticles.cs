using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface IArticles
    {
        IEnumerable<Article> Articles { get; }
        Article getObjectArticle(int? articleId);
    }
}
