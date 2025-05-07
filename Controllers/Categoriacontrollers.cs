using APIProjetoLivros.Interface;
using APIProjetoLivros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categoriacontrollers : ControllerBase
    {
        //Injetar o Repository
        private readonly ICategoriaRepository _repository;

        public Categoriacontrollers(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult ListarTodos()
        {
            var categorias = _repository.ListsrTodos();
            return Ok (categorias); 
        }

        [HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            _repository.Cadastrar(categoria);
            return Created();

        }
    }
}
