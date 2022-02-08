using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Models
{
    public class DbObjects
    {
        //public static void Initial(AppDbContext context)
        //{
        //    if (!context.Categories.Any())
        //    {
        //        context.Categories.AddRange(Categories.Select(c => c.Value));
        //    }

        //    if (!context.Articles.Any())
        //    {
        //        context.AddRange(
        //            new Article
        //            {
        //                Name= "Example",
        //                ShortDescription="example example example",
        //                Description = "example example example example example example example example example",
        //                Image = "/img/example.jpg",
        //                Category = Categories["1 example category"],
        //                Tags = { Tags["1 example tag"], Tags["2 example tag"] }
        //            }
        //            );
        //    }

        //    context.SaveChanges();
        //}

        //private static Dictionary<string, Category> category;
        //public static Dictionary<string, Category> Categories
        //{
        //    get
        //    {
        //        if (category == null)
        //        {
        //            var categoryList = new Category[]
        //            {
        //                 new Category{Name ="1 example category"},
        //                 new Category{Name ="2 example category"},
        //                 new Category{Name ="3 example category"},

        //            };

        //            category = new Dictionary<string, Category>();
        //            foreach (Category cat in categoryList)
        //            {
        //                category.Add(cat.Name, cat);
        //            }
        //        }

        //        return category;
        //    }
        //}

        //private static Dictionary<string, Tag> tag;
        //public static Dictionary<string, Tag> Tags
        //{
        //    get
        //    {
        //        if (tag == null)
        //        {
        //            var tagList = new Tag[]
        //            {
        //                 new Tag {Name ="1 example tag"},
        //                 new Tag {Name ="2 example tag"},
        //                 new Tag {Name ="3 example tag"},

        //            };

        //            tag = new Dictionary<string, Tag>();
        //            foreach (Tag tg in tagList)
        //            {
        //                tag.Add(tg.Name, tg);
        //            }
        //        }

        //        return tag;
        //    }
        //}
    }
}
