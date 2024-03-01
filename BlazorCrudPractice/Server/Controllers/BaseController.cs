using BlazorCrudPractice.Server.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudPractice.Server.Controllers
{
    public abstract class BaseController : Controller
    {

        public BaseController()
        {

        }


        public User UserInfo
        {
            get { return HttpContext.Session.Get<User>("UserInfo"); }
            set { HttpContext.Session.Set<User>("UserInfo", value); }
        }

        public string GetResourcePath()
        {
            return new Uri($"{Request.Scheme}://{Request.Host}/").ToString();
        }
    }
}
