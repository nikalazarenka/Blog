using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int DateId { get; set; }
        public virtual Date Date { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<Tag> Tags { get; set; } = new();
    }
}
