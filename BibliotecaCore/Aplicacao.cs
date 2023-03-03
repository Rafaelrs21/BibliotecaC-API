using BibliotecaApi.Model;
using BibliotecaCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using static BibliotecaCore.Aplicacao;

namespace BibliotecaCore
{
    public class Aplicacao
    {
        public Aplicacao(IBancoDeDados bancoDeDados)
        {
            BancoDeDado = bancoDeDados;
        }

        public IBancoDeDados BancoDeDado { get; }
        

        public Autor GetAutor(Guid id)
        {
            var autor = BancoDeDado.Find(id);

            return autor;
        }

        public Autor CreatAutor(CreateAutor create)
        {
            var autor = new Autor();

            autor.Id = Guid.NewGuid();
            autor.Nome = create.Nome;
            autor.Sobrenome = create.Sobrenome;
            autor.Email = create.Email;
            autor.DataNascimento = DateTime.UtcNow;

            BancoDeDado.Save(autor);

            return autor;
        }

        public void DeleteAutor(Guid id)
        {
            BancoDeDado.Remove(id);
        }

        public Autor UpdateAutor(Guid id, UpdateAutor update)
        {
            var autor = BancoDeDado.Find(id);

            autor.Nome = update.Nome;
            BancoDeDado.Edit(autor);

            return autor;
        }

        public Livro GetLivro(Guid id)
        {
            var livro = BancoDeDado.FindLivro(id);

            return livro;
        }

        public List<Livro> GetLivros(Guid autorId ,Guid livroId)
        {
            var list = new List<Livro>();

            if(livroId != default)
            {
                var livro = BancoDeDado.FindLivro(livroId);
                list.Add(livro);
            }
            else
            {
                var livros = BancoDeDado.GetLivros().Where(x => x.AutorId == autorId).ToList();
                list.AddRange(livros);
            }

            return list;
        }
        public Livro CreateLivro(Guid id ,CreateLivro create)
        {
            var livro = new Livro();

            livro.Id = Guid.NewGuid();
            livro.AutorId = id;
            livro.Titulo = create.Titulo;
            livro.ISBN = create.ISBN;
            livro.DataCriada = DateTime.UtcNow;

            BancoDeDado.SaveLivro(livro);
            
            return livro;
        }

        public Livro CreateLivro2(CreateLivro create)
        {
            var livro = new Livro();

            livro.Id = Guid.NewGuid();
            livro.AutorId = Guid.NewGuid();
            livro.Titulo = create.Titulo;
            livro.ISBN = create.ISBN;
            livro.DataCriada = DateTime.UtcNow;

            BancoDeDado.SaveLivro(livro);

            return livro;
        }

        public void DeleteLivro(Guid id)
        {
            BancoDeDado.RemoveLivro(id);
        }

        public Livro UpdateLivro(Guid id, UpadateLivro update)
        {
            var livro = BancoDeDado.FindLivro(id);

            livro.Titulo = update.Titulo;
            BancoDeDado.EditLivro(livro);

            return livro;
        }

        public interface IBancoDeDados
        {
            List<Autor> GetAutor();
            Autor Find(Guid id);
            void Save(Autor post);
            void Edit(Autor post);
            void Remove(Guid id);


            List<Livro> GetLivros();
            Livro FindLivro(Guid id);
            void SaveLivro(Livro comment);
            void EditLivro(Livro livro);
            void RemoveLivro(Guid id);
        }
    }
}