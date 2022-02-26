using Blog.Data.Interfaces;
using Blog.Data.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticles _articleRepository;
        private readonly ICategories _categoryRepository;
        private readonly IDates _datesRepository;
        private readonly ITags _tagsRepository;
        public HomeController(IArticles articlesRepository, ICategories categoriesRepository, IDates datesRepository, ITags tagsRepository)
        {
            _articleRepository = articlesRepository;
            _categoryRepository = categoriesRepository;
            _datesRepository = datesRepository;
            _tagsRepository = tagsRepository;
        }
        public ViewResult Index(int? category, int? date, int? tag, int page = 1)
        {
            int pageSize = 3;
            IQueryable<Article> _articles = (IQueryable<Article>)_articleRepository.Articles;

            if (category != null && category != 0)
            {
                _articles = _articles.Where(a => a.CategoryId == category);
            }

            if (date != null && date != 0)
            {
                _articles = _articles.Where(a => a.DateId == date);
            }

            if (tag != null && tag != 0)
            {
                _articles = _articles.Where(a => a.Tags.Any(t => t.Id == tag));
            }

            var count = _articles.Count();
            var items = _articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            FilterViewModel filterViewModel = new FilterViewModel(_categoryRepository.Categories.ToList(), category, _datesRepository.Dates.ToList(), date, _tagsRepository.Tags.ToList(), tag);

            var articles = new ArticlesViewModel
            {
                Articles = items,
                FilterViewModel = filterViewModel,
                PageViewModel = pageViewModel
            };

            return View(articles);
        }
    }
}
