using Blog.Data.Interfaces;
using Blog.Data.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticles _articleRepository;
        private readonly ICategories _categoryRepository;
        private readonly IDates _datesRepository;
        private readonly ITags _tagsRepository;
        public ArticleController(IArticles articlesRepository, ICategories categoriesRepository, IDates datesRepository, ITags tagsRepository)
        {
            _articleRepository = articlesRepository;
            _categoryRepository = categoriesRepository;
            _datesRepository = datesRepository;
            _tagsRepository = tagsRepository;
        }
        public ViewResult Index(int page = 1)
        {
            int pageSize = 6;
            IQueryable<Article> _articles = (IQueryable<Article>)_articleRepository.Articles;
            var count = _articles.Count();
            var items = _articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            var articles = new ArticlesViewModel
            {
                Articles = items,
                PageViewModel = pageViewModel
            };

            return View(articles);
        }

        [HttpGet]
        public IActionResult Create(int? category, int? tag)
        {
            SelectViewModel selectViewModel = new SelectViewModel(_categoryRepository.Categories.ToList(), category, _tagsRepository.Tags.ToList(), tag);
            var articlesViewModel = new ArticlesViewModel
            {
                SelectViewModel = selectViewModel,
            };

            var createArticleViewModel = new CreateOrEditArticleViewModel
            {
                ArticlesViewModel = articlesViewModel
            };

            return View(createArticleViewModel);
        }

        [HttpPost]
        public IActionResult Create(string name, string shortDescription, string description, string image, int category, int tag)
        {
            _articleRepository.Create(name, shortDescription, description, image, category, tag);
            return RedirectToAction("Index", "Article");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Article _article = _articleRepository.getObjectArticle(id);
                if (_article != null)
                {
                    var article = new ArticleViewModel
                    {
                        Article = _article
                    };

                    return View(article);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _articleRepository.Delete(id);
            return RedirectToAction("Index", "Article");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Article _article = _articleRepository.getObjectArticle(id);
                if (_article != null)
                {
                    List<Tag> tags = _tagsRepository.getObjectTagsByArticleId(id);
                    int tag = tags.FirstOrDefault().Id;
                    SelectViewModel selectViewModel = new SelectViewModel(_categoryRepository.Categories.ToList(), _article.CategoryId, _tagsRepository.Tags.ToList(), tag);
                    var articlesViewModel = new ArticlesViewModel
                    {
                        SelectViewModel = selectViewModel,
                    };

                    var editArticleViewModel = new CreateOrEditArticleViewModel
                    {
                        Id= _article.Id,
                        ArticlesViewModel = articlesViewModel,
                        Name = _article.Name,
                        ShortDescription = _article.ShortDescription,
                        Description = _article.ShortDescription,
                        Image = _article.Image,
                        Category = _categoryRepository.Categories.FirstOrDefault(c=>c.Id == _article.CategoryId),
                        Tags = _tagsRepository.Tags.Where(t=>t.Id == tag).ToList()
                    };

                    return View(editArticleViewModel);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(int id,string name, string shortDescription, string description, string image, int category, int tag)
        {
            _articleRepository.Edit(id,name,shortDescription,description,image,category,tag);
            return RedirectToAction("Index", "Article");
        }
    }
}
