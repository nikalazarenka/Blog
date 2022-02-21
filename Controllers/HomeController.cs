using Blog.Data.Interfaces;
using Blog.Data.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllArticle _articleRepository;
        private readonly IArticleCategory _categoryRepository;
        private readonly IAllDates _datesRepository;
        private readonly IArticleTags _tagsRepository;
        public HomeController(IAllArticle articlesRepository, IArticleCategory categoriesRepository, IAllDates datesRepository, IArticleTags tagsRepository)
        {
            _articleRepository = articlesRepository;
            _categoryRepository = categoriesRepository;
            _datesRepository = datesRepository;
            _tagsRepository = tagsRepository;
        }
        public ViewResult Index(int? category, int? date, int? tag, int page = 1)
        {
            int pageSize = 3;
            IQueryable<Article> articles = (IQueryable<Article>)_articleRepository.Articles;

            if (category != null && category != 0)
            {
                articles = articles.Where(a => a.CategoryId == category);
            }

            if (date != null && date != 0)
            {
                articles = articles.Where(a => a.DateId == date);
            }

            if (tag != null && tag != 0)
            {
                articles = articles.Where(a => a.Tags.Any(t => t.Id == tag));
            }

            var count = articles.Count();
            var items = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            FilterViewModel filterViewModel = new FilterViewModel(_categoryRepository.AllCategories.ToList(), category, _datesRepository.Dates.ToList(), date, _tagsRepository.AllTags.ToList(), tag);

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
