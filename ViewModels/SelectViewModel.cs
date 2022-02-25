using Blog.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class SelectViewModel
    {
        public SelectList Categories { get; set; }
        public int? SelectedCategory { get; set; }

        public List<SelectListItem> Tags { get; set; }
        public List<int?> TagIds { get; set; }

        public SelectViewModel(List<Category> categories, int? category, List<Tag> tags)
        {
            Categories = new SelectList(categories, "Id", "Name", category);
            SelectedCategory = category;

            Tags = new List<SelectListItem>();
            TagIds = new List<int?>();

            foreach (var tag in tags)
            {
                Tags.Add(new SelectListItem { Text = tag.Name, Value = tag.Id.ToString() });
                TagIds.Add(tag.Id);
            }
        }
    }
}
