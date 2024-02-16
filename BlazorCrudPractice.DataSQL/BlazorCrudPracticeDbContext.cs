using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.DataSQL
{
    public class BlazorCrudPracticeDbContext : DbContext
    {
        public BlazorCrudPracticeDbContext(DbContextOptions<BlazorCrudPracticeDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(TimeSpan.FromMinutes(30));

        }
    }
}
