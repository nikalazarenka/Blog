using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface IArticleTags
    {
        IEnumerable<Tag> AllTags { get; }
        List<Tag> getObjectTags(int articleId);

    }
}