using Blog.Data.Interfaces;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class ArticleRepository : IAllArticle
    {
        private readonly AppDbContext appDbContext;
        public ArticleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Article> Articles => appDbContext.Articles.Include(c => c.Category);

        public Article getObjectArticle(int articleId) => appDbContext.Articles.FirstOrDefault(p => p.Id == articleId);
    }
}
