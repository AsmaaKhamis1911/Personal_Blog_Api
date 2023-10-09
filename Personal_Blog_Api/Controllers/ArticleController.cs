using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Blog_Api.Models;

namespace Personal_Blog_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly BlogContext _context;
        public ArticleController(BlogContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllArticles()
        {
            List<Article> articles = _context.Articles.ToList();
            return Ok(articles);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetOneArticleRoute")]
        public IActionResult GetArticleById(int id)
        {
            Article article = _context.Articles.FirstOrDefault(x => x.Id == id);
            return Ok(article);
        }

        [HttpGet]
        [Route("{title:alpha}")]
        public IActionResult GetArticleByTitle(string title)
        {
            Article article = _context.Articles.FirstOrDefault(x => x.Title==title);
            return Ok(article);
        }

        [HttpPost]
        public IActionResult PostAllArticle(Article article)
        {
            if (ModelState.IsValid == true)
            {
                _context.Articles.Add(article);
                _context.SaveChanges();
                return Ok("Saved");
            }
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateArticel([FromRoute] int id, [FromBody] Article article)
        {
            if (ModelState.IsValid == true)
            {
                Article OldArticle = _context.Articles.FirstOrDefault(d => d.Id == id);
                if (OldArticle != null)
                {
                    OldArticle.Title = article.Title;
                    OldArticle.Content = article.Content;
                    OldArticle.CreatedAt = article.CreatedAt;
                    OldArticle.Author = article.Author;
                    OldArticle.Category = article.Category;
                    OldArticle.ImageUrl = article.ImageUrl;
                    _context.SaveChanges();
                    return StatusCode(204, OldArticle);
                }
                return BadRequest("Id Not Valid");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveArticleById(int id)
        {
            Article OldArticle = _context.Articles.FirstOrDefault(d => d.Id == id);
            if (OldArticle != null)
            {
                try
                {
                    _context.Articles.Remove(OldArticle);
                    _context.SaveChanges();
                    return StatusCode(204, "Record Remove Success");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Id Not Found");
        }
    }

}
