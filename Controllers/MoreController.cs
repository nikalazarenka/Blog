using Blog.Data.Interfaces;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blog.Controllers
{
    public class MoreController : Controller
    {
        private readonly IAllArticle _articleRepository;
        private readonly IArticleCategory _categoryRepository;
        private readonly IAllDates _dateRepository;
        private readonly IArticleTags _tagsRepository;

        public MoreController(IAllArticle articleRepository, IArticleCategory categoryRepository, IAllDates dateRepository, IArticleTags tagsRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _dateRepository = dateRepository;
            _tagsRepository = tagsRepository;
        }

        public ViewResult Index(int id)
        {
            var article = _articleRepository.getObjectArticle(id);
            var category = _categoryRepository.getObjectCategory(article.CategoryId);
            var date = _dateRepository.getObjectDate(article.DateId);
            var tags = _tagsRepository.getObjectTags(article.Id);
            var more = new MoreViewModel
            {
                Article = article,
                Category = category,
                Date = date,
                Tags = tags
            };

            return View(more);
        }
    }
}
