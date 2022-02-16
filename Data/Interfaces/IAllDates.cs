using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface IAllDates
    {
        IEnumerable<Date> Dates { get; }
    }
}
