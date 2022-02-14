using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Models
{
    public class Date
    {
        public DateTime PublicationDate { get; set; }
        public List<Publication> Publications { get; set; }
    }
}
