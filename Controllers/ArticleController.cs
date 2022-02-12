using Blog.Data.Interfaces;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IAllArticle _allArticles;
        public ArticleController(IAllArticle iAllArticles)
        {
            _allArticles = iAllArticles;
        }

        public ViewResult ArticleList()
        {
            var article = _allArticles.Articles;
            var articleObj = new ArticleListViewModel
            {
                allArticle = article,
            };
            return View(articleObj);
        }
    }
}
