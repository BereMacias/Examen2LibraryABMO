using libraryExamen2.Context;
using libraryExamen2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace libraryExamen2.Operaciones
{
    public class AutorDao
    {
        public ELibraryContext contexto = new ELibraryContext();

        //Insertar autor 
        public bool insertAutor(String name)
        {
            try
            {
                var authorName = contexto.Authors.Where(aut => aut.Name == name).FirstOrDefault();

                if(authorName == null)
                {
                    Author author = new Author();
                    author.Name = name;

                    contexto.Authors.Add(author);
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

        public List<Author> selectAuthors() {
            var authors = contexto.Authors.ToList<Author>();
            return authors;
        }



    }
}
