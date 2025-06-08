using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAbrigos_WebApp.Domain.Entities
{
    [Table("tb_abrigo")]
    public class AbrigoEntity
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Nome { get; set; } = string.Empty;
        [Required] public int Capacidade { get; set; }
        [Required] public string Status { get; set; } = string.Empty;

        // Relação 1:1 com Localizacao
        public int LocalizacaoId { get; set; }
        public LocalizacaoEntity Localizacao { get; set; } = null!;

        // Relação 1:N com Ocupantes
        public ICollection<OcupanteEntity> Ocupantes { get; set; } = new List<OcupanteEntity>();
    }
}
