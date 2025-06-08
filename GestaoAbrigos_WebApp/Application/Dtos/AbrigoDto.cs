using System.ComponentModel.DataAnnotations;

namespace GestaoAbrigos_WebApp.Application.Dtos
{
    public class AbrigoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Capacidade)} é obrigatório")]
        [Range(1, 1000, ErrorMessage = "Capacidade deve ser maior que 0 e menor ou igual a 1000.")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(Status)} é obrigatório")]
        [StringLength(50, ErrorMessage = "Status deve ter no máximo 50 caracteres.")]
        public string Status { get; set; } = string.Empty;

        [Display(Name = "Localização")]
        [Required(ErrorMessage = $"Campo {nameof(LocalizacaoId)} é obrigatório.")]
        public int LocalizacaoId { get; set; }
    }
}
