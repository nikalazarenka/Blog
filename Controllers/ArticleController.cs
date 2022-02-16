using Blog.Data.Interfaces;
using Blog.Data.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IAllArticle _articleRepository;
        private readonly IArticleCategory _categoryRepository;
        private readonly IAllDates _datesRepository;
        public ArticleController(IAllArticle articlesRepository, IArticleCategory categoriesRepository, IAllDates datesRepository)
        {
            _articleRepository = articlesRepository;
            _categoryRepository = categoriesRepository;
            _datesRepository = datesRepository;
        }

        public ViewResult ArticleList(int? category, int? date, int page = 1)
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

            var count = articles.Count();
            var items = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            FilterViewModel filterViewModel = new FilterViewModel(_categoryRepository.AllCategories.ToList(), category, _datesRepository.Dates.ToList(), date);

            var articleList = new ArticleListViewModel
            {
                allArticle = items,
                FilterViewModel = filterViewModel,
                PageViewModel = pageViewModel
            };

            return View(articleList);
        }
    }
}
