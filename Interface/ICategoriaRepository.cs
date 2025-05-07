using APIProjetoLivros.Models;

namespace APIProjetoLivros.Interface
{
    public interface ICategoriaRepository
    {
        // Assincrono - Task (Tarefa)
        //Sincrono
        List<Categoria>ListsrTodos();
        Task<List<Categoria>> ListarTodosAsync();
        void Cadastrar(Categoria categoria);    
        Categoria?Atualizar(int id, Categoria categoria);
        Categoria? Deletar (int id);    
    }
}
