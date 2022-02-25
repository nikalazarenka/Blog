using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class CreateOrEditArticleViewModel
    {
        //[Required]
        //public string Name { get; set; }

        //[Required]
        //public string ShortDescription { get; set; }

        //[Required]
        //public string Description { get; set; }

        //[Required]
        //public string Image { get; set; }

        //[Required]
        //public Category Category { get; set; }

        //public List<Tag> Tags { get; set; }

        public Article Article { get; set; }

        public SelectViewModel SelectViewModel { get; set; }

    }
}
