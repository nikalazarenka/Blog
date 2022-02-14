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
        private readonly IAllArticle _articleRepository;
        private readonly IArticleCategory _categoryRepository;
        private readonly IAllPublications _publicationsRepository;
        public HomeController(IAllArticle articleRepository, IArticleCategory categoryRepository, IAllPublications publicationsRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _publicationsRepository = publicationsRepository;
        }
        public ViewResult Index(int? category, int? date,int page=1)
        {
            int pageSize = 3;
            IQueryable<Article> articles = (IQueryable<Article>)_articleRepository.Articles;

            if (category != null && category != 0 && date != null && date != 0)
            {
                articles = articles.Where(a => a.CategoryId == category);
            }

            var count = articles.Count();
            var items = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            FilterViewModel filterViewModel = new FilterViewModel(_categoryRepository.AllCategories.ToList(), category, _publicationsRepository.Dates.ToList(), date);

            var homeArticles = new HomeViewModel
            {
                allArticles = items,
                FilterViewModel = filterViewModel,
                PageViewModel = pageViewModel
            };

            return View(homeArticles);
        }
    }
}
