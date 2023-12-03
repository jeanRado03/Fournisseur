using Fournisseur.Model;
using Fournisseur.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fournisseur.Controllers
{
    [ApiController]
    [Route(("article/[controller]"))]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticleController() 
        {
            _articleService = new ArticleService();
        }

        [HttpPost("saveArticle")]
        public IActionResult saveArticle([FromBody] Article article)
        {
            _articleService.saveArticle(article);
            return Ok(article);
        }

    }
}
