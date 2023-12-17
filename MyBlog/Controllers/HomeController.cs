using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using System.Diagnostics;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using var ctx = new BlogContext();
            var posts = ctx.Posts.ToArray();

            return View(posts);
        }

        public IActionResult Detail(int id) 
        {
            //qua dobbiamo prendere il singolo post 
            using var ctx = new BlogContext();
            var post = ctx.Posts.SingleOrDefault();

            if (post is null)
            {
                return NotFound($"Not found, sorry");
            }

            return View(post);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}