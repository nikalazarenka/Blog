using Blog.Data.Interfaces;
using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
