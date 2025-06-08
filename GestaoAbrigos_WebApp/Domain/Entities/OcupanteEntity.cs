using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAbrigos_WebApp.Domain.Entities
{
    [Table("tb_ocupante")]
    public class OcupanteEntity
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Nome { get; set; } = string.Empty;
        [Required] public int Idade { get; set; }
        public string Genero { get; set; } = string.Empty;

        // Relação N:1 com Abrigo
        public int AbrigoId { get; set; }
        public AbrigoEntity Abrigo { get; set; } = null!;
    }
}
