using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Interfaces
{
    public interface IAllDates
    {
        IEnumerable<Date> Dates { get; }
    }
}
