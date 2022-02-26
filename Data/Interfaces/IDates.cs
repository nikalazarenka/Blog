using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Interfaces
{
    public interface IDates
    {
        IEnumerable<Date> Dates { get; }
        Date getObjectDate(int dateId);

    }
}
