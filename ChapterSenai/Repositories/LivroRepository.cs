using ChapterSenai.Contexts;
using ChapterSenai.Models;

namespace ChapterSenai.Repositories
{
    public class LivroRepository 
    {
        // possui acesso aos dados
        private readonly ChapterContext _context;
        // somente um data context na memória da aplicação na requisição, evitar o usar o new
        // para o repositório existir, precisa do contexto, a aplicacao cria
        // configurar no startup
        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }
        // retorna a lista de livros
        public List<Livro> Listar()
        {
            // SELECT Id, Titulo, QuantidadePaginas, Disponivel FROM Livros;
            return _context.Livros.ToList();
        }
    }
}
