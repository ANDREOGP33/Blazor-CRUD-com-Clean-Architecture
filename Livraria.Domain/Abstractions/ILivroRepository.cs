using Livraria.Domain.Entities;

namespace Livraria.Domain.Abstractions
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> ObterLivros();
        Task<Livro?> ObterLivro(int id);
        Task<Livro> AdicionarLivro(Livro Livro);
        Task DeletarLivro(int id);
        Task Atualizar(Livro Livro);
    }
}
