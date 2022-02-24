using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> Categories { get; }
        Category getObjectCategory(int? categoryId);
        public void Create(string name);
        public void Delete(int? id);
        public void Edit(Category category);
    }
}
