using System.ComponentModel.DataAnnotations;

namespace GestaoAbrigos_WebApp.Application.Dtos
{
    public class OcupanteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Idade)} é obrigatório")]
        [Range(0, 130, ErrorMessage = "Idade deve ser entre 0 e 130 anos.")]
        public int Idade { get; set; }

        [StringLength(20, ErrorMessage = "Gênero deve ter no máximo 20 caracteres.")]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(AbrigoId)} é obrigatório.")]
        public int AbrigoId { get; set; }
    }

    public class OcupanteEditDto : OcupanteDto
    {
        public new int Id { get; set; }
    }
}
