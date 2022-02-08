using Blog.Data.Interfaces;
using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
