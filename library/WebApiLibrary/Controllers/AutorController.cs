using libraryExamen2.Models;
using libraryExamen2.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLibrary.Controllers
{
    [Route("api")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AutorDao AutorDAO = new AutorDao();

        //POST author
        [HttpPost("autor")]
        public bool insertAutor([FromBody] Author author)
        {
            return AutorDAO.insertAutor(author.Name);
        }

        [HttpGet("autors")]
        public List<Author> selectAuthors()
        {
            return AutorDAO.selectAuthors();
        }
    }
}
