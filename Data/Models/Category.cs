using System.Collections.Generic;

namespace Blog.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}
