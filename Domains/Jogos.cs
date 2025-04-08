using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//NameSpace ->>>>>> Caminho em que a classe jogo está.
namespace Projeto_Jogos.Domains
{
    [Table("Jogos")]
    //O Index faz com que o NomeDoJogo NÃO se repita.
    [Index(nameof(NomeDoJogo), IsUnique = true)]
    //Public class -> Cria uma classe pública.
    public class Jogos
    {
        //Preencher os atributos
        [Key]
        public Guid JogoID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        //O Required faz com que seja obrigatório preencher o campo NomeDoJogo
        [Required(ErrorMessage = "O nome do jogo é obrigatóio")]
        public string? NomeDoJogo { get; set; }


        [Column(TypeName = "VARCHAR(50)")]

        public string? Plataforma { get; set; }
    }
}
