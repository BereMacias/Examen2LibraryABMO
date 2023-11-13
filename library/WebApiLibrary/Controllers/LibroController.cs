using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using libraryExamen2.Operaciones;
using libraryExamen2.Models;

namespace WebApiLibrary.Controllers
{
    [Route("api")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private libroDAO libroDAO = new libroDAO();

        //POST libro
        [HttpPost("libro")]
        public bool insertBook([FromBody] Book book)
        {
            return libroDAO.insertBook(book.IdAuthor, book.Title, book.Chapters, book.Pages, book.Price);
        }

        //GETALL libros
        [HttpGet("libros")]
        public List<Book> selectBooks()
        {
            return libroDAO.selectBooks();
        }

        //GET libro por id
        [HttpGet("book")]
        public Book selectBookId(int id)
        {
            return libroDAO.selectBookId(id);
        }

        [HttpGet("AuthorBook")]
        public List<AuthorBook> selectAuthorBook() { 
            return libroDAO.selectAuthorBook();
        }

        [HttpGet("tituloBook")]
        public List<AuthorBook> selectTitleBook(string titulo)
        {
            return libroDAO.selectTitleBook(titulo);
        }
    }
}
