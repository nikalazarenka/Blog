using Blog.Data.Interfaces;
using Blog.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class TagRepository : ITags
    {
        private readonly AppDbContext appDbContext;
        public TagRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Tag> Tags => appDbContext.Tags;

        public List<Tag> getObjectTagsByArticleId(int? articleId)
        {
            return appDbContext.Articles
            .Where(article => article.Id == articleId)
            .SelectMany(article => article.Tags).ToList();
        }

        public Tag getObjectTag(int? id) => appDbContext.Tags.FirstOrDefault(p => p.Id == id);

        public void Create(string name)
        {
            Tag tag = new Tag { Name = name };
            appDbContext.Tags.Add(tag);
            appDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            Tag tag = appDbContext.Tags.FirstOrDefault(t => t.Id == id);
            if (tag != null)
            {
                appDbContext.Tags.Remove(tag);
                appDbContext.SaveChanges();
            }
        }

        public void Edit(Tag tag)
        {
            appDbContext.Tags.Update(tag);
            appDbContext.SaveChanges();
        }
    }
}
