using Blog.Data.Interfaces;
using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class PublicationRepository : IAllPublications
    {
        private readonly AppDbContext appDbContext;
        public PublicationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Publication> Publications => appDbContext.Publications;

        public void createPublication(Publication publication, Article article)
        {
            publication.PublicationDate = DateTime.Now;
            publication.ArticleId = article.Id;
            appDbContext.Publications.Add(publication);
            appDbContext.SaveChanges();
        }
    }
}
