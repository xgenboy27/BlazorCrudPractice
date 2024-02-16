using Microsoft.AspNetCore.Identity;

namespace BlazorCrudPractice.Server.Model
{
    public abstract class BaseEmployee
    { 
        public IConfiguration Configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json").Build();

        public bool isValid { get; set; }


        public BaseEmployee()
        {
        }
    }
}
