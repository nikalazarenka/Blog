using Blog.Data.Interfaces;
using Blog.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repository
{
    public class CategoryRepository : ICategories
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Category> Categories => appDbContext.Categories;

        public Category getObjectCategory(int? categoryId) => appDbContext.Categories.FirstOrDefault(p => p.Id == categoryId);

        public void Create(string name)
        {
            Category category = new Category { Name = name };
            appDbContext.Categories.Add(category);
            appDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            Category category = appDbContext.Categories.FirstOrDefault(t => t.Id == id);
            if (category != null)
            {
                appDbContext.Categories.Remove(category);
                appDbContext.SaveChanges();
            }
        }

        public void Edit(Category category)
        {
            appDbContext.Categories.Update(category);
            appDbContext.SaveChanges();
        }
    }
}
