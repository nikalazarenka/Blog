using Blog.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class TagsViewModel
    {
        public IEnumerable<Tag> Tags { get; set; }
    }
}
