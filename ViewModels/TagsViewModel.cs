using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class TagsViewModel
    {
        public IEnumerable<Tag> Tags { get; set; }
    }
}
