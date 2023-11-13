using libraryExamen2.Context;
using libraryExamen2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace libraryExamen2.Operaciones
{
    public class libroDAO
    {

        //Objeto context
        public ELibraryContext contexto = new ELibraryContext();

        //Crear libro
        public bool insertBook(int idAut, string title, int chapters, int pages, double price)
        {
            try
            {
                var author = contexto.Authors.Where(aut => aut.Id == idAut).FirstOrDefault();

                if(author != null)
                {
                    Book book = new Book();
                    book.IdAuthor = idAut;
                    book.Title = title;
                    book.Chapters = chapters;
                    book.Pages = pages;
                    book.Price = price;

                    contexto.Books.Add(book);
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        //Obtener todos los libros 
        public List<Book> selectBooks() 
        {

            var books = contexto.Books.ToList<Book>();
            return books;
        }

        //Obtener por Id
        public Book selectBookId(int IdB)
        {
            var book = contexto.Books.Where(b => b.Id == IdB).FirstOrDefault();
            return book;
        }

        public List<AuthorBook> selectAuthorBook()
        {
            var query = from b in contexto.Books
                        join a in contexto.Authors on b.IdAuthor
                equals a.Id
                        select new AuthorBook
                        {
                            bookTitulo = b.Title,
                            authorNombre = a.Name,
                            chapters = b.Chapters,
                            pages = b.Pages,
                            price = b.Price
                        };
            return query.ToList();
        }

        public List<AuthorBook> selectTitleBook(string titulo)
        {
            var query = from b in contexto.Books
                        join a in contexto.Authors on b.IdAuthor
                        equals a.Id
                        where b.Title == titulo
                        select new AuthorBook
                        {
                            bookTitulo = b.Title,
                            authorNombre = a.Name,
                            chapters = b.Chapters,
                            pages = b.Pages,
                            price = b.Price
                        } ;
            return query.ToList();
        }
       
    }
}
