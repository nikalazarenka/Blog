using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface IArticles
    {
        IEnumerable<Article> Articles { get; }
        Article getObjectArticle(int? articleId);

        public void Create(string name, string shortDescription, string description, string Image, int category, int tag);
        public void Delete(int? id);
        public void Edit(int id, string name, string shortDescription, string description, string image, int category, int tag);
    }
}
