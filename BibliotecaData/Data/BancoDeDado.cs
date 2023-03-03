using BibliotecaApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static BibliotecaCore.Aplicacao;

namespace BibliotecaApi.Data
{
    public class BancoDeDado: DbContext, IBancoDeDados
    {
        public BancoDeDado(DbContextOptions options): base(options)
        {

        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }


        public Autor Find(Guid id)
        {
            return this.Autor.Find(id);
        }

        public List<Autor> GetAutor()
        {
            return this.Autor.ToList();
        }

        public Livro FindLivro(Guid id)
        {
            return this.Livro.Find(id);
        }

        public List<Livro> GetLivros()
        {
            return this.Livro.ToList();
        }

        public void Remove(Guid id)
        {
            var autor = this.Find(id);
            this.Autor.Remove(autor);
        }

        public void Save(Autor autor)
        {
            this.Autor.Add(autor);
            this.SaveChanges();
        }

        public void Edit(Autor autor)
        {
            this.Autor.Update(autor);
            this.SaveChanges();
        }

        public void SaveLivro(Livro livro)
        {
            this.Livro.Add(livro);
            this.SaveChanges();
        }

        public void EditLivro(Livro livro)
        {
            this.Livro.Update(livro);
            this.SaveChanges();
        }

        public void RemoveLivro(Guid id)
        {
            var livro = this.FindLivro(id);
            this.Livro.Remove(livro);
        }
    }
}
