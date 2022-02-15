using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Models
{
    public class Date
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public List<Article> Articles { get; set; }
    }
}
