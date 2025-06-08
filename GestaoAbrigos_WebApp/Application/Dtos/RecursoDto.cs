using System.ComponentModel.DataAnnotations;

namespace GestaoAbrigos_WebApp.Application.Dtos
{
    public class RecursoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatório")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Nome deve ter entre 2 e 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Tipo)} é obrigatório")]
        [StringLength(100, ErrorMessage = "Tipo deve ter no máximo 100 caracteres.")]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(UnidadeMedida)} é obrigatório")]
        [StringLength(50, ErrorMessage = "Unidade de medida deve ter no máximo 50 caracteres.")]
        public string UnidadeMedida { get; set; } = string.Empty;
    }
}
