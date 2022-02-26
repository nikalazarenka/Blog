using Blog.Data.Interfaces;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class MoreController : Controller
    {
        private readonly IArticles _articleRepository;
        private readonly ICategories _categoryRepository;
        private readonly IDates _dateRepository;
        private readonly ITags _tagsRepository;

        public MoreController(IArticles articleRepository, ICategories categoryRepository, IDates dateRepository, ITags tagsRepository)
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
            var tags = _tagsRepository.getObjectTagsByArticleId(article.Id);
            var _article = new ArticleViewModel
            {
                Article = article,
                Category = category,
                Date = date,
                Tags = tags
            };

            return View(_article);
        }
    }
}
