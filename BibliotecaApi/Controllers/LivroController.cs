using BibliotecaApi.Data;
using BibliotecaApi.Model;
using BibliotecaCore;
using BibliotecaCore.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivroController : Controller
    {
        public BancoDeDado BancodeDado { get; }

        public LivroController(BancoDeDado bancodeDados)
        {
            BancodeDado = bancodeDados;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string titulo)
        {
            return Ok(BancodeDado.GetLivros().Where(x => x.Titulo == titulo).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromQuery] Guid id)
        {
            var app = new Aplicacao(BancodeDado);
            var post = app.GetLivro(id);

            return Ok(post);
        }

        [HttpPost]
        public ActionResult Post([FromQuery] CreateLivro create)
        {
            var app = new Aplicacao(BancodeDado);
            var livro = app.CreateLivro2(create);

            return Created("api/livro", livro);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var app = new Aplicacao(BancodeDado);

            app.DeleteLivro(id);

            return NoContent();

        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, UpadateLivro update)
        {
            var app = new Aplicacao(BancodeDado);
            app.UpdateLivro(id, update);

            return Ok(update);

        }
    }
}
