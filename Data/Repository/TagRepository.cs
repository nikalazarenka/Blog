using Blog.Data.Interfaces;
using Blog.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repository
{
    public class TagRepository : IArticleTags
    {
        private readonly AppDbContext appDbContext;
        public TagRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Tag> AllTags => appDbContext.Tags;

        public List<Tag> getObjectTags(int articleId)
        {
            return appDbContext.Articles
            .Where(article => article.Id == articleId)
            .SelectMany(article => article.Tags).ToList();
        }
    }
}
