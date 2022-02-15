using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Blog.Data.Models
{
    public class DbObjects
    {
        public static void Initial(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                using (var ts = new TransactionScope())
                {
                    context.Categories.AddRange(Categories.Select(c => c.Value));
                    ts.Complete();
                }
            }

            context.SaveChanges();

            if (!context.Tags.Any())
            {
                using (var ts = new TransactionScope())
                {
                    context.Tags.AddRange(Tags.Select(t => t.Value));
                    ts.Complete();
                }
            }

            context.SaveChanges();

            if (!context.Dates.Any())
            {
                using (var ts = new TransactionScope())
                {
                    context.Dates.AddRange(
                        new Date
                        {
                            Datetime = DateTime.Now
                        },
                        new Date
                        {
                            Datetime = new DateTime(2015, 7, 20, 18, 30, 25)
                        },
                        new Date
                        {
                            Datetime = new DateTime(2018, 7, 20, 18, 30, 25)
                        },
                        new Date
                        {
                            Datetime = new DateTime(2020, 12, 20, 17, 34, 25)
                        },
                        new Date
                        {
                            Datetime = new DateTime(2022, 2, 15, 21, 35, 0)
                        },
                        new Date
                        {
                            Datetime = new DateTime(2011, 10, 20, 17, 34, 24)
                        }
                        );

                    ts.Complete();
                }
            }

            context.SaveChanges();

            if (!context.Articles.Any())
            {
                using (var ts = new TransactionScope())
                {
                    context.Articles.AddRange(
                        new Article
                        {
                            Name = "Example1",
                            ShortDescription = "example1 example1 example1",
                            Description =
                            "example1 example1 example1 example1 example1 example1 example1 example1 example1 " +
                            "example1 example1 example1 example1 example1 example1 example1 example1 example1 " +
                            "example1 example1 example1 example1 example1 example1 example1 example1 example1 " +
                            "example1 example1 example1 example1 example1 example1 example1 example1 example1 ",
                            Image = "/img/example1.jpg",
                            Category = Categories["category1"],
                            Tags = new List<Tag>() { Tags["tag1"], Tags["tag2"] },
                            Date = context.Dates.FirstOrDefault()
                        },
                        new Article
                        {
                            Name = "Example2",
                            ShortDescription = "example2 example2 example2",
                            Description =
                            "example2 example2 example2 example2 example2 example2 example2 example2 example2 " +
                            "example2 example2 example2 example2 example2 example2 example2 example2 example2 " +
                            "example2 example2 example2 example2 example2 example2 example2 example2 example2 " +
                            "example2 example2 example2 example2 example2 example2 example2 example2 example2 ",
                            Image = "/img/example2.jpg",
                            Category = Categories["category2"],
                            Tags = new List<Tag>() { Tags["tag3"], Tags["tag4"] },
                            Date = context.Dates.FirstOrDefault()
                        },
                        new Article
                        {
                            Name = "Example3",
                            ShortDescription = "example3 example3 example3",
                            Description =
                            "example3 example3 example3 example3 example3 example3 example3 example3 example3 " +
                            "example3 example3 example3 example3 example3 example3 example3 example3 example3 " +
                            "example3 example3 example3 example3 example3 example3 example3 example3 example3 " +
                            "example3 example3 example3 example3 example3 example3 example3 example3 example3 ",
                            Image = "/img/example3.jpg",
                            Category = Categories["category3"],
                            Tags = new List<Tag>() { Tags["tag1"], Tags["tag5"] },
                            Date = context.Dates.FirstOrDefault()
                        },
                        new Article
                        {
                            Name = "Example4",
                            ShortDescription = "example4 example4 example4",
                            Description =
                            "example4 example4 example4 example4 example4 example4 example4 example4 example4 " +
                            "example4 example4 example4 example4 example4 example4 example4 example4 example4 " +
                            "example4 example4 example4 example4 example4 example4 example4 example4 example4 " +
                            "example4 example4 example4 example4 example4 example4 example4 example4 example4 ",
                            Image = "/img/example4.jpg",
                            Category = Categories["category1"],
                            Tags = new List<Tag>() { Tags["tag1"], Tags["tag4"] },
                            Date = context.Dates.FirstOrDefault()
                        },
                        new Article
                        {
                            Name = "Example5",
                            ShortDescription = "example5 example5 example5",
                            Description =
                            "example5 example5 example5 example5 example5 example5 example5 example5 example5 " +
                            "example5 example5 example5 example5 example5 example5 example5 example5 example5 " +
                            "example5 example5 example5 example5 example5 example5 example5 example5 example5 " +
                            "example5 example5 example5 example5 example5 example5 example5 example5 example5 ",
                            Image = "/img/example5.jpg",
                            Category = Categories["category3"],
                            Tags = new List<Tag>() { Tags["tag1"], Tags["tag5"] },
                            Date = context.Dates.FirstOrDefault()
                        },
                        new Article
                        {
                            Name = "Example6",
                            ShortDescription = "example6 example6 example6",
                            Description =
                            "example6 example6 example6 example6 example6 example6 example6 example6 example6 " +
                            "example6 example6 example6 example6 example6 example6 example6 example6 example6 " +
                            "example6 example6 example6 example6 example6 example6 example6 example6 example6 " +
                            "example6 example6 example6 example6 example6 example6 example6 example6 example6 ",
                            Image = "/img/example6.jpg",
                            Category = Categories["category4"],
                            Tags = new List<Tag>() { Tags["tag3"], Tags["tag2"] },
                            Date = context.Dates.FirstOrDefault()
                        }
                        );

                    ts.Complete();
                }
            }

            context.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var categoryList = new Category[]
                    {
                         new Category {Name = "category1"},
                         new Category {Name = "category2"},
                         new Category {Name = "category3"},
                         new Category {Name = "category4"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category cat in categoryList)
                    {
                        category.Add(cat.Name, cat);
                    }
                }

                return category;
            }
        }

        private static Dictionary<string, Tag> tag;
        public static Dictionary<string, Tag> Tags
        {
            get
            {
                if (tag == null)
                {
                    var tagList = new Tag[]
                    {
                         new Tag {Name = "tag1"},
                         new Tag {Name = "tag2"},
                         new Tag {Name = "tag3"},
                         new Tag {Name = "tag4"},
                         new Tag {Name = "tag5"}
                    };

                    tag = new Dictionary<string, Tag>();
                    foreach (Tag tg in tagList)
                    {
                        tag.Add(tg.Name, tg);
                    }
                }

                return tag;
            }
        }
    }     
}
