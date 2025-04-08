using Projeto_Jogos.Context;
using Projeto_Jogos.Domains;
using Projeto_Jogos.Interfaces;


namespace Projeto_Jogos.Repositories
{
    /// <summary>
    /// Repositório para gerenciamento dos usuarios
    /// </summary>
    public class JogosRepository : IJogosRepository
    {
        private readonly JogosContext _context;

        /// <summary>
        /// Repositório para gerenciamento dos usuarios
        /// </summary>
        public JogosRepository(JogosContext context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Jogos jogos)
        {
            try
            {
                Jogos jogosBuscado = _context.Jogos.Find(id)!;

                if (jogosBuscado != null)
                {
                    jogosBuscado.NomeDoJogo = jogos.NomeDoJogo;
                    jogosBuscado.Plataforma = jogos.Plataforma;
                }

                _context.Jogos.Update(jogosBuscado!);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Jogos BuscarPorId(Guid id)
        {
            try
            {
                return _context.Jogos.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Jogos jogos)
        {
            try
            {
                jogos.JogoID = Guid.NewGuid();

                _context.Jogos.Add(jogos);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Jogos jogosBuscado = _context.Jogos.Find(id)!;

                if (jogosBuscado != null)
                {
                    _context.Jogos.Remove(jogosBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Jogos> Listar()
        {
            try
            {
                return _context.Jogos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}