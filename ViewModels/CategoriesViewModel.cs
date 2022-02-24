using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class CategoriesViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
