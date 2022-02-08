using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Interfaces
{
    public interface IArticleTags
    {
        IEnumerable<Tag> AllTags { get; }
    }
}
