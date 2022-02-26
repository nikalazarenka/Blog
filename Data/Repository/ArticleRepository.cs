using Blog.Data.Interfaces;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public void Create(string name, string shortDescription, string description, string Image, int category, int tag)
        {
            Date date = new Date
            {
                Datetime = DateTime.Now.ToString()
            };

            appDbContext.Dates.Add(date);
            appDbContext.SaveChanges();

            Article article = new Article
            {
                Name = name,
                ShortDescription = shortDescription,
                Description = description,
                Image = Image,
                Date = date,
                DateId = date.Id,
                Category = appDbContext.Categories.FirstOrDefault(c=>c.Id==category),
                CategoryId = category,
                Tags = appDbContext.Tags.Where(t=>t.Id==tag).ToList()
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

        public void Edit(int id, string name, string shortDescription, string description, string image, int category, int tag)
        {
            Article article = getObjectArticle(id);
            article.Name = name;
            article.ShortDescription = shortDescription;
            article.Description = description;
            article.Image = image;
            article.Category = appDbContext.Categories.FirstOrDefault(c => c.Id == category);
            article.CategoryId = category;
            article.Tags = appDbContext.Tags.Where(t => t.Id == tag).ToList();

            appDbContext.Articles.Update(article);
            appDbContext.SaveChanges();
        }

        public Article getObjectArticle(int? articleId) => appDbContext.Articles.FirstOrDefault(a => a.Id == articleId);
    }
}
