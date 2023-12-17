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

            // Imposta le lunghezze massime da mostrare nella view
            int titleMaxLenght = 25; 
            int DescriptionMaxLenght = 90; 

            foreach (var post in posts)
            {
                // così tronco i testi troppo lunghi
                if (post.Title.Length > titleMaxLenght)
                {
                    post.Title = post.Title.Substring(0, titleMaxLenght) + "...";
                }

                if (post.Description.Length > DescriptionMaxLenght)
                {
                    post.Description = post.Description.Substring(0, DescriptionMaxLenght) + "...";
                }
            }

            return View(posts);            
        } 

        public IActionResult Detail(int id)
        {
            using var ctx = new BlogContext();
            //qua dobbiamo prendere il singolo post
            var post = ctx.Posts.FirstOrDefault(p => p.Id == id);

            if (post is null)
            {
                return NotFound($"This element doesn't exist, spiaze");
            }

            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        //ci sono due create, la prima risponde ad una richiesta GET, e restituisce solo una vista
        //l'altra risponde ad una POST, ed elabora il contenuto del form (solo alla fine darà una vista)

        [HttpPost]
        [ValidateAntiForgeryToken] // Verifica il token anti forgery
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid) //se il form non è valido
            {
                return View(post);
            }

            // se è valid storiamo il post
            using var ctx = new BlogContext();
            ctx.Posts.Add(post);
            ctx.SaveChanges();

            // Ora otteniamo l'ID del post appena creato
            int postId = post.Id; 
            return RedirectToAction("Detail", "Home", new { Id = postId });
            //return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}