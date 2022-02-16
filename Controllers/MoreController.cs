using Blog.Data.Interfaces;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class MoreController : Controller
    {
        private readonly IAllArticle _articleRepository;

        public MoreController(IAllArticle articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public ViewResult Index(int id)
        {
            var item = _articleRepository.getObjectArticle(id);
            var more = new MoreViewModel
            {
                Article = item
            };

            return View(more);
        }
    }
}
