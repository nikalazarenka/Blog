using Blog.Data.Interfaces;
using Blog.Data.Models;
using System.Collections.Generic;

namespace Blog.Data.Repository
{
    public class DateRepository : IAllDates
    {
        private readonly AppDbContext appDbContext;
        public DateRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Date> Dates => appDbContext.Dates;
    }
}
