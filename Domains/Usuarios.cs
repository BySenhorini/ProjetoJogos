using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//NameSpace ->>>>>> Caminho em que a classe jogo está.
namespace Projeto_Jogos.Domains
{
    [Table("Usuarios")]
    [Index(nameof(Nickname), IsUnique = true)]
    //Public class -> Cria uma classe pública.
    public class Usuarios
    {
        //Preencher os atributos
        [Key]
        public Guid UsuarioID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome do usuario é obrigatóio")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(30)")] 
        [Required(ErrorMessage = "O Nickname é obrigatóio")]
        public string? Nickname { get; set; }

        public Guid JogoFavorito { get; set; }
        [ForeignKey("JogoFavorito")]

        public Jogos? Jogos { get; set; }


    }
}