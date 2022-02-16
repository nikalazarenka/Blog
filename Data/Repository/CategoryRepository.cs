using Blog.Data.Interfaces;
using Blog.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repository
{
    public class CategoryRepository : IArticleCategory
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Category> AllCategories => appDbContext.Categories;

        public Category getObjectCategory(int categoryId) => appDbContext.Categories.FirstOrDefault(p => p.Id == categoryId);
    }
}
