using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryExamen2.Models
{
    public class AuthorBook
    {
        public string bookTitulo { get; set; } = null;
        public string authorNombre { get; set; } = null;
        public int chapters { get; set; } 
        public int pages { get; set; }
        public double price { get; set; }

    }
}
