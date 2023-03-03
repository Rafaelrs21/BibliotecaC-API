using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Model
{
    public class Livro
    {
        public Guid Id { get; set; }
        public Guid AutorId { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime DataCriada { get; set; }

    }
}
