using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAbrigos_WebApp.Domain.Entities
{
    [Table("tb_localizacao")]
    public class LocalizacaoEntity
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Rua { get; set; } = string.Empty;
        [Required] public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        [Required] public string Cidade { get; set; } = string.Empty;
        [Required] public string Estado { get; set; } = string.Empty;
        [Required] public string Cep { get; set; } = string.Empty;

        // Relação 1:N com Abrigos
        public ICollection<AbrigoEntity> Abrigos { get; set; } = new List<AbrigoEntity>();
    }
}
