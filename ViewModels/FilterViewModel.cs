using Blog.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class FilterViewModel
    {
        public SelectList Tags { get; set; }
        public int? SelectedTag { get; set; }

        public SelectList Dates { get; private set; }
        public int? SelectedDate { get; private set; }
        public SelectList Categories { get; private set; }
        public int? SelectedCategory { get; private set; }

        public FilterViewModel(List<Category> categories, int? category, List<Date> dates, int? date, List<Tag> tags, int? tag)
        {
            categories.Insert(0, new Category { Name = "All", Id = 0 });
            dates.Insert(0, new Date { Datetime = "All", Id = 0 });
            tags.Insert(0, new Tag { Name = "All", Id = 0 });

            Categories = new SelectList(categories, "Id", "Name", category);
            Dates = new SelectList(dates, "Id", "Datetime", date);
            Tags = new SelectList(tags, "Id", "Name", tag);
            
            SelectedCategory = category;
            SelectedDate = date;
            SelectedTag = tag;
        }

    }
}
