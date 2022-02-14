using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public int PublicationDateId { get; set; }
        public virtual Date PublicationDate { get; set; }
    }
}
