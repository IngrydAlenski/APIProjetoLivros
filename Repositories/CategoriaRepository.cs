using APIProjetoLivros.Context;
using APIProjetoLivros.Interface;
using APIProjetoLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProjetoLivros.Repositories
{
    //Herdar e implementar (ctrl .)
    //Injetar o contexto
    public class CategoriaRepository : ICategoriaRepository
    {
        //Injecao de contexto
       private LivrosContext  _context;

        public CategoriaRepository(LivrosContext context)
        {
            _context = context;
        }
        public Categoria? Atualizar(int id, Categoria categoria)
        {
            //1 procuro quem atualizar 
            var categoriaEncontrada = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            //2 se nao acho, retorno nulo
            if (categoriaEncontrada == null) { return null; }

            //3 se eu acho atualizo as informacoes
            categoriaEncontrada.NomeCategoria = categoria.NomeCategoria;
            _context.SaveChanges();
            return categoriaEncontrada;
        }
        public void Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }
        public Categoria? Deletar(int id)
        { 
        //1 procuro o que quero  apagar 
        var categoria = _context.Categorias.Find(id);

        //2 se nao achei, retorno nulo
            if (categoria == null);
           
        //3 se achei apago
        _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }
        public async Task<List<Categoria>> ListarTodosAsync()
        {
          return await _context.Categorias.ToListAsync();

        }
        public List<Categoria> ListsrTodos()
        {
          return _context.Categorias.ToList();
        }

    }
}
