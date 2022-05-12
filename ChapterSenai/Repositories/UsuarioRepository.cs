using ChapterSenai.Contexts;
using ChapterSenai.Interfaces;
using ChapterSenai.Models;

namespace ChapterSenai.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ChapterContext _context;
        public UsuarioRepository(ChapterContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioEncotrado = _context.Usuarios.Find(id);
            if (usuarioEncotrado != null)
            {
                usuarioEncotrado.Email = usuario.Email;
                usuarioEncotrado.Senha = usuario.Senha;
                usuarioEncotrado.Tipo = usuario.Tipo;
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioEncotrado = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuarioEncotrado);
            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
