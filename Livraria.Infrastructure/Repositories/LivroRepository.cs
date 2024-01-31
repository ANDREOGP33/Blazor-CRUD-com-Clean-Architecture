using Livraria.Domain.Abstractions;
using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationDbContext _context;

        public LivroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Livro> AdicionarLivro(Livro Livro)
        {
            if(_context is not null && Livro is not null && _context.Livros is not null)
            {
                _context.Livros.Add(Livro);
                await _context.SaveChangesAsync();
                return Livro;
            }
            else
            {
                throw new InvalidOperationException("Dados invalidos...");
            }          
        }

        public async Task Atualizar(Livro livro)
        {
            if (_context is not null)
            {
                _context.Entry(livro).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados invalidos...");
            }
        }

        public async Task DeletarLivro(int id)
        {
            var livro = await ObterLivro(id);
            if(livro is not null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados invalidos...");
            }
        }

        public async Task<Livro?> ObterLivro(int id)
        {
            var livro = await _context.Livros.FirstOrDefaultAsync(l=>l.LivroId == id);
            
            if (livro == null)
                throw new InvalidOperationException($"Livro com ID {id} não encontrado");

            return livro;
        }

        public async Task<IEnumerable<Livro>> ObterLivros()
        {
            if (_context is not null && _context.Livros is not null)
            {
                var livros = await _context.Livros.ToListAsync();
                return livros;
            }
            else
            {
                return new List<Livro>();
            }
        }
    }
}
