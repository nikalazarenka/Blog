using Blog.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class CreateOrEditArticleViewModel
    {
        public int Id { get; set; }
        public Date Date { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public Category Category { get; set; }

        public List<Tag> Tags { get; set; }

        public ArticlesViewModel ArticlesViewModel { get; set; }
    }
}
