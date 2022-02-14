using Blog.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class FilterViewModel
    {
        //public IEnumerable<Article> Articles { get; set; }

        //public SelectList Dates { get; private set; }
        //public int? SelectedDate { get; private set; }
        public SelectList Categories { get; private set; }
        public int? SelectedCategory { get; private set; }

        public SelectList Dates { get; private set; }
        public int? SelectedDate { get; private set; }

        public FilterViewModel(List<Category> categories, int? category, List<DateTime> dates, int? date)
        {
            categories.Insert(0, new Category { Name = "All", Id = 0 });
            dates.Insert(0, DateTime.Now);
            Dates = new SelectList(dates, "Id", "Date", date);
            SelectedDate = date;
            Categories = new SelectList(categories, "Id", "Name", category);
            SelectedCategory = category;
        }

    }
}
