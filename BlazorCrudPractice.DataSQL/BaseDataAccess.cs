using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudPractice.DataSQL
{
    public class BaseDataAccess
    {
        public DbContextOptionsBuilder<BlazorCrudPracticeDbContext> Builder = new DbContextOptionsBuilder<BlazorCrudPracticeDbContext>();

        ///private String PathAppsettings = System.IO.Path.Combine(Directory.GetCurrentDirectory());
        public IConfiguration Configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json").Build();

        public BaseDataAccess()
        {
            Builder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
        }
       
    }
}
