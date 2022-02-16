using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface IArticleCategory
    {
        IEnumerable<Category> AllCategories { get; }
        Category getObjectCategory(int categoryId);

    }
}
