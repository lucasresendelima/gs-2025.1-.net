using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoAbrigos_WebApp.Domain.Entities
{
    [Table("tb_recurso")]
    public class RecursoEntity
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Nome { get; set; } = string.Empty;
        [Required] public string Tipo { get; set; } = string.Empty;
        [Required] public string UnidadeMedida { get; set; } = string.Empty;
    }
}

