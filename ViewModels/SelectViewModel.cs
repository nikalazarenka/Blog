using Blog.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class SelectViewModel
    {
        public SelectList Categories { get; set; }
        public int? SelectedCategory { get; set; }

        public SelectList Tags { get; set; }
        public int? SelectedTag { get; set; }

        public SelectViewModel(List<Category> categories, int? category, List<Tag> tags, int? tag)
        {
            Categories = new SelectList(categories, "Id", "Name", category);
            SelectedCategory = category;

            Tags = new SelectList(tags, "Id", "Name", tag);
            SelectedTag = tag;
        }
    }
}
