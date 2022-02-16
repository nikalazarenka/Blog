using System.Collections.Generic;

namespace Blog.Data.Models
{
    public class Date
    {
        public int Id { get; set; }
        public string Datetime { get; set; }
        public List<Article> Articles { get; set; }
    }
}
