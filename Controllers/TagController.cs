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
    public class TagController : Controller
    {
        private readonly ITags _tagsRepository;
        public TagController(ITags tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public IActionResult Index()
        {
            IQueryable<Tag> _tags = (IQueryable<Tag>)_tagsRepository.Tags;
            var tags = new TagsViewModel
            {
                Tags = _tags
            };

            return View(tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            _tagsRepository.Create(name);
            return RedirectToAction("Index", "Tag");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Tag _tag = _tagsRepository.getObjectTag(id);
                if (_tag != null)
                {
                    var tag = new TagViewModel
                    {
                        Name = _tag.Name
                    };

                    return View(tag);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _tagsRepository.Delete(id);
            return RedirectToAction("Index", "Tag");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Tag _tag = _tagsRepository.getObjectTag(id);
                if (_tag != null)
                {
                    var tag = new TagViewModel
                    {
                        Name = _tag.Name
                    };

                    return View(tag);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Tag tag)
        {
            _tagsRepository.Edit(tag);
            return RedirectToAction("Index", "Tag");
        }
    }
}
