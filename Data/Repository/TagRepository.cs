using Blog.Data.Interfaces;
using Blog.Data.Models;
using System.Collections.Generic;

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
    }
}
