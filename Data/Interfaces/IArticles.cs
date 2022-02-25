using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface IArticles
    {
        IEnumerable<Article> Articles { get; }
        Article getObjectArticle(int? articleId);

        public void Create(string name, string shortDescription, string description, string Image, Date date, Category category, List<Tag> tags);
        public void Delete(int? id);
        public void Edit(Article article);
    }
}
