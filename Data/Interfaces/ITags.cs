using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface ITags
    {
        IEnumerable<Tag> Tags { get; }
        List<Tag> getObjectTagsByArticleId(int? articleId);
        Tag getObjectTag(int? id);
        public void Create(string name);
        public void Delete(int? id);
        public void Edit(Tag tag);
    }
}