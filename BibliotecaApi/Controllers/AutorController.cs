using BibliotecaApi.Data;
using BibliotecaApi.Model;
using BibliotecaCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BibliotecaApi.Controllers
{
    [Route("api/autor")]
    [ApiController]
    public class AutorController : Controller
    {

        public BancoDeDado BancodeDado { get; }

        public AutorController(BancoDeDado bancodeDados)
        {
            BancodeDado = bancodeDados;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string nome)
        {
          return Ok(BancodeDado.GetAutor().Where(x => x.Nome == nome).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromQuery] Guid id)
        {
            var app = new Aplicacao(BancodeDado);
            var post = app.GetAutor(id);

            return Ok(post);
        }

        [HttpPost]
        public ActionResult Post([FromQuery]CreateAutor create)
        {
            var app = new Aplicacao(BancodeDado);
            var post = app.CreatAutor(create);

            return Created("api/autor",post);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]Guid id)
        {
            var app = new Aplicacao(BancodeDado);

            app.DeleteAutor(id);

            return NoContent();

        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, UpdateAutor update)
        {
            var app = new Aplicacao(BancodeDado);
            app.UpdateAutor(id, update);
        
            return Ok(update);

        }
        [HttpPost("{id}/livros")]
        public ActionResult AutorLivro([FromRoute]Guid id, [FromBody] CreateLivro create)
        {
            var app = new Aplicacao(BancodeDado);
            app.CreateLivro(id,create);
              
            return Ok(create);
        }

        [HttpGet("{id}/livros")]
        public ActionResult GetLivro([FromRoute] Guid id, [FromQuery(Name = "id")] Guid livroId)
        {
            var app = new Aplicacao(BancodeDado);

            var livro = app.GetLivros(id, livroId);

            return Ok(livro);
        }

        [HttpGet("{id}/livros/{livrosId}")]
        public ActionResult GetLivro2([FromRoute] Guid id, [FromQuery] Guid livroId)
        {
            var livro = BancodeDado.GetLivros().Where(x => x.Id == livroId && x.AutorId ==id);

            return Ok(livro);
        }


    }
}
