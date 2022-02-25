using Blog.Data.Interfaces;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repository
{
    public class ArticleRepository : IArticles
    {
        private readonly AppDbContext appDbContext;
        public ArticleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Article> Articles => appDbContext.Articles.Include(c => c.Category);

        public void Create(string name, string shortDescription, string description, string Image, Date date, Category category, List<Tag> tags)
        {
            Article article = new Article
            {
                Name = name,
                ShortDescription = shortDescription,
                Description = description,
                Image = Image,
                Date = date,
                DateId = date.Id,
                Category = category,
                CategoryId = category.Id,
                Tags = tags
            };

            appDbContext.Articles.Add(article);
            appDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            Article article = appDbContext.Articles.FirstOrDefault(a => a.Id == id);
            if (article != null)
            {
                appDbContext.Articles.Remove(article);
                appDbContext.SaveChanges();
            }
        }

        public void Edit(Article article)
        {
            appDbContext.Articles.Update(article);
            appDbContext.SaveChanges();
        }

        public Article getObjectArticle(int? articleId) => appDbContext.Articles.FirstOrDefault(a => a.Id == articleId);
    }
}
