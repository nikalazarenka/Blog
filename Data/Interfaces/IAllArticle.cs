using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface IAllArticle
    {
        IEnumerable<Article> Articles { get; }
        Article getObjectArticle(int articleId);
    }
}
