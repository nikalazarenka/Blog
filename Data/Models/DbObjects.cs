using System;
using System.Collections.Generic;
using System.Linq;
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
                    Category c1 = new Category { Name = "category1" };
                    Category c2 = new Category { Name = "category2" };
                    context.Categories.AddRange(c1, c2);
                    ts.Complete();
                }
            }

            context.SaveChanges();

            if (!context.Tags.Any())
            {
                using (var ts = new TransactionScope())
                {
                    Tag t1 = new Tag { Name = "tag1" };
                    Tag t2 = new Tag { Name = "tag2" };
                    Tag t3 = new Tag { Name = "tag3" };
                    Tag t4 = new Tag { Name = "tag4" };
                    context.Tags.AddRange(t1, t2, t3, t4);
                    ts.Complete();
                }
            }

            context.SaveChanges();

            if (!context.Articles.Any())
            {
                using (var ts = new TransactionScope())
                {
                    Article a1 = new Article
                    {
                        Name = "Example1",
                        ShortDescription = "example1 example1 example1",
                        Description =
                        "example1 example1 example1 example1 example1 example1 example1 example1 example1 " +
                        "example1 example1 example1 example1 example1 example1 example1 example1 example1 " +
                        "example1 example1 example1 example1 example1 example1 example1 example1 example1 " +
                        "example1 example1 example1 example1 example1 example1 example1 example1 example1 ",
                        Image = "/img/example1.jpg",
                        Category = context.Categories.Where(c=>c.Name== "category1").FirstOrDefault(),
                        Tags = new List<Tag>() { context.Tags.Where(t => t.Name == "tag1").FirstOrDefault(), context.Tags.Where(t => t.Name == "tag2").FirstOrDefault() }
                    };

                    Article a2 = new Article
                    {
                        Name = "Example2",
                        ShortDescription = "example2 example2 example2",
                        Description =
                            "example2 example2 example2 example2 example2 example2 example2 example2 example2 " +
                            "example2 example2 example2 example2 example2 example2 example2 example2 example2 " +
                            "example2 example2 example2 example2 example2 example2 example2 example2 example2 " +
                            "example2 example2 example2 example2 example2 example2 example2 example2 example2 ",
                        Image = "/img/example2.jpg",
                        Category = context.Categories.Where(c => c.Name == "category2").FirstOrDefault(),
                        Tags = new List<Tag>() { context.Tags.Where(t=>t.Name=="tag3").FirstOrDefault(), context.Tags.Where(t => t.Name == "tag4").FirstOrDefault() }
                    };

                    context.Articles.AddRange(a1, a2);
                    
                    // do the stuff
                    ts.Complete();
                }

                context.SaveChanges();
            }

            if (!context.Publications.Any())
            {
                using (var ts = new TransactionScope())
                {
                    context.Publications.AddRange(
                    new Publication
                    {
                        PublicationDate = DateTime.Now,
                        Article = context.Articles.FirstOrDefault()
                    },
                    new Publication
                    {
                        PublicationDate = DateTime.Now,
                        Article = context.Articles.FirstOrDefault()
                    }
                    );

                    ts.Complete();
                }
            }

            context.SaveChanges();
        }
    }
}
