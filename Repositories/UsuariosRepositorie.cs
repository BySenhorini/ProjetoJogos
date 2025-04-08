using Projeto_Jogos.Context;
using Projeto_Jogos.Domains;
using Projeto_Jogos.Interfaces;

namespace Projeto_Jogos.Repositories
{
    /// <summary>
    /// Repositório para gerenciamento dos usuarios
    /// </summary>
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly JogosContext _context;

        /// <summary>
        /// Repositório para gerenciamento dos usuarios
        /// </summary>
        public UsuariosRepository(JogosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Repositório para gerenciamento dos usuario.
        /// </summary>
        public void Atualizar(Guid id, Usuarios usuario)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.Find(id)!;

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Nickname = usuario.Nickname;
                    usuarioBuscado.JogoFavorito = usuario.JogoFavorito;
                }

                _context.Usuarios.Update(usuarioBuscado!);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos usuario.
        /// </summary
        public void Cadastrar(Usuarios usuarios)
        {
            try
            {
                usuarios.UsuarioID = Guid.NewGuid();

                _context.Usuarios.Add(usuarios);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos usuario.
        /// </summary
        public void Deletar(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.Find(id)!;

                if (usuarioBuscado != null)
                {
                    _context.Usuarios.Remove(usuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos usuario.
        /// </summary
        Usuarios IUsuariosRepository.BuscarPorId(Guid id)
        {
            try
            {
                return _context.Usuarios.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos usuario.
        /// </summary
        List<Usuarios> IUsuariosRepository.Listar()
        {
            try
            {
                return _context.Usuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}