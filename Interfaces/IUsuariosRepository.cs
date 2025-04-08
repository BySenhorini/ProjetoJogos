using Projeto_Jogos.Domains;

namespace Projeto_Jogos.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IUsuariosRepository
    {
        /// <summary>
        /// </summary>
        void Cadastrar(Usuarios usuarios);


        /// <summary>
        /// </summary>
        void Deletar(Guid id);

        /// <summary>
        /// </summary>
        void Atualizar(Guid id, Usuarios usuarios);

        /// <summary>
        /// </summary>
        Usuarios BuscarPorId(Guid id);

        /// <summary>
        /// </summary>
        List<Usuarios> Listar();
    }
}