using BibliotecaApi.Data;
using BibliotecaApi.Model;
using BibliotecaCore;
using System;
using System.Collections.Generic;

namespace BibliotecaCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Biblioteca das antigas!");

            Console.WriteLine("1 - Cadastrar Post");
            Console.WriteLine("2 - Buscar comentario");
            Console.WriteLine("3 - Deletar Post");


            var opcao = Console.ReadLine();

            switch(opcao)
            {
                case "1":

                   CriarPost();

                    break;

                case "2":

                    BuscarComentario();

                    break;


                case "3":

                    DeletarPost();

                    break;
            }
        }

        private static void DeletarPost()
        {
            Console.WriteLine("Insira o identificador do Post");
            var PostId = Guid.Parse(Console.ReadLine());

            var app = new Aplicacao(null);

            app.DeleteAutor(PostId);
        }

        private static void BuscarComentario()
        {
            Console.WriteLine("Insira o identificador do Post");
            var PostId = Guid.Parse(Console.ReadLine());

            var app = new Aplicacao(null);

            List<Livro> comentarios = app.GetLivros(default, default);

            foreach(var com in comentarios)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Autor: ", com.Titulo);
                Console.WriteLine("Autor: ", com.ISBN);
                Console.WriteLine("--------------------------------");
            }
        }

        private static void CriarPost()
        {
            var createPost = new CreateAutor();

            Console.WriteLine("Insira o Titulo");
            createPost.Nome = Console.ReadLine();

            Console.WriteLine("Insira o texto");
            createPost.Sobrenome = Console.ReadLine();

            BancoDeDado bd = null;

            var app = new Aplicacao(bd);

            app.CreatAutor(createPost);


        }
    }
}
